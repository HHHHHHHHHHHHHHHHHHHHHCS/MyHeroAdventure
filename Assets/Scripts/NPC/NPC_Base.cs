using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPC_Base:MonoBehaviour
{
    [SerializeField]
    protected string npcName;



    public abstract void Talk();

}
