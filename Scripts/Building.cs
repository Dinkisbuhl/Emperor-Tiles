using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public int teamOwner = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setTeamOwner(int tO)
    {
        teamOwner = tO;
    }

    public int getTeamOwner()
    {
        return teamOwner;
    }
}
