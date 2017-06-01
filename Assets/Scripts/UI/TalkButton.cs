using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TalkButton : MonoBehaviour
{
    [SerializeField]
    private Button btn;
    [SerializeField]
    private Text str;

    public void Init(int i, string _str, UnityAction _click)
    {
        gameObject.SetActive(true);
        str.text = string.Format("{0}. {1}", i + 1, _str);
        btn.onClick.RemoveAllListeners();
        btn.onClick.AddListener(_click);
    }
}
