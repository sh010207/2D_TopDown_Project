using UnityEngine;

public class Item : MonoBehaviour
{
    private ItemData itemData;

    private void Awake()
    {
    }

    public void SetItemData(ItemData item)
    {
        itemData = item;
        Debug.Log($"{itemData.Name}");

    }
}
