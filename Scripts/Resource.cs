using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public int breakTime = 5;
    public int material = 0;
    public int integrity = 5;
    public int arrListPlace;

    void Start()
    {
        integrity = breakTime;
    }
    
    void Update()
    {
        
    }

    public void breakTick()
    {
        integrity--;
    }

    public int getIntegrity()
    {
        return integrity;
    }

    public int getMaterial()
    {
        return material;
    }

    public void setArrListPlace(int place)
    {
        arrListPlace = place;
    }

    public int getArrListPlace()
    {
        return arrListPlace;
    }
}
