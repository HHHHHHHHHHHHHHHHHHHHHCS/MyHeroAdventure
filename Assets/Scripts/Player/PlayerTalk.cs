using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTalk : MonoBehaviour
{
    public bool IsTalk
    {
        get;
        private set;
    }


    public void SetTalk()
    {
        IsTalk = true;
    }

    public void CancelTalk()
    {
        IsTalk = false;
    }
}
