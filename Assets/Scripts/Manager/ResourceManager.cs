using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager instance;
    private void Awake()
    {
        instance = this;
        Debug.Log($"{instance.name}");
    }

    public T ResourceLoad<T>(string name) where T : Object
    {
        T data = Resources.Load<T>($"ScriptableObject/{name}");
        Debug.Log($"{data.name}");
        return data;
    }
}
