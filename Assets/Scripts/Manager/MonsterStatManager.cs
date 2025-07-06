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
    public UnityAction monsterDieEvent;
    public UnityAction<float,float> hpChangeEvent;

    private MonsterData monsterData;
    private StatHandler statHandler;

    private float damage;
    private float hp;
    private float attackRange;
    private float moveSpeed;
    private float attackSpeed;
    private float maxHp;
    private int itemID;

    private MonsterAnimationController monsterAnimationController;
    private void Awake()
    {
        monsterAnimationController = GetComponent<MonsterAnimationController>();    
        monsterData =  MonsterSpawn.instance.ChacedMonster();
        statHandler = new StatHandler();
        Init();
    }

    private void Init()
    {
        damage = monsterData.Attack;
        hp = monsterData.MaxHP;
        maxHp = monsterData.MaxHP;
        attackRange = monsterData.AttackRange;
        moveSpeed = monsterData.MoveSpeed;
        attackSpeed = monsterData.AttackSpeed;
        itemID = monsterData.DropItem;
    }

    private void UpdateStat(MonsterStat value)
    {
        switch(value)
        {
            case MonsterStat.Hp:
                if (hp <= 0) 
                    Die();            
                break;
            case MonsterStat.Damage:
                break;
        }
    }

    private void Die()
    {
        this.gameObject.layer = LayerMask.NameToLayer("Default");
        monsterDieEvent?.Invoke();
        monsterAnimationController.DeadAnimation(true);
        Invoke("DestroyObject", 1f);
        ItemManager.Instance.CachedItem(itemID);
        ItemManager.Instance.CreateItem(this.transform);
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }

    public float GetMonsterStat(MonsterStat stat )
    {
        switch(stat)
        {
            case MonsterStat.Hp:
                return hp;
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
        monsterAnimationController.HitAnimation();
        float currentHP = statHandler.Sub(hp, damage);
        hp = currentHP;
        UpdateStat(MonsterStat.Hp);
        takeDamageEvent?.Invoke();
        hpChangeEvent?.Invoke(hp, maxHp);
    }
}
