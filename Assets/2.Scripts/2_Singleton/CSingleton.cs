using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSingleton<T> : MonoBehaviour where T : Component
{
    private static T _instance;
    private static bool _ShuttingDown = false;
    private static object _Lock = new object();
    public static T Instance{
        get
        {
            if (_ShuttingDown)
            {
                Debug.LogWarning("[Singleton] Instance '" + typeof(T) +
                    "' already destroyed. Returning null.");
                return null;
            }
 
            lock (_Lock)
            {
                if (_instance == null)
                {
                    // Search for existing instance.
                    _instance = (T)FindObjectOfType(typeof(T));
 
                    // Create new instance if one doesn't already exist.
                    if (_instance == null)
                    {
                        // Need to create a new GameObject to attach the singleton to.
                        var singletonObject = new GameObject();
                        _instance = singletonObject.AddComponent<T>();
                        singletonObject.name = typeof(T).ToString() + " (Singleton)";
 
                        // Make instance persistent.
                        DontDestroyOnLoad(singletonObject);
                    }
                }
 
                return _instance;
            }
        }
    }
    
    private void OnDestroy()
    {
        _ShuttingDown = true;
    }

    private void OnApplicationQuit()
    {
        _ShuttingDown = true;
    }
}

public class CSingletonPersistent<T> : MonoBehaviour where T : Component
{
    private static T _instance;
    public static T Instance{
        get{
            // if(_instance == null){
            //     GameObject obj = new GameObject();
            //     obj.name = typeof(T).Name;
            //     obj.hideFlags = HideFlags.HideAndDontSave;
            //     _instance = obj.AddComponent<T>();
            // }
            return _instance;
        }
        set{

        }
    }
    
    public virtual void Awake() {
        if(_instance == null){
            _instance = this as T;
            DontDestroyOnLoad(this);
        }
        else {
            Destroy(this);
        }
    }
    private void OnDestroy() {
        if(_instance == this){
            _instance = null;
        }
    }
}

