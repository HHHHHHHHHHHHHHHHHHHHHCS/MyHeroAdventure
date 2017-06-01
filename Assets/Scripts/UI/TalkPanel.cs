using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public struct ButtonClick
{
    public string text;
    public UnityAction onClick;
}

public class TalkPanel : MonoBehaviour
{
    [SerializeField]
    private Button talkButtonPrefab;

    [SerializeField]
    private Text talkName;
    [SerializeField]
    private Text talkContent;
    [SerializeField]
    private TalkButton[] buttons;

    public void SetTalk(string _name, string _content, params ButtonClick[] buttonEvents)
    {
        ShowPanel();
        talkName.text = string.Format("{0}:", _name);
        talkContent.text = _content;

        if (buttonEvents == null)
        {
            HideAllButtons();
        }
        else
        {
            for (int i = 0; i < buttonEvents.Length; i++)
            {
                buttons[i].Init(i,buttonEvents[i].text, buttonEvents[i].onClick);
            }
            for (int i = buttonEvents.Length; i < buttons.Length; i++)
            {
                buttons[i].gameObject.SetActive(false);
            }
        }


    }

    void HideAllButtons()
    {
        foreach (var item in buttons)
        {
            item.gameObject.SetActive(false);
        }
    }


    public void HidePanel()
    {
        PlayerCtrl.Instance.PlayerTalk.CancelTalk();
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
    }

    public void ShowPanel()
    {
        PlayerCtrl.Instance.PlayerTalk.SetTalk();
        if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
        }
    }
}
