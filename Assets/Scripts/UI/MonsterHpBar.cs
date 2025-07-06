using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHpBar : HealthBar
{
    private MonsterStatManager monsterStatManager;

    private void OnEnable()
    {
        monsterStatManager.hpChangeEvent += UpdateHpBar;
    }

    private void OnDisable()
    {
        monsterStatManager.hpChangeEvent -= UpdateHpBar;
    }

    private void Awake()
    {
        monsterStatManager = GetComponent<MonsterStatManager>();
    }

    protected override void UpdateHpBar(float currentHp, float maxHp)
    {
        base.UpdateHpBar(currentHp, maxHp);
    }
}
