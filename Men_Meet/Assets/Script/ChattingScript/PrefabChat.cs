using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class PrefabChat : MonoBehaviour
{
    public PhotonView PV;
    public ChatManage _ChatManage;
    public InputField InputChatText;
    private void Start()
    {
        _ChatManage = GameObject.Find("ChatManager").GetComponent<ChatManage>();
        InputChatText=GameObject.Find("ChatInput").GetComponent<InputField>();
    }

    private void Update()
    {
        if (PV.IsMine)
        {
            if (Input.GetMouseButtonDown(1))
            {
                PV.RPC("chatRPC", RpcTarget.All, PhotonNetwork.NickName + " : "+InputChatText.text);
                InputChatText.text = "";
            }
        }
    }

    [PunRPC]
    public void chatRPC(string msg)
    {
        Debug.Log(msg);
        _ChatManage.updateChat(msg);
    }
}
