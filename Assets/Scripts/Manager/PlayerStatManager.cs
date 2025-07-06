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
    private PlayerAnimationController _controller;
    private PlayerData _playerData;
    private StatHandler statHandler;

    private float currentHp;
    private float damage;
    private float moveSpeed;

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
    }


    public void TakeDamage(float value)
    {
        _controller.HitAnimation();
        currentHp = statHandler.Sub(currentHp, value);
        UpdateStat(PlayerStat.Hp);
        Debug.Log($"데미지를 받았습니다! 받은 데미지 {value}  현재 체력 : {currentHp}");
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

        // UI 호출하면서 업데이트 시켜주는
    }

    public float GetPlayerDamage()
    {
        float value = damage;
        return value;
    }

    private void Die()
    {
        this.gameObject.layer = LayerMask.NameToLayer("Defalut");
        _controller.DeadAnimaiton(true);
        Debug.Log("플레이어가 죽었습니다");
        Invoke("DisablePlayer", 1f);
    }

    private void DisablePlayer()
    {
        this.gameObject.SetActive(false);
    }
}
