using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class PhotonManageScript : MonoBehaviourPunCallbacks
{
    /*
    [SerializeField] Text Statetext;
    //네트워크 서버 연결
    public void Connect() => PhotonNetwork.ConnectUsingSettings();
    //Connect()콜백 함수
    public override void OnConnectedToMaster()
    {
        Statetext.text+="서버접속완료\n";
       PhotonNetwork.LocalPlayer.NickName = "DDE";
    }
    //네트워크 서버 연결 종료
    public void Disconnect() => PhotonNetwork.Disconnect();
    public override void OnDisconnected(DisconnectCause cause) => Statetext.text = "연결 끊김";
    //로비 참가하기(대형 게임이 아닌 이랑 로비는 하나만 사용)
    public void JoinLobby() => PhotonNetwork.JoinLobby();
    public override void OnJoinedLobby() => Statetext.text += "로비접속완료";
    //방만들기 방이름, 최대인원을 설정
    public void CreateRoom() => PhotonNetwork.CreateRoom("ROOT", new RoomOptions { MaxPlayers =10 });
    //콜백함수 - 생성 완료시
    public override void OnCreatedRoom() => Statetext.text += "방만들기완료";
    //콜백함수 - 생성 실패시
    public override void OnCreateRoomFailed(short returnCode, string message) => Statetext.text = "방만들기실패";
    //방참가하기
    public void JoinRoom() => PhotonNetwork.JoinRoom("ROOT");
    //참가 완료시 콜백함수
    public override void OnJoinedRoom() => Statetext.text += "방참가완료";
    //참가 실패시 콜백함수
    public override void OnJoinRoomFailed(short returnCode, string message) => Statetext.text ="방참가실패";
    //방 생성/참가하기(방이름이 있다면, 생성하고 아니면 참가) - 콜백 함수는 위와 동일
    //public void JoinOrCreateRoom() => PhotonNetwork.JoinOrCreateRoom(roomInput.text, new RoomOptions { MaxPlayers = 2 }, null);
    //방 랜덤 참가하기
    public void JoinRandomRoom() => PhotonNetwork.JoinRandomRoom();
    //콜백함수 - 방참가실패시
    public override void OnJoinRandomFailed(short returnCode, string message) => Statetext.text = "방랜덤참가실패";
    //방 떠나기
    public void LeaveRoom() => PhotonNetwork.LeaveRoom();

    void Start()
    {
        Statetext = "";
        Connect();
        JoinLobby();
        CreateRoom();
        JoinRoom();
        CreateRoom();
    }
    void StartLoad()
    {
        Statetext = "";
        Connect();
        JoinLobby();
        JoinRoom();
    }
    */
}
