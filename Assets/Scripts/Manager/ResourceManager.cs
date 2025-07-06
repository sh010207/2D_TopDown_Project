using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager instance;
    private void Awake()
    {
        instance = this;
    }

    public T ResourceLoad<T>(string name) where T : Object
    {
        T data = Resources.Load<T>($"ScriptableObject/{name}");
        return data;
    }
}
