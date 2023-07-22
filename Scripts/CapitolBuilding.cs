using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapitolBuilding : Photon.MonoBehaviour
{
    public int health;
    public int maxHealth = 200;
    public GameObject controlPoint;

    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        if (health <= 0)
        {
            this.GetComponent<PhotonView>().RPC("capitolDestruct", PhotonTargets.AllBuffered);
        }
    }

    public void takeDamage(int dmg)
    {
        this.GetComponent<PhotonView>().RPC("takeDmgRPC", PhotonTargets.AllBuffered, dmg);
    }

    [PunRPC]
    public void takeDmgRPC(int dmg)
    {
        health -= dmg;
    }

    [PunRPC]
    public void capitolDestruct()
    {
        Destroy(this.gameObject);
    }
}
