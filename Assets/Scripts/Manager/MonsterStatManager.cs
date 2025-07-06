using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;


public enum MonsterStat
{
    Hp,
    Damage,
    AttackRange,
    AttackSpeed,
    MoveSpeed
}

public class MonsterStatManager : MonoBehaviour, IDamageble
{
    public UnityAction takeDamageEvent;

    private MonsterData monsterData;
    private StatHandler statHandler;

    private float damage;
    private float currentHp;
    private float attackRange;
    private float moveSpeed;
    private float attackSpeed;


    private void Awake()
    {
        monsterData =  MonsterSpawn.instance.ChacedMonster();
        statHandler = new StatHandler();
        Init();
    }

    private void Init()
    {
        damage = monsterData.Attack;
        currentHp = monsterData.MaxHP;
        attackRange = monsterData.AttackRange;
        moveSpeed = monsterData.MoveSpeed;
        attackSpeed = monsterData.AttackSpeed;
    }

    private void UpdateStat(MonsterStat value)
    {
        switch(value)
        {
            case MonsterStat.Hp:
                if (currentHp <= 0) 
                    Die();            
                break;
            case MonsterStat.Damage:
                break;
        }
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }

    public float GetMonsterStat(MonsterStat stat )
    {
        switch(stat)
        {
            case MonsterStat.Hp:
                return currentHp;
            case MonsterStat.Damage:
                return damage;
            case MonsterStat.AttackSpeed:
                return attackSpeed;
            case MonsterStat.AttackRange:
                return attackRange;
            case MonsterStat.MoveSpeed:
                return moveSpeed;
            default:
                return 0f;
        }
    }

    public void TakeDamage(float damage)
    {
        float currentHP = statHandler.Sub(currentHp , damage);
        currentHp = currentHP;
        UpdateStat(MonsterStat.Hp);
        Debug.Log($"{currentHp}");
        takeDamageEvent?.Invoke();
    }
}
