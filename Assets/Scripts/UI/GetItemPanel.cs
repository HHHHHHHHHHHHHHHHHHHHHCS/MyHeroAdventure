using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class GetItemPanel : MonoBehaviour
{
    [SerializeField]
    private float hideTime = 3f;

    [SerializeField]
    private Image image;
    [SerializeField]
    private Text text;

    private float imageAlpha;
    private float textAlpha;

    private float imageAlphaSpeed;
    private float textAlphaSpeed;


    private void Awake()
    {
        imageAlpha = image.color.a;
        textAlpha = text.color.a;

        imageAlphaSpeed = hideTime <= 0 ? imageAlpha : imageAlpha / hideTime;
        textAlphaSpeed = hideTime <= 0 ? textAlpha : textAlpha / hideTime;
    }

    public void Update()
    {
        Color col = image.color;
        if (col.a <= 0)
        {
            gameObject.SetActive(false);
        }
        else
        {
            col.a = Mathf.Clamp01(col.a - imageAlphaSpeed * Time.deltaTime);
            image.color = col;

            col = text.color;
            col.a = Mathf.Clamp01(col.a - textAlphaSpeed * Time.deltaTime);
            text.color = col;
        }


    }

    public void SetItem(params string[] items)
    {
        text.text = "";
        StringBuilder sb = new StringBuilder("");
        string end = items[items.Length - 1];
        foreach (var i in items)
        {
            sb.Append(i);
            if (i != end)
            {
                sb.Append('\n');
            }
        }

        Color col = image.color;
        col.a = imageAlpha;
        image.color = col;

        col = text.color;
        col.a = textAlpha;
        text.color = col;
    }
}
