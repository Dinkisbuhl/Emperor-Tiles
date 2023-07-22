using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SweepChunkObj : MonoBehaviour
{
    public float timer;
    public float averageHeight = 0;
    public GameObject[] chunks = new GameObject[4];
    private int index = 0;
    public bool equalized = false;
    public GameObject toBuild;
    public GameObject sweepChild1x1;
    public GameObject sweepChild2x2;
    public float chunkX = 0;
    public float chunkZ = 0;
    public float yPos = 0;

    public bool containsMountains = false;
    public bool containsNonMountains = false;
    public bool containsBuildings = false;
    public bool containsPlayers = false;
    public bool is2x2 = false;

    public int teamOwner = 0;

    void Start()
    {
        timer = 20f;
    }

    public void OnTriggerEnter(Collider col)
    {
        if ((col.gameObject.tag == "ChunkBlock" || col.gameObject.tag == "ChunkBlockMountain") && index < 4)
        {
            bool cont = true;
            for (int i = 0; i < index; i++)
            {
                if (col.gameObject == chunks[i].gameObject)
                {
                    cont = false;
                }
            }
            if (cont)
            {
                chunks[index] = col.gameObject;
                index++;
            }
            if (col.gameObject.tag == "ChunkBlockMountain")
            {
                containsMountains = true;
            }
            if (col.gameObject.tag == "ChunkBlock")
            {
                containsNonMountains = true;
            }
        }

        if (col.gameObject.tag == "Building")
        {
            containsBuildings = true;
        }

        if (col.gameObject.tag == "Player")
        {
            containsPlayers = true;
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

        if (chunks[0] != null && chunks[1] != null && chunks[2] != null && chunks[3] != null && !equalized)
        {
            Debug.Log("Equalizing");
            GameObject c1 = chunks[0].gameObject;
            GameObject c2 = chunks[1].gameObject;
            GameObject c3 = chunks[2].gameObject;
            GameObject c4 = chunks[3].gameObject;
            bool cont = true;
            if (containsMountains && containsNonMountains)
            {
                cont = false;
                Debug.Log("You Cannot Build On Uneven Terrain");
            }
            else if (containsBuildings)
            {
                cont = false;
                Debug.Log("You Cannot Build On Top of Other Buildings");
            }
            else if (containsPlayers)
            {
                cont = false;
                Debug.Log("You Cannot Build On Top of Any Players");
            }
            for (int i = 0; i < 4; i++)
            {
                GameObject curr = chunks[i].gameObject;
                for (int j = 0; j < 4; j++)
                {
                    GameObject oCurr = chunks[j].gameObject;
                    if (Mathf.Abs(curr.transform.position.y - oCurr.transform.position.y) > 10)
                    {
                        cont = false;
                        Debug.Log("You Cannot Build On Uneven Terrain");
                    }
                }
            }
            if (cont)
            {
                float totalHeight = c1.transform.position.y + c2.transform.position.y + c3.transform.position.y + c4.transform.position.y;
                averageHeight = totalHeight / 4;
                Debug.Log("Average Height: " + averageHeight);
                Vector3 newPos1 = new Vector3(c1.transform.position.x, averageHeight, c1.transform.position.z);
                Vector3 newPos2 = new Vector3(c2.transform.position.x, averageHeight, c2.transform.position.z);
                Vector3 newPos3 = new Vector3(c3.transform.position.x, averageHeight, c3.transform.position.z);
                Vector3 newPos4 = new Vector3(c4.transform.position.x, averageHeight, c4.transform.position.z);
                chunks[0].gameObject.transform.position = newPos1;
                chunks[1].gameObject.transform.position = newPos2;
                chunks[2].gameObject.transform.position = newPos3;
                chunks[3].gameObject.transform.position = newPos4;
                equalized = true;
                if (!containsMountains)
                {
                    GameObject builtObj = Instantiate(toBuild, new Vector3(chunkX * 48 + 24, averageHeight + 24, chunkZ * 48 + 24), Quaternion.identity);
                    builtObj.GetComponent<Building>().setTeamOwner(teamOwner);
                    if (!is2x2)
                    {
                        Instantiate(sweepChild1x1, new Vector3(chunkX * 48, yPos, chunkZ * 48), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(sweepChild2x2, new Vector3(chunkX * 48 + 24, yPos, chunkZ * 48 + 24), Quaternion.identity);
                    }
                    timer = 3f;
                }
                else
                {
                    GameObject builtObj = Instantiate(toBuild, new Vector3(chunkX * 48 + 24, averageHeight + 48, chunkZ * 48 + 24), Quaternion.identity);
                    builtObj.GetComponent<Building>().setTeamOwner(teamOwner);
                    if (!is2x2)
                    {
                        Instantiate(sweepChild1x1, new Vector3(chunkX * 48, yPos, chunkZ * 48), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(sweepChild2x2, new Vector3(chunkX * 48 + 24, yPos, chunkZ * 48 + 24), Quaternion.identity);
                    }
                    timer = 3f;
                }
            }
            else
            {
                equalized = true;
                Destroy(this.gameObject);
            }
        }
    }

    public void setBuildObjParams(GameObject gO, float cX, float cZ, float yP, bool two, int tO)
    {
        toBuild = gO;
        chunkX = cX;
        chunkZ = cZ;
        yPos = yP;
        is2x2 = two;
        teamOwner = tO;
    }
}
