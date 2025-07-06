using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

enum PlayerStat
{
    Hp,
    Damage,
    MoveSpeed
}

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
        UpdateStat(PlayerStat.Hp);
        Debug.Log($"�������� �޾ҽ��ϴ�! ���� ������ {value}  ���� ü�� : {currentHp}");
    }


    private void UpdateStat(PlayerStat stat)
    {
        switch(stat)
        {
            case PlayerStat.Hp:
                if (currentHp <= 0) 
                    Die();
                break;
            case PlayerStat.Damage:
                break;
            case PlayerStat.MoveSpeed:
                break;
        }

        // UI ȣ���ϸ鼭 ������Ʈ �����ִ�
    }

    public float GetPlayerDamage()
    {
        float value = damage;
        return value;
    }

    private void Die()
    {
        Debug.Log("�÷��̾ �׾����ϴ�");
        Application.Quit();
    }
}
