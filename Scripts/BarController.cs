using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarController : MonoBehaviour
{
    public float value;
    public float panicValue;
    public Gradient flash;
    float baseWidth;
    float pValue;

    float lerp = 0;
    RectTransform rect;
    Image bar;

    void Start()
    {
        rect = transform.GetChild(0).GetComponent<RectTransform>();
        bar = transform.GetChild(0).GetComponent<Image>();
        baseWidth = rect.rect.width;
        pValue = value;
        bar.color = flash.Evaluate(0);
    }

    void Update()
    {
        if (value < pValue)
        {
            rect.sizeDelta = new Vector2(baseWidth * value, rect.sizeDelta.y);
            lerp = Mathf.Sqrt(pValue - value);
        }

        if (lerp <= 0 && value < panicValue)
        {
            lerp = 1;
        }

        if (lerp > 0)
        {
            bar.color = flash.Evaluate(lerp);
            lerp -= Time.deltaTime;
        }

        pValue = value;
    }
}
