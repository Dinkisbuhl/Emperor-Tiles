using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSize : MonoBehaviour
{
    public float minHeight;
    public float maxHeight;
    public float minWidth;
    public float maxWidth;
    public void Awake()
    {
        float height = Random.Range(minHeight, maxHeight);
        float width = Random.Range(minWidth, maxWidth);
        Vector3 scaleObj = new Vector3(width, height, width);
        this.transform.localScale = scaleObj;
    }
}
