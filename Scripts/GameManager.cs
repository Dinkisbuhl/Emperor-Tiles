using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject PlayerPrefabBlue;
    public GameObject PlayerPrefabRed;
    public GameObject PlayerPrefabGreen;
    public GameObject PlayerPrefabOrange;
    public GameObject GameCanvas;
    public GameObject SceneCamera;
    public Text PingText;
    public GameObject disconnectUI;
    private bool Off = false;
    private bool OffTwo = false;
    private bool OffThree = false;
    private bool spawnedIn = false;

    public GameObject PlayerFeed;
    public GameObject FeedGrid;

    [HideInInspector]public GameObject LocalPlayer;
    public Text RespawnTimerText;
    public GameObject RespawnMenu;
    private float TimerAmount = 5f;
    private bool RunSpawnTimer = false;
    private float loadTimer = 5f;
    private bool loadOnce = false;
    public float randomValue1 = 816f;
    public float randomValue2 = 816f;

    private void Awake()
    {
        Instance = this;
        GameCanvas.SetActive(true);
    }

    public void Start()
    {
        //PhotonNetwork.isMessageQueueRunning = false;
        //PhotonNetwork.BackgroundTimeout = 200000;
        //Debug.Log(PhotonNetwork.BackgroundTimeout);
        //Debug.Log(PhotonNetwork.isMessageQueueRunning);
        Cursor.lockState = CursorLockMode.None;
        randomValue1 = Random.Range(811f, 821f);
        randomValue2 = Random.Range(811f, 821f);
    }

    public void Update()
    {
        /*
        if (loadTimer > 0)
        {
            loadTimer -= Time.deltaTime;
        }
        if (loadTimer <= 0 && !loadOnce)
        {
            PhotonNetwork.isMessageQueueRunning = true;
            Debug.Log(PhotonNetwork.isMessageQueueRunning);
            loadOnce = true;
        }
        */
        CheckInput();
        PingText.text = "Ping: " + PhotonNetwork.GetPing();

        if (RunSpawnTimer)
        {
            StartRespawn();
        }
    }

    public void EnableRespawn()
    {
        TimerAmount = 5f;
        RunSpawnTimer = true;
        RespawnMenu.SetActive(true);
    }

    private void StartRespawn()
    {
        TimerAmount -= Time.deltaTime;
        RespawnTimerText.text = "Respawning In " + TimerAmount.ToString("F0");

        if (TimerAmount <= 0)
        {
            LocalPlayer.GetComponent<PhotonView>().RPC("Respawn", PhotonTargets.AllBuffered);
            //LocalPlayer.GetComponent<Health>().EnableInput();
            RespawnLocation();
            RespawnMenu.SetActive(false);
            RunSpawnTimer = false;
        }
    }

    public void RespawnLocation()
    {
        float rValue1 = Random.Range(-5f, 5f);
        float rValue2 = Random.Range(-5f, 5f);
        LocalPlayer.transform.localPosition = new Vector3(rValue1, 100, rValue2);
    }

    private void CheckInput()
    {
        if (spawnedIn)
        {
            if (Off && Input.GetKeyDown(KeyCode.Escape))
            {
                disconnectUI.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Off = false;
            }
            else if (!Off && Input.GetKeyDown(KeyCode.Escape))
            {
                disconnectUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Off = true;
            }

            if (OffTwo && Input.GetKeyDown(KeyCode.L))
            {
                Cursor.lockState = CursorLockMode.Locked;
                OffTwo = false;
            }
            else if (!OffTwo && Input.GetKeyDown(KeyCode.L))
            {
                Cursor.lockState = CursorLockMode.None;
                OffTwo = true;
            }
        }
    }

    public void SetSpawnMethod()
    {
        if (!OffThree)
        {
            randomValue1 = Random.Range(0f, 1632f);
            randomValue2 = Random.Range(0f, 1632f);
            OffThree = true;
        }
        else
        {
            randomValue1 = Random.Range(811f, 821f);
            randomValue2 = Random.Range(811f, 821f);
            OffThree = false;
        }
    }

    public void SpawnPlayerBlue()
    {
        PhotonNetwork.Instantiate(PlayerPrefabBlue.name, new Vector3(randomValue1, 115, randomValue2), Quaternion.identity, 0);
        GameCanvas.SetActive(false);
        SceneCamera.SetActive(false);
        spawnedIn = true;
    }

    public void SpawnPlayerRed()
    {
        PhotonNetwork.Instantiate(PlayerPrefabRed.name, new Vector3(randomValue1, 115, randomValue2), Quaternion.identity, 0);
        GameCanvas.SetActive(false);
        SceneCamera.SetActive(false);
        spawnedIn = true;
    }

    public void SpawnPlayerGreen()
    {
        PhotonNetwork.Instantiate(PlayerPrefabGreen.name, new Vector3(randomValue1, 115, randomValue2), Quaternion.identity, 0);
        GameCanvas.SetActive(false);
        SceneCamera.SetActive(false);
        spawnedIn = true;
    }

    public void SpawnPlayerOrange()
    {
        PhotonNetwork.Instantiate(PlayerPrefabOrange.name, new Vector3(randomValue1, 115, randomValue2), Quaternion.identity, 0);
        GameCanvas.SetActive(false);
        SceneCamera.SetActive(false);
        spawnedIn = true;
    }

    public void JoinTeam(int team)
    {
        if (PhotonNetwork.player.CustomProperties.ContainsKey("Team"))
        {
            PhotonNetwork.player.CustomProperties["Team"] = team;
        }
        else
        {
            ExitGames.Client.Photon.Hashtable playerProps = new ExitGames.Client.Photon.Hashtable
            {
                { "Team", team }
            };
            PhotonNetwork.SetPlayerCustomProperties(playerProps);
        }
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.LoadLevel("Menu");
    }

    public void toggleFullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

    private void OnPhotonPlayerConnected(PhotonPlayer player)
    {
        GameObject obj = Instantiate(PlayerFeed, new Vector2(0, 0), Quaternion.identity);
        obj.transform.SetParent(FeedGrid.transform, false);
        obj.GetComponent<Text>().text = player.name + " joined the game";
        obj.GetComponent<Text>().color = Color.green;
    }

    private void OnPhotonPlayerDisconnected(PhotonPlayer player)
    {
        GameObject obj = Instantiate(PlayerFeed, new Vector2(0, 0), Quaternion.identity);
        obj.transform.SetParent(FeedGrid.transform, false);
        obj.GetComponent<Text>().text = player.name + " left the game";
        obj.GetComponent<Text>().color = Color.red;
    }
}
