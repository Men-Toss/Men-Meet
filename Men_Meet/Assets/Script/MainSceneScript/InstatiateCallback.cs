using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class InstatiateCallback : IPunInstantiateMagicCallback
{
    public GameObject _GameObject;
   public void OnPhotonInstantiate(PhotonMessageInfo info)
    {
        Debug.Log("OnPhotonInstantiate");
    }
}
