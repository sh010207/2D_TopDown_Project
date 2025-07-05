using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MonsterDataBase", menuName = "SO/MonsterBase")]
public class MonsterDatabase : ScriptableObject
{
    public List<MonsterData> monsters;
}
