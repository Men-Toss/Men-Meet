using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class MainSceneChactorManage : MonoBehaviour
{
    public MainCharLoad MCL;
    void Awake()
    {
        PhotonNetwork.Instantiate("Player",new Vector3(-323f,70f,45f),Quaternion.identity);
    }
}
