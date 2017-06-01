using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPC_Base:MonoBehaviour
{
    [SerializeField]
    protected string npcName;

    protected ButtonClick nextButton = new ButtonClick() { text = "下一步"};

    public abstract void Talk();

}
