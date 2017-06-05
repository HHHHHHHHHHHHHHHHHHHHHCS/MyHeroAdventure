using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager
{
    private const string dataPath = "Data/MyItemAsset";
    public List<ItemProperty> ItemList
    {
        get;
        private set;
    }

    public Dictionary<string, ItemProperty> ItemDic
    {
        get;
        private set;
    }


    public ItemManager()
    {
        Init();
    }

    void Init()
    {
        ItemList = ((ItemData)Resources.Load(dataPath)).itemList;

        ItemDic = new Dictionary<string, ItemProperty>();
        foreach(var i in ItemList)
        {
            if(!ItemDic.ContainsKey(i.id))
            {
                ItemDic.Add(i.id, i);
            }
        }
    }

    public ItemProperty FindItem(string id)
    {
        if(ItemDic!=null&& ItemDic.ContainsKey(id))
        {
            return ItemDic[id];
        }
        return null;
    }
}
