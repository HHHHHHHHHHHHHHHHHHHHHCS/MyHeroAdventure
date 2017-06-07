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

    [SerializeField]
    private GetItemPanel getItemPanel;

    public TalkPanel TalkPanel
    {
        get
        {
            return talkPanel;
        }
    }

    public GetItemPanel GetItemPanel
    {
        get
        {
            return getItemPanel;
        }
    }

    private void Awake()
    {
        _instance = this;
    }
}
