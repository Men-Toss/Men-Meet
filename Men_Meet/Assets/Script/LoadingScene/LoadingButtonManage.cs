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
    public Button[] IntroDucebtn = new Button[4];
    //학교 프로그램 패널
    public GameObject ProgramPanel;
    //프로그램 소개 버튼 배열
    public Button[] Programbtn = new Button[5];
    //프로그램/학교소개 버튼 , 버튼 텍스트
    public Button Intro_Pro_btn;
    public Text Intro_Pro_text;
    //카메라 움직임 조절 변수
    public CameraMovement CM;
    //리스트 갱신을 위한 리스트 매니저
    public ListManage LM;
    
    
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
            CM.isCameraYes = true;
            ChatPanel.SetActive(false);
            chatIcon.gameObject.SetActive(true);
            isChatpanel=false;
        }
        else
        {
            CM.isCameraYes = false;
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
            IntroDucebtn[i].GetComponent<Image>().color=Color.white;

        IntroDucebtn[index].GetComponent<Image>().color = Color.cyan;
    }
    //학교 소개 패널 보이기 / 숨기기
    public void ClickIntrduceShow()=> IntroducePanel.SetActive(true);
    public void ClickIntroduceHide()
    {
        IntroducePanel.SetActive(false);
        CM.isCameraYes = true;
    }
    
    //프로그램 소개 패널 클릭 시 작동
    public void ClickProgramButton(int index)
    {
        for (int i = 0; i < 5; i++)
            Programbtn[i].GetComponent<Image>().color=Color.white;

        Programbtn[index].GetComponent<Image>().color = Color.yellow;

        LM.Programcmd = index + 1;
        LM.ProgramNowIndex = 1;
        LM.LoadProgramListData();
    }
    //프로그램 소개 패널 보이기 / 숨기기
    public void ClickProgramShow()=> ProgramPanel.SetActive(true);
    public void ClickProgramHide()
    {
        ProgramPanel.SetActive(false);
        CM.isCameraYes = true;
    }
    
    
    
    
    //콜라이더 시 메세지버튼 보이기/숨기기
    public void Intro_Pro_btnShow() => Intro_Pro_btn.gameObject.SetActive(true);
    public void Intro_Pro_btnHide() => Intro_Pro_btn.gameObject.SetActive(false);
    public void Intro_Pro_btnSetText(string msg) => Intro_Pro_text.text = msg;
    //소개,프로그램 버튼 클릭 시
    public void ClickIntroPro()
    {
        if (Intro_Pro_text.text.Equals("학과 소개"))
        {
            ClickIntrduceShow();
            ClickIntroduceButton(0);
            LM.loadIntroListData(1);
            CM.isCameraYes = false;
        }
        else if (Intro_Pro_text.text.Equals("부처 소개"))
        {
            ClickIntrduceShow();
            ClickIntroduceButton(1);
            LM.loadIntroListData(2);
            CM.isCameraYes = false;
        }
        else if (Intro_Pro_text.text.Equals("건물 소개"))
        {
            ClickIntrduceShow();
            ClickIntroduceButton(2);
            LM.loadIntroListData(3);
            CM.isCameraYes = false;
        }
        else if (Intro_Pro_text.text.Equals("동아리 소개"))
        {
            ClickIntrduceShow();
            ClickIntroduceButton(3);
            LM.loadIntroListData(4);
            CM.isCameraYes = false;
        }
        else if (Intro_Pro_text.text.Equals("교과 프로그램"))
        {
            ClickProgramShow();
            ClickProgramButton(0);
            CM.isCameraYes = false;
        }
        else if (Intro_Pro_text.text.Equals("비교과 프로그램"))
        {
            ClickProgramShow();
            ClickProgramButton(1);
            CM.isCameraYes = false;
        }
        else if (Intro_Pro_text.text.Equals("학과 프로그램"))
        {
            ClickProgramShow();
            ClickProgramButton(2);
            CM.isCameraYes = false;
        }
        else if (Intro_Pro_text.text.Equals("기타 프로그램"))
        {
            ClickProgramShow();
            ClickProgramButton(3);
            CM.isCameraYes = false;
        }
        else if (Intro_Pro_text.text.Equals("자주 묻는 질문"))
        {
            ClickProgramShow();
            ClickProgramButton(4);
            CM.isCameraYes = false;
        }
    }
}
