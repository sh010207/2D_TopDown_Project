using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponController : MonoBehaviour
{
    public UnityAction<float> action;

    private BoxCollider2D box;
    private SpriteRenderer spriteRenderer;
    private Weapon weapon;

    private float angle;
    public LayerMask monsterLayer;

    private float playerDamage;

    private bool canAttack = true;

    private IDamageble damageble;

    private void Awake()
    {
        weapon = GetComponentInChildren<Weapon>();
        box = GetComponentInChildren<BoxCollider2D>();
    }

    private void Update()
    {
        RotateWeapon();
        if(canAttack)
        {
            StartCoroutine(AttackCoroutine());
        }
    }

    public float SetPlayerDamage(float damage)
    {
        return playerDamage = damage;
    }

    private void RotateWeapon()
    {
        transform.Rotate(Vector3.back * weapon.RoataeSpeed * Time.deltaTime);
    }

    private IEnumerator AttackCoroutine()
    {
        Vector2 boxCenter = weapon.gameObject.transform.position;
        Vector2 boxSize = box.size;
        float boxAngle = transform.eulerAngles.z;

        canAttack = false;

        Collider2D[] hits = Physics2D.OverlapBoxAll(boxCenter, boxSize, boxAngle, monsterLayer);

        foreach (var hit in hits)
        {
            IDamageble monster = hit.GetComponent<IDamageble>();
            if(monster != null)
            {
                action?.Invoke(playerDamage);
                monster.TakeDamage(playerDamage + weapon.WeaponDamage);
            }
        }

        yield return new WaitForSeconds(weapon.AttackCoolDown);

        canAttack  = true;  
    }
}
