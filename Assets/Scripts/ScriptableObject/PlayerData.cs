using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "SO/PlayerData")]
public class PlayerData : ScriptableObject
{
    public float HP;
    public float Damage;
    public float MoveSpeed;
    public float MaxHp;
}
