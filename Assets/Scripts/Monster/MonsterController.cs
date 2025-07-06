using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    private MonsterStatManager monsterStatManager;
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider2D;
    private Transform target;
    private SpriteRenderer spriteRenderer;
    private bool isStaggered = false;

    public LayerMask playerLayer;

    // 각각의 몬스터의 공격범위 
    private float attackRange;
    // 각각의 몬스터의 속도
    private float moveSpeed;
    private float attackSpeed;
    private float currentHp;
    private float currentDamage;

    private bool canAttack = true;

    private void OnEnable()
    {
        monsterStatManager.takeDamageEvent += OnHitEvent;
    }

    private void OnDisable()
    {
        monsterStatManager.takeDamageEvent -= OnHitEvent;
    }

    private void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        monsterStatManager = GetComponent<MonsterStatManager>();
        rb = GetComponentInChildren<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        if (target == null)
        {
            Debug.Log("tartget이 Null입니다.");
        }
    }
    private void Start()
    {
        SetMonsterStat();
    }

    private void FixedUpdate()
    {
        if (isStaggered || target == null)
        {
            return;
        }
        else
        {
            Move(); 
        }
    }

    private void Update()
    {
        if (isStaggered || target == null)
        {
            return;
        }
        else
        {
            LookAtTarget();
        }
        if(canAttack)
        {
            StartCoroutine(AttackCoroutine(attackSpeed));
        }
        else
        {
            return;
        }
    }

    private void Move()
    {
        if (target == null) return;

        Vector2 dir = ((Vector2)target.position - rb.position).normalized;

        if (Vector2.Distance(transform.position, target.position) >= attackRange)
        {
            rb.MovePosition(rb.position + dir * moveSpeed * Time.fixedDeltaTime);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void LookAtTarget()
    {
        if (transform.position.x < target.position.x)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }
    }

    private void SetMonsterStat()
    {
        moveSpeed = monsterStatManager.GetMonsterStat(MonsterStat.MoveSpeed);
        attackRange = monsterStatManager.GetMonsterStat(MonsterStat.AttackRange);
        attackSpeed = monsterStatManager.GetMonsterStat(MonsterStat.AttackSpeed);
        currentHp = monsterStatManager.GetMonsterStat(MonsterStat.Hp);
        currentDamage = monsterStatManager.GetMonsterStat(MonsterStat.Damage);
    }

    private void OnHitEvent()
    {
        // duration은 무기에따라 변경 가능
        StartCoroutine(StaggerCoroutine(0.5f));
    }


    private IEnumerator StaggerCoroutine(float duration)
    {
        isStaggered = true;

        yield return new WaitForSeconds(duration);

        isStaggered = false;
    }

    private IEnumerator AttackCoroutine(float duration)
    {

        Vector2 dirToTarget = ((Vector2)target.position - (Vector2)transform.position).normalized;

        Vector2 boxCenter = (Vector2)transform.position + boxCollider2D.offset + dirToTarget * 0.5f;
        float boxSizeX = boxCollider2D.size.x * attackRange;
        Vector2 boxSize = new Vector2(boxSizeX, boxCollider2D.size.y);

        canAttack = false;

        Collider2D hit = Physics2D.OverlapBox(boxCenter, boxSize, 0, playerLayer);
        if (hit != null)
        {
            IDamageble player = hit.GetComponent<IDamageble>();
            if (player != null)
            {
                player.TakeDamage(currentDamage);
            }
        }

        yield return new WaitForSeconds(attackSpeed);

        canAttack = true;
    }

    private void OnDrawGizmosSelected()
    {
        if (boxCollider2D == null || target == null) return;

        Gizmos.color = Color.red;

        Vector2 dirToTarget = ((Vector2)target.position - (Vector2)transform.position).normalized;

        Vector2 boxCenter = (Vector2)transform.position + boxCollider2D.offset + dirToTarget * 0.5f;
        float boxSizeX = boxCollider2D.size.x * attackRange;
        Vector2 boxSize = new Vector2(boxSizeX, boxCollider2D.size.y);

        Gizmos.DrawWireCube(boxCenter, boxSize);
    }
}
