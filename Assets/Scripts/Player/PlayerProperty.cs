using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerProperty
{
    [SerializeField]
    private int hp;
    [SerializeField]
    private int attack;
    [SerializeField]
    private int armor;
    [SerializeField]
    private float moveTime=0.1f;

    public int Hp
    {
        get
        {
            return hp;
        }

        set
        {
            hp = value;
        }
    }

    public int Attack
    {
        get
        {
            return attack;
        }

        set
        {
            attack = value;
        }
    }

    public int Armor
    {
        get
        {
            return armor;
        }

        set
        {
            armor = value;
        }
    }

    public float MoveTime
    {
        get
        {
            return moveTime;
        }

        set
        {
            moveTime = value;
        }
    }
}
