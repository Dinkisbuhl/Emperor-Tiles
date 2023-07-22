using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBuilding : Photon.MonoBehaviour
{
    public float posX;
    public float posY;
    public float posZ;
    public float timer;
    public float xChunk;
    public float zChunk;
    public float buildPosY;
    public bool buildMode;

    public Text PositionDisplay;
    public Text Confirm;
    public GameObject chunkSweeper;
    public GameObject chunkSweeper2x2;
    public GameObject BuildOutline1x1;
    public GameObject BuildOutline2x2;
    public PhotonView photonView;

    public GameObject Camp;
    public GameObject CapitolBuilding1;
    public GameObject CaptiolBlue;
    public GameObject CaptiolRed;
    public GameObject CaptiolGreen;
    public GameObject CaptiolOrange;

    public int playerTeam = -1;

    void Start()
    {
        if (photonView.isMine)
        {
            posX = gameObject.transform.position.x;
            posY = gameObject.transform.position.y;
            posZ = gameObject.transform.position.z;
            timer = 0.5f;
            Confirm.enabled = false;
            buildMode = false;
            buildPosY = posY - 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.isMine)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            if (timer <= 0)
            {
                posX = gameObject.transform.position.x;
                posY = gameObject.transform.position.y - 0.99f;
                posZ = gameObject.transform.position.z;
                timer = 0.5f;
            }

            PositionDisplay.text = "X: " + posX + " Y: " + posY + " Z: " + posZ;

            if (Input.GetKeyDown(KeyCode.B) && buildMode == false)
            {
                if (posX > 24 && posZ > 24 && posX < 1560 && posZ < 1560)
                {
                    if (posY > 0)
                    {
                        bool noCap = true;
                        GameObject[] buildings = GameObject.FindGameObjectsWithTag("Building");
                        for (int i = 0; i < buildings.Length; i++)
                        {
                            GameObject curr = buildings[i];
                            var capScript = curr.GetComponent<Building>();
                            if (capScript)
                            {
                                int teamOwner = buildings[i].GetComponent<Building>().getTeamOwner();
                                if (teamOwner == playerTeam)
                                {
                                    noCap = false;
                                }
                            }
                        }
                        if (noCap)
                        {
                            xChunk = Mathf.Floor((posX + 24) / 48);
                            zChunk = Mathf.Floor((posZ + 24) / 48);
                            buildPosY = posY;

                            Instantiate(BuildOutline2x2, new Vector3(xChunk * 48 + 24, posY, zChunk * 48 + 24), Quaternion.identity);
                            Confirm.enabled = true;
                            buildMode = true;
                        }
                        else
                        {
                            Debug.Log("Your Team Already Has a Capitol");
                        }
                    }
                    else
                    {
                        Debug.Log("Must Build Above Sea Level");
                    }
                }
                else
                {
                    Debug.Log("Must Include One Chunk of Space On All Sides");
                }
            }

            if (buildMode == true)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    Confirm.enabled = false;
                    buildMode = false;
                    GameObject instanceBuildOutline = GameObject.FindGameObjectWithTag("BuildOutline");
                    instanceBuildOutline.GetComponent<BuildOutline>().destroyBuildOutline();
                    this.GetComponent<PhotonView>().RPC("buildCapitol", PhotonTargets.AllBuffered, xChunk, zChunk, buildPosY);
                }
                else if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Confirm.enabled = false;
                    buildMode = false;
                    GameObject instanceBuildOutline = GameObject.FindGameObjectWithTag("BuildOutline");
                    instanceBuildOutline.GetComponent<BuildOutline>().destroyBuildOutline();
                }
            }
        }
    }

    [PunRPC]
    public void buildCamp(float chunkX, float chunkZ, float yPos)
    {
        Instantiate(chunkSweeper, new Vector3(chunkX * 48, yPos, chunkZ * 48), Quaternion.identity);
        Instantiate(Camp, new Vector3(chunkX * 48, yPos, chunkZ * 48), Quaternion.identity);
    }

    [PunRPC]
    public void buildCapitol(float chunkX, float chunkZ, float yPos)
    {
        Instantiate(chunkSweeper2x2, new Vector3(chunkX * 48 + 24, yPos, chunkZ * 48 + 24), Quaternion.identity);
        GameObject cSInstance = GameObject.FindGameObjectWithTag("ChunkSweeper");
        if (cSInstance)
        {
            if (playerTeam == 0)
            {
                cSInstance.GetComponent<SweepChunkObj>().setBuildObjParams(CaptiolBlue, chunkX, chunkZ, yPos, true, playerTeam);
            }
            else if (playerTeam == 1)
            {
                cSInstance.GetComponent<SweepChunkObj>().setBuildObjParams(CaptiolRed, chunkX, chunkZ, yPos, true, playerTeam);
            }
            else if (playerTeam == 2)
            {
                cSInstance.GetComponent<SweepChunkObj>().setBuildObjParams(CaptiolGreen, chunkX, chunkZ, yPos, true, playerTeam);
            }
            else if (playerTeam == 3)
            {
                cSInstance.GetComponent<SweepChunkObj>().setBuildObjParams(CaptiolOrange, chunkX, chunkZ, yPos, true, playerTeam);
            }
        }
    }
}
