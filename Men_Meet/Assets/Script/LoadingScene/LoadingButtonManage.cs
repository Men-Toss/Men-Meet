using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class LoadingButtonManage : MonoBehaviourPunCallbacks
{
    public GameObject loadingPanel;
    public GameObject SettingPanel;
    public GameObject msgPanel;
    public GameObject ChatPanel;
    public Text msgText;
    public bool isChatpanel=false;
    public Button chatIcon;
    //학교 소개 패널
    public GameObject IntroducePanel;
    //학교 소개 버튼 배열
    public Button[] IntroDuce = new Button[4];

    //메타버스 월드 입장
    public void ClickStart()
    {   
        loadingPanel.SetActive(false);
        
        ChatPanel.SetActive(false);
        chatIcon.gameObject.SetActive(true);
        isChatpanel=false;
    }
    //종료버튼 클릭 시
    public void ClickExit()
    {
        msgPanel.SetActive(true);
        msgText.text = "종료중.....";
        PhotonNetwork.Disconnect();
    }
    //포톤네트워크 콜백함수 - 연결 종료 시
    public override void  OnDisconnected(DisconnectCause cause)
    {
        msgPanel.SetActive(false);
        msgText.text = "";
        Application.Quit();
    }
    //설정버튼 클릭 시
    public void ClickSetting()
    {
        SettingPanel.SetActive(true);
    }
    //설정패널 종료 시
    public void ClickSettingExit()
    {
        SettingPanel.SetActive(false);
    }
    //채팅패널 보이기
    public void ClickChat()
    {
        if (isChatpanel)
        {
            ChatPanel.SetActive(false);
            chatIcon.gameObject.SetActive(true);
            isChatpanel=false;
        }
        else
        {
            ChatPanel.SetActive(true);
            chatIcon.gameObject.SetActive(false);
            isChatpanel=true;
        }
    }
    //마이크 음소거 / 음소거 해제
    public void ClickMicroPhone()
    {
        
    }
    //전체 볼륨 조정 / 0,1,2,3
    public void ClickVolume()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
            ClickChat();
    }
    
    
    //학교 소개 패널 클릭 시 작동
    public void ClickIntroduceButton(int index)
    {
        for (int i = 0; i < 4; i++)
            IntroDuce[i].GetComponent<Image>().color=Color.white;

        IntroDuce[index].GetComponent<Image>().color = Color.cyan;
    }
    
    //
}
