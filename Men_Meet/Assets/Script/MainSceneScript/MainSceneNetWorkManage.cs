using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class MainSceneNetWorkManage : MonoBehaviourPunCallbacks
{
    public Text NowPlayerCountText;
    void Update() =>NowPlayerCountText.text= PhotonNetwork.CurrentRoom.PlayerCount.ToString();
}
