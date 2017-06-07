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
    private Text titleText;
    [SerializeField]
    private Text contentText;

    private float imageAlpha;
    private float textAlpha;

    private float imageAlphaSpeed;
    private float textAlphaSpeed;

    private bool isShow;

    private void Awake()
    {
        imageAlpha = image.color.a;
        textAlpha = contentText.color.a;

        imageAlphaSpeed = hideTime <= 0 ? imageAlpha : imageAlpha / hideTime;
        textAlphaSpeed = hideTime <= 0 ? textAlpha : textAlpha / hideTime;
    }

    public void Update()
    {
        if(isShow)
        {
            Color col = image.color;
            if (col.a <= 0)
            {
                isShow = false;
                gameObject.SetActive(false);
            }
            else
            {
                col.a = Mathf.Clamp01(col.a - imageAlphaSpeed * Time.deltaTime);
                image.color = col;

                col = titleText.color;
                col.a = Mathf.Clamp01(col.a - textAlphaSpeed * Time.deltaTime);
                titleText.color = col;

                col = contentText.color;
                col.a = Mathf.Clamp01(col.a - textAlphaSpeed * Time.deltaTime);
                contentText.color = col;
            }
        }



    }

    public void SetItem(params string[] items)
    {
        isShow = true;
        gameObject.SetActive(true);
        contentText.text = "";
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
        contentText.text = sb.ToString();

        Color col = image.color;
        col.a = imageAlpha;
        image.color = col;

        col = titleText.color;
        col.a = textAlpha;
        titleText.color = col;

        col = contentText.color;
        col.a = textAlpha;
        contentText.color = col;
    }
}
