using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Base : MonoBehaviour
{
    [SerializeField]
    protected string itemID;


    protected SpriteRenderer spriteRenderer;
    protected ItemProperty itemProperty;

    protected virtual void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    protected virtual void Start()
    {
        itemProperty = DataManager.Instance.ItemInfo.FindItem(itemID);
        spriteRenderer.sprite = itemProperty.image;
    }


    public virtual void GetItem()
    {
        Debug.Log(itemProperty.name);
    }
}
