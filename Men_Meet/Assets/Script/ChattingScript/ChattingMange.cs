using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class ChattingMange : MonoBehaviourPunCallbacks
{
    public Text[] ChatText = new Text[10];
    //public Text _Input;
    public PhotonView PV;
    public void SendMessage()
    {
        string sendMessage = "[" + PhotonNetwork.NickName + "] "+"안녕하세요";
        PV.RPC("ChattingRPC",RpcTarget.AllBuffered,sendMessage);      
    }

    [PunRPC]
    public void ChattingRPC(string msg)
    {
        bool isInput = false;
        for (int i = 0; i < ChatText.Length; i++)
            if (ChatText[i].text == "")
            {
                isInput = true;
                ChatText[i].text = msg;
                break;
            }
        if (!isInput) // 꽉차면 한칸씩 위로 올림
        {
            for (int i = 1; i < ChatText.Length; i++) ChatText[i - 1].text = ChatText[i].text;
            ChatText[ChatText.Length - 1].text = msg;
        }
    }
}
