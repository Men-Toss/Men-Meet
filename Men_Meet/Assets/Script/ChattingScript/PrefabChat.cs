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
            string chatstring = "<color=red>"+PhotonNetwork.NickName + "</color> : " + InputChatText.text;
            if (Input.GetKeyDown(KeyCode.Return) && !InputChatText.text.Equals(""))
            {
                PV.RPC("chatRPC", RpcTarget.All, chatstring);
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
