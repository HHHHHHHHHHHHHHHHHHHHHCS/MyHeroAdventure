using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
[CreateAssetMenu(fileName = "MyItemAsset", menuName = "My/Item", order = 0)]
public class ItemData : ScriptableObject
{
    public List<ItemProperty> itemList;
}
