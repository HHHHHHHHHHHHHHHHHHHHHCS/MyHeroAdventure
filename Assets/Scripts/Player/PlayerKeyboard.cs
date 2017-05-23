using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerKeyboard 
{
    [SerializeField]
    private KeyCode up;
    [SerializeField]
    private KeyCode down;
    [SerializeField]
    private KeyCode left;
    [SerializeField]
    private KeyCode right;

    public KeyCode Up
    {
        get
        {
            return up;
        }
    }

    public KeyCode Down
    {
        get
        {
            return down;
        }
    }

    public KeyCode Left
    {
        get
        {
            return left;
        }
    }

    public KeyCode Right
    {
        get
        {
            return right;
        }
    }
}
