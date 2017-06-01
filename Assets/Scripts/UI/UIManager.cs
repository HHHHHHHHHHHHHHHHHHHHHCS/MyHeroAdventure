using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;

    public static UIManager Instance
    {
        get
        {
            return _instance;
        }
    }

    [SerializeField]
    private TalkPanel talkPanel;

    public TalkPanel TalkPanel
    {
        get
        {
            return talkPanel;
        }
    }



    private void Awake()
    {
        _instance = this;
    }
}
