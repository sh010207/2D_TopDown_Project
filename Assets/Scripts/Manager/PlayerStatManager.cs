using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatManager : MonoBehaviour, IDamageble
{
    private PlayerData _playerData;
    private StatHandler statHandler;

    private float currentHp;
    private float damage;
    private float moveSpeed;

    private void Start()
    {
        _playerData = ResourceManager.instance.ResourceLoad<PlayerData>("PlayerData");
        statHandler = new StatHandler();
        Init();
    }

    private void Init()
    {
        currentHp = _playerData.HP;
        damage = _playerData.Damage;
        moveSpeed = _playerData.MoveSpeed;
    }


    public void TakeDamage(float value)
    {
        currentHp = statHandler.Sub(currentHp, value);
        UpdateStat(value);
    }


    private void UpdateStat(float vlaue)
    {
        if (currentHp <= 0)
        {
            Die();
        }

        // UI 호출하면서 업데이트 시켜주는
    }

    private void Die()
    {

    }
}
