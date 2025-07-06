using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerStatManager statManager;
    private WeaponController controller;

    private void OnEnable()
    {
        controller.action += TossDamage;
    }

    private void OnDisable()
    {
        controller.action -= TossDamage;
    }

    private void Awake()
    {
        statManager = GetComponent<PlayerStatManager>();
        controller = GetComponentInChildren<WeaponController>();
    }

    private void TossDamage(float value)
    {
        value = statManager.GetPlayerStat(PlayerStat.Damage);
        controller.SetPlayerDamage(value);
    }
    
}
