﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonUsingLazy<T> : MonoBehaviour where T : class
{
    private static readonly Lazy<T> _instance =
        new Lazy<T>(() =>
        {
            T instance = FindObjectOfType(typeof(T)) as T;

            if (instance == null)
            {
                GameObject obj = new GameObject("GameManagers");
                instance = obj.AddComponent(typeof(T)) as T;

                DontDestroyOnLoad(obj);
            }

            return instance;
        });

    public static T Instance
    {
        get
        {
            return _instance.Value;
        }
    }
}
