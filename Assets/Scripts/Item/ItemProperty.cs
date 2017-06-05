using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemProperty
{
    public string id;
    public string name;
    public Sprite image;

    public ItemProperty Clone()
    {
        return MemberwiseClone() as ItemProperty;
    }
}
