using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDatabase", menuName = "SO/ItemDatabase")]
public class ItemDatabase : ScriptableObject
{
    public List<ItemData> Items = new List<ItemData>();
}
