using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climbing : MonoBehaviour
{
    public bool isTouchingWall;

    void Start()
    {
        isTouchingWall = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "ChunkBlock" || col.gameObject.tag == "ChunkBlockMountain")
        {
            isTouchingWall = true;
        }
    }

    public void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "ChunkBlock" || col.gameObject.tag == "ChunkBlockMountain")
        {
            isTouchingWall = false;
        }
    }

    public bool getTouchingWall()
    {
        return isTouchingWall;
    }
}
