using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class Test : MonoBehaviourPunCallbacks
{
    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster() =>
        PhotonNetwork.JoinOrCreateRoom("AAA", new RoomOptions { MaxPlayers = 5 }, null);
    

    
}
