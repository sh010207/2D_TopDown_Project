using UnityEngine;
using System.IO;
using UnityEditor;

public class MonsterDataLoader
{
    [MenuItem("Tools/Load Monster JSON")]
    public static void LoadMonsterData()
    {
        string path = Application.dataPath + "/Resources/Monster.json";

        if (!File.Exists(path))
        {
            Debug.LogError("파일이 존재하지 않아요: " + path);
            return;
        }

        string json = File.ReadAllText(path);
        string wrappedJson = json;

        MonsterDataListWrapper wrapper = JsonUtility.FromJson<MonsterDataListWrapper>(wrappedJson);
        if (wrapper == null || wrapper.Monster == null)
        {
            Debug.LogError("JSON 파싱 실패!");
            return;
        }

        MonsterDatabase asset = ScriptableObject.CreateInstance<MonsterDatabase>();
        asset.monsters = wrapper.Monster;

        AssetDatabase.CreateAsset(asset, "Assets/Resources/MonsterDatabase.asset");
        AssetDatabase.SaveAssets();

        Debug.Log("SO 생성완료");
    }
}
