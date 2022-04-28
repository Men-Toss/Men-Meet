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
    public Button StartButton;
    public LoadingTextScript loadingTextScript;
    //네트워크 서버 연결
    public void Connect() => PhotonNetwork.ConnectUsingSettings();
    //Connect()콜백 함수
    public override void OnConnectedToMaster()
    {
        Statetext.text+="OnConnectedToMaster\n";
       PhotonNetwork.LocalPlayer.NickName = "DDE";
       ProgressBar.fillAmount=0.2f;
    }
    //네트워크 서버 연결 종료
    public void Disconnect() => PhotonNetwork.Disconnect();
    public override void OnDisconnected(DisconnectCause cause) => Statetext.text += "OnDisconnected\n";
    //로비 참가하기(대형 게임이 아닌 이랑 로비는 하나만 사용)
    public void JoinLobby() => PhotonNetwork.JoinLobby();
    public override void OnJoinedLobby() {
        Statetext.text += "OnJoinedLobby\n";
       ProgressBar.fillAmount=0.4f;
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
    } 
    //참가 실패시 콜백함수
    public override void OnJoinRoomFailed(short returnCode, string message) => Statetext.text +="OnJoinRoomFailed\n";
    //방 생성/참가하기(방이름이 있다면, 생성하고 아니면 참가) - 콜백 함수는 위와 동일
    //public void JoinOrCreateRoom() => PhotonNetwork.JoinOrCreateRoom(roomInput.text, new RoomOptions { MaxPlayers = 2 }, null);
    //방 랜덤 참가하기
    public void JoinRandomRoom() => PhotonNetwork.JoinRandomRoom();
    //콜백함수 - 방참가실패시
    public override void OnJoinRandomFailed(short returnCode, string message) => Statetext.text += "OnJoinRandomFailed\n";
    //방 떠나기
    public void LeaveRoom() => PhotonNetwork.LeaveRoom();

    void Start()=> StartCoroutine("CONNECT");
    IEnumerator CONNECT(){
        Connect();
        yield return new WaitForSeconds(3f);
        StartCoroutine("JOINLOBBY");
    }
    IEnumerator JOINLOBBY(){
        JoinLobby();
        yield return new WaitForSeconds(1f);
        StartCoroutine("CREATEROOM");
    }
        IEnumerator CREATEROOM(){
        CreateRoom();
        yield return new WaitForSeconds(1f);
        StartCoroutine("JOINROOM");
    }
        IEnumerator JOINROOM(){
        //JoinRoom();
        yield return new WaitForSeconds(1f);
        Statetext.text += PhotonNetwork.LocalPlayer.NickName+ "님, 준비가 완료되었습니다.\n";
        loadingTextScript.StopAni();
        MainStatetext.text="준비완료~!";
       ProgressBar.fillAmount=1f;
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
