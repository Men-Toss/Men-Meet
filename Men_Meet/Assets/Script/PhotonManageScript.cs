using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonManageScript : MonoBehaviourPunCallbacks
{/*

    //��Ʈ��ũ ���� ����
    public void Connect() => PhotonNetwork.ConnectUsingSettings();
    //Connect()�ݹ� �Լ�
    public override void OnConnectedToMaster()
    {
        print("�������ӿϷ�");
       //PhotonNetwork.LocalPlayer.NickName = NickNameInput.text;
    }
    //��Ʈ��ũ ���� ���� ����
    public void Disconnect() => PhotonNetwork.Disconnect();
    public override void OnDisconnected(DisconnectCause cause) => print("�������");
    //�κ� �����ϱ�(���� ������ �ƴ� �̶� �κ�� �ϳ��� ���)
    public void JoinLobby() => PhotonNetwork.JoinLobby();
    public override void OnJoinedLobby() => print("�κ����ӿϷ�");
    //�游��� ���̸�, �ִ��ο��� ����
    public void CreateRoom() => PhotonNetwork.CreateRoom(roomInput.text, new RoomOptions { MaxPlayers = 2 });
    //�ݹ��Լ� - ���� �Ϸ��
    public override void OnCreatedRoom() => print("�游���Ϸ�");
    //�ݹ��Լ� - ���� ���н�
    public override void OnCreateRoomFailed(short returnCode, string message) => print("�游������");
    //�������ϱ�
    public void JoinRoom() => PhotonNetwork.JoinRoom(roomInput.text);
    //���� �Ϸ�� �ݹ��Լ�
    public override void OnJoinedRoom() => print("�������Ϸ�");
    //���� ���н� �ݹ��Լ�
    public override void OnJoinRoomFailed(short returnCode, string message) => print("����������");
    //�� ����/�����ϱ�(���̸��� �ִٸ�, �����ϰ� �ƴϸ� ����) - �ݹ� �Լ��� ���� ����
    public void JoinOrCreateRoom() => PhotonNetwork.JoinOrCreateRoom(roomInput.text, new RoomOptions { MaxPlayers = 2 }, null);
    //�� ���� �����ϱ�
    public void JoinRandomRoom() => PhotonNetwork.JoinRandomRoom();
    //�ݹ��Լ� - ���������н�
    public override void OnJoinRandomFailed(short returnCode, string message) => print("�淣����������");
    //�� ������
    public void LeaveRoom() => PhotonNetwork.LeaveRoom();

    */
}
