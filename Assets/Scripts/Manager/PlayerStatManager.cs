using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum PlayerStat
{
    Hp,
    MaxHp,
    Damage,
    MoveSpeed
}

public class PlayerStatManager : MonoBehaviour, IDamageble
{
    public UnityAction<float, float> hpChangedEvent;

    private PlayerAnimationController _controller;
    private PlayerData _playerData;
    private StatHandler statHandler;


    private float currentHp;
    private float damage;
    private float moveSpeed;
    private float maxHp;

    private void OnEnable()
    {
        this.gameObject.layer = LayerMask.NameToLayer("Player");
    }

    private void Start()
    {
        _controller = GetComponent<PlayerAnimationController>();
        _playerData = ResourceManager.instance.ResourceLoad<PlayerData>("PlayerData");
        statHandler = new StatHandler();
        Init();
    }

    private void Init()
    {
        currentHp = _playerData.HP;
        damage = _playerData.Damage;
        moveSpeed = _playerData.MoveSpeed;
        maxHp = _playerData.MaxHp;
    }


    public void TakeDamage(float value)
    {
        _controller.HitAnimation();
        currentHp = statHandler.Sub(currentHp, value);
        UpdateStat(PlayerStat.Hp);
        hpChangedEvent?.Invoke(currentHp, maxHp);
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
    }

    public float GetPlayerStat(PlayerStat stat)
    {
        switch(stat)
        {
            case PlayerStat.Hp:
                return currentHp;
            case PlayerStat.Damage:
                return damage;
            case PlayerStat.MoveSpeed:
                return moveSpeed;
            case PlayerStat.MaxHp:
                return maxHp;
            default:
                return 0;
        }
    }

    private void Die()
    {
        if (currentHp <= 0) return;
        this.gameObject.layer = LayerMask.NameToLayer("Defalut");
        _controller.DeadAnimaiton(true);
        Debug.Log("�÷��̾ �׾����ϴ�");
        Invoke("DisablePlayer", 1f);
    }

    private void DisablePlayer()
    {
        this.gameObject.SetActive(false);
    }
}
