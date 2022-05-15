using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class ChatManage : MonoBehaviourPunCallbacks
{
    public Text[] ChatText = new Text[10];
    public Text UsetConnectStateText;
    public Text UserConnectCountText;
    
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        UsetConnectStateText.text = "<color=yellow>" + newPlayer.NickName + "님이 참가하셨습니다</color>";
        //ChatRPC("<color=yellow>" + newPlayer.NickName + "님이 참가하셨습니다</color>");
        UserConnectCountText.text = PhotonNetwork.CountOfPlayers.ToString()+"/"+"20";
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        UsetConnectStateText.text = "<color=yellow>" + otherPlayer.NickName + "님이 퇴장하셨습니다</color>";
       // ChatRPC("<color=yellow>" + otherPlayer.NickName + "님이 퇴장하셨습니다</color>");
        UserConnectCountText.text = PhotonNetwork.CountOfPlayers.ToString()+"/"+"20";
    }
    
        public void updateChat(string msg)
        {
            Debug.Log(msg);
        
            bool isInput = false;
            for (int i = 0; i < 10; i++)
                if (ChatText[i].text == "")
                {
                    isInput = true;
                    ChatText[i].text = msg;
                    break;
                }
            if (!isInput) // 꽉차면 한칸씩 위로 올림
            {
                for (int i = 1; i < 10; i++) ChatText[i - 1].text = ChatText[i].text;
                ChatText[9].text = msg;
            }
        
        }
}
