using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    static T instance;
    public static T Instance => instance;

    void Awake()
    {
        Init();
    }

    void Init()
    {
        if(instance)
        {
            Destroy(this);
            return;
        }
        instance = this as T;
    }
}
