using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    public static MonsterSpawn instance;
    public Transform[] spawnPos;
    public GameObject monsterPrefab;
    private MonsterDatabase monsterDatabase;
    private List<MonsterData> monsters;

    private void Start()
    {
        instance = this;
        monsterDatabase = ResourceManager.instance.ResourceLoad<MonsterDatabase>("MonsterDatabase");
        monsters = monsterDatabase.monsters;
        Spawn();
    }

    public MonsterData ChacedMonster()
    {
        int random = Random.Range(0, monsters.Count);
        var data = monsters[random];
        return data;
    }

    public void Spawn()
    {
        for (int i = 0; i < spawnPos.Length; i++)
        {
            var pos = spawnPos[i].position;
            Instantiate(monsterPrefab, pos, Quaternion.identity);
        }
    }
}
