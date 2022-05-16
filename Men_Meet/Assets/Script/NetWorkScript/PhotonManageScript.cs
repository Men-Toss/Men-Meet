using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class PhotonManageScript : MonoBehaviourPunCallbacks
{
    public Text MainStatetext;
    public Text Statetext;
    public Image ProgressBar;
    public LoadingTextScript loadingTextScript;
    public Text[] ChatText = new Text[10];
    public Text ChatInput;
    public Button StartButton;
    public GameObject ChatPanel;
    public Text nowPlayerText;
    
    //네트워크 서버 연결
    public void Connect() => PhotonNetwork.ConnectUsingSettings();
    //Connect()콜백 함수
    public override void OnConnectedToMaster()
    {
        Statetext.text+="OnConnectedToMaster\n";
        PhotonNetwork.LocalPlayer.NickName =
            GameObject.Find("UserManager").GetComponent<UserStateScript>().UserNickName;
       ProgressBar.fillAmount=0.2f;
       //로비 참가하기(대형 게임이 아닌 이랑 로비는 하나만 사용)
       PhotonNetwork.JoinLobby();
    }
    //네트워크 서버 연결 종료
    public void Disconnect() => PhotonNetwork.Disconnect();
    public override void OnDisconnected(DisconnectCause cause) => Statetext.text += "OnDisconnected\n";
    public override void OnJoinedLobby() {
        Statetext.text += "OnJoinedLobby\n";
       ProgressBar.fillAmount=0.4f;
       JoinOrCreateRoom();
    } 
    //방만들기 방이름, 최대인원을 설정
    public void CreateRoom() => PhotonNetwork.CreateRoom("ROOT", new RoomOptions { MaxPlayers =10 });
    //콜백함수 - 생성 완료시
    public override void OnCreatedRoom() {
        Statetext.text += "OnCreatedRoom\n";
       ProgressBar.fillAmount=0.4f;
    } 
    //콜백함수 - 생성 실패시
    public override void OnCreateRoomFailed(short returnCode, string message) => Statetext.text += "OnCreateRoomFailed\n";
    //방참가하기
    public void JoinRoom() => PhotonNetwork.JoinRoom("ROOT");
    //참가 완료시 콜백함수
    public override void OnJoinedRoom() {
      Statetext.text += "OnJoinedRoom\n"; 
       ProgressBar.fillAmount=0.8f;
       
       Statetext.text += PhotonNetwork.LocalPlayer.NickName+ "님, 준비가 완료되었습니다.\n";
       loadingTextScript.StopAni();
       MainStatetext.text="준비완료~!";
       ProgressBar.fillAmount=1f;

       string[] charInstan=new string[4];
       
       charInstan[0] = GameObject.Find("UserManager").GetComponent<UserStateScript>().userCharCode;
       charInstan[1] = GameObject.Find("UserManager").GetComponent<UserStateScript>().userSkin.ToString();
       charInstan[2] = GameObject.Find("UserManager").GetComponent<UserStateScript>().userCloth.ToString();
       charInstan[3] = GameObject.Find("UserManager").GetComponent<UserStateScript>().UserNickName;
       PhotonNetwork.Instantiate("Player",new Vector3(1f,-0.25f,0),Quaternion.identity,0,charInstan);
       
       
       ChatInput.text = "";
       for (int i = 0; i < ChatText.Length; i++) ChatText[i].text = "";
       
       StartButton.gameObject.SetActive(true);
       //ChatPanel.SetActive(false);
    } 
    //참가 실패시 콜백함수
    public override void OnJoinRoomFailed(short returnCode, string message) => Statetext.text +="OnJoinRoomFailed\n";
    //방 생성/참가하기(방이름이 있다면, 생성하고 아니면 참가) - 콜백 함수는 위와 동일
    public void JoinOrCreateRoom() => PhotonNetwork.JoinOrCreateRoom("ROOT", new RoomOptions { MaxPlayers = 10 }, null);
    //방 랜덤 참가하기
    public void JoinRandomRoom() => PhotonNetwork.JoinRandomRoom();
    //콜백함수 - 방참가실패시
    public override void OnJoinRandomFailed(short returnCode, string message) => Statetext.text += "OnJoinRandomFailed\n";
    //방 떠나기
    public void LeaveRoom() => PhotonNetwork.LeaveRoom();

    void Start() {
        StartButton.gameObject.SetActive(false);
        Connect();
    }

    private void Update()
    {
        nowPlayerText.text = PhotonNetwork.CountOfPlayers.ToString()+" / 50";
    }

    void Info()
    {
        if (PhotonNetwork.InRoom)
        {
            print("현재 방 이름 : " + PhotonNetwork.CurrentRoom.Name);
            print("현재 방 인원수 : " + PhotonNetwork.CurrentRoom.PlayerCount);
            print("현재 방 최대인원수 : " + PhotonNetwork.CurrentRoom.MaxPlayers);

            string playerStr = "방에 있는 플레이어 목록 : ";
            for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++) playerStr += PhotonNetwork.PlayerList[i].NickName + ", ";
            print(playerStr);
        }
        else
        {
            print("접속한 인원 수 : " + PhotonNetwork.CountOfPlayers);
            print("방 개수 : " + PhotonNetwork.CountOfRooms);
            print("모든 방에 있는 인원 수 : " + PhotonNetwork.CountOfPlayersInRooms);
            print("로비에 있는지? : " + PhotonNetwork.InLobby);
            print("연결됐는지? : " + PhotonNetwork.IsConnected);
        }
    }
}
