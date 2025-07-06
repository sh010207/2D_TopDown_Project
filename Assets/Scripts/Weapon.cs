using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // 임의적 무기 데미지와 공격 속도
    private float damage = 10f;
    private float roataeSpeed = 100.0f;
    private float attackCoolDown = 0.5f;

    public float WeaponDamage { get; private set; }
    public float RoataeSpeed {  get; private set; }
    public float AttackCoolDown {  get; private set; }

    private void Awake()
    {
        WeaponDamage = damage;
        RoataeSpeed = roataeSpeed;
        AttackCoolDown = attackCoolDown;
    }

    //public Weapon(float weaponDamage, float roataeSpeed, float attackCoolDown)
    //{
    //    WeaponDamage = weaponDamage;
    //    RoataeSpeed = roataeSpeed;
    //    AttackCoolDown = attackCoolDown;
    //}
}
