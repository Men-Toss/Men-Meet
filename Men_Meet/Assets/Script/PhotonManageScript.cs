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
    //��Ʈ��ũ ���� ����
    public void Connect() => PhotonNetwork.ConnectUsingSettings();
    //Connect()�ݹ� �Լ�
    public override void OnConnectedToMaster()
    {
        Statetext.text+="�������ӿϷ�\n";
       PhotonNetwork.LocalPlayer.NickName = "DDE";
    }
    //��Ʈ��ũ ���� ���� ����
    public void Disconnect() => PhotonNetwork.Disconnect();
    public override void OnDisconnected(DisconnectCause cause) => Statetext.text = "���� ����";
    //�κ� �����ϱ�(���� ������ �ƴ� �̶� �κ�� �ϳ��� ���)
    public void JoinLobby() => PhotonNetwork.JoinLobby();
    public override void OnJoinedLobby() => Statetext.text += "�κ����ӿϷ�";
    //�游��� ���̸�, �ִ��ο��� ����
    public void CreateRoom() => PhotonNetwork.CreateRoom("ROOT", new RoomOptions { MaxPlayers =10 });
    //�ݹ��Լ� - ���� �Ϸ��
    public override void OnCreatedRoom() => Statetext.text += "�游���Ϸ�";
    //�ݹ��Լ� - ���� ���н�
    public override void OnCreateRoomFailed(short returnCode, string message) => Statetext.text = "�游������";
    //�������ϱ�
    public void JoinRoom() => PhotonNetwork.JoinRoom("ROOT");
    //���� �Ϸ�� �ݹ��Լ�
    public override void OnJoinedRoom() => Statetext.text += "�������Ϸ�";
    //���� ���н� �ݹ��Լ�
    public override void OnJoinRoomFailed(short returnCode, string message) => Statetext.text ="����������";
    //�� ����/�����ϱ�(���̸��� �ִٸ�, �����ϰ� �ƴϸ� ����) - �ݹ� �Լ��� ���� ����
    //public void JoinOrCreateRoom() => PhotonNetwork.JoinOrCreateRoom(roomInput.text, new RoomOptions { MaxPlayers = 2 }, null);
    //�� ���� �����ϱ�
    public void JoinRandomRoom() => PhotonNetwork.JoinRandomRoom();
    //�ݹ��Լ� - ���������н�
    public override void OnJoinRandomFailed(short returnCode, string message) => Statetext.text = "�淣����������";
    //�� ������
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
