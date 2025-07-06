using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private ItemData item;
    public GameObject itemPrefab;
    public static ItemManager Instance;
    private ItemDatabase ItemDatabase;
    private List<ItemData> Items;

    private void Start()
    {
        Instance = this;
        ItemDatabase =  ResourceManager.instance.ResourceLoad<ItemDatabase>("ItemDatabase");

        Items = ItemDatabase.Items;
    }

    public void CreateItem(Transform itemCreatePoint)
    {
        GameObject obj = Instantiate(itemPrefab, itemCreatePoint.position, Quaternion.identity);
        var data  = obj.GetComponent<Item>();
        data.SetItemData(item);
    }

    public void CachedItem(int itemID)
    {
        ItemData data;
        foreach (ItemData itemData in Items)
        {
            if(itemData.ItemID == itemID)
            {
                data = itemData;
                item = data;
                break;
            }
        }
        
    }
}
