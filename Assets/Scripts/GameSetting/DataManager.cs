using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private static DataManager _instance;

    public static DataManager Instance
    {
        get
        {
            return _instance;
        }

    }

    public ItemManager ItemInfo
    {
        get;
        private set;
    }


    private void Awake()
    {
        if(_instance==null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
            ItemInfo = new ItemManager();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
