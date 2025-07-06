using UnityEngine;
using System.IO;
using UnityEditor;

public class ItemDataLoader
{
    [MenuItem("Tools/Load Item JSON")]
    public static void LoadItemData()
    {
        string path = Application.dataPath + "/Resources/Items.json";

        if (!File.Exists(path))
        {
            Debug.LogError("파일이 존재하지 않아요: " + path);
            return;
        }

        string json = File.ReadAllText(path);
        string wrappedJson = json;

        ItemDataListWrapper wrapper = JsonUtility.FromJson<ItemDataListWrapper>(wrappedJson);
        if (wrapper == null || wrapper.Item == null)
        {
            Debug.LogError("JSON 파싱 실패!");
            return;
        }

        ItemDatabase asset = ScriptableObject.CreateInstance<ItemDatabase>();
        asset.Items = wrapper.Item;

        AssetDatabase.CreateAsset(asset, "Assets/Resources/ItemDatabase.asset");
        AssetDatabase.SaveAssets();

        Debug.Log("SO 생성완료");
    }
}

