using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SweepChild : MonoBehaviour
{
    public float timer;

    void Start()
    {
        timer = 5f;
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "ChunkObj")
        {
            Destroy(col.gameObject);
        }
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
