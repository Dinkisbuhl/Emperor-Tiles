using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceHolder : MonoBehaviour
{
    public ArrayList resources = new ArrayList();

    public void setResources(ArrayList arr)
    {
        resources = arr;
        Debug.Log("setting resources");
    }

    public void RemoveResourceSelf(int index)
    {
        Debug.Log("Now removing: " + index);
        GameObject found = (GameObject)resources[index-1];
        resources.Remove(found);
        Destroy(found);
    }

    public int getSize()
    {
        Debug.Log("Getting Size");
        return resources.Count;
    }

    /*
    public void RemoveResourceSelf(int index)
    {
        if (photonView.isMine)
        {
            this.GetComponent<PhotonView>().RPC("ExecuteRemoveResource", PhotonTargets.AllBuffered, index);
        }
    }

    [PunRPC]
    public void ExecuteRemoveResource(int index)
    {
        GameObject found = (GameObject)resources[index];
        resources.Remove(found);
        Destroy(found);
    }
    */
}
