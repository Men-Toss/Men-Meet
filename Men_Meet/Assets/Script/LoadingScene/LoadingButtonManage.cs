using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using Photon.Voice.Unity;

public class LoadingButtonManage : MonoBehaviourPunCallbacks
{
    public GameObject MAIN_CAMERA;
    public GameObject SUB_CAMERA;
    public GameObject loadingPanel;
    public GameObject SettingPanel;
    public GameObject msgPanel;
    public GameObject ChatPanel;
    public GameObject timerPanel;
    public GameObject paintPanel;
    public GameObject soundPanel;
    public Recorder myRecorder;
    public Text msgText;
    public bool isChatpanel=false;
    public Button chatIcon;
    //마이크 음소거, 음소거 해제 상태
    public bool ismicro = false;
    //마이크 음소거, 음소거 해제 버튼
    public Button microPhonebtn;
    //음소거,음소거 해제 이미지
    public Sprite[] microPhoneImage = new Sprite[2];
    //학교 소개 패널
    public GameObject IntroducePanel;
    //학교 소개 버튼 배열
    public Button[] IntroDucebtn = new Button[4];
    //학교 프로그램 패널
    public GameObject ProgramPanel;
    //프로그램 소개 버튼 배열
    public Button[] Programbtn = new Button[5];
    //프로그램 프리팹 클릭시 나오는 패널
    public GameObject ProgramDetailPanel;
    public Text ProgramDetailTitleText;
    public Text ProgramDetailIntroduceText;
    public Text ProgramDetailTimeText;
    //프로그램/학교소개 버튼 , 버튼 텍스트
    public Button Intro_Pro_btn;
    public Text Intro_Pro_text;
    //카메라 움직임 조절 변수
    public CameraMovement CM;
    //리스트 갱신을 위한 리스트 매니저
    public ListManage LM;

    public void Start()
    {
        OnRecord();
    }

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
    
    //프로그램 소개 프리팹 클릭시
    public void ClickProgramPrefab(int C1, int C2)
    {
        ProgramDetailPanel.SetActive(true);
        switch (C1)
        {
            case 1:
                ProgramDetailTitleText.text = LM.Program1[0][C2];
                ProgramDetailIntroduceText.text = LM.Program1[1][C2];
                ProgramDetailTimeText.text = 
                    "일정 : "+LM.Program1[2][C2]+" ~ "+LM.Program1[3][C2];
                break;
            case 2:
                ProgramDetailTitleText.text = LM.Program2[0][C2];
                ProgramDetailIntroduceText.text = LM.Program2[1][C2];
                ProgramDetailTimeText.text = 
                    "일정 : "+LM.Program2[2][C2]+" ~ " +LM.Program2[3][C2];
                break;
            case 3:
                ProgramDetailTitleText.text = LM.Program3[0][C2];
                ProgramDetailIntroduceText.text = LM.Program3[1][C2];
                ProgramDetailTimeText.text = 
                    "일정 : "+LM.Program3[2][C2]+" ~ " +LM.Program3[3][C2];
                break;
            case 4:
                ProgramDetailTitleText.text = LM.Program4[0][C2];
                ProgramDetailIntroduceText.text = LM.Program4[1][C2];
                ProgramDetailTimeText.text = 
                    "일정 : "+LM.Program4[2][C2]+" ~ " +LM.Program4[3][C2];
                break;
            case 5:
                ProgramDetailTitleText.text = LM.Program5[0][C2];
                ProgramDetailIntroduceText.text = LM.Program5[1][C2];
                ProgramDetailTimeText.text = 
                    "일정 : "+LM.Program5[2][C2]+" ~ " +LM.Program5[3][C2];
                break;
        }
    }
    
    //프로그램 소개 상세 패널 숨기기
    public void ClickProgramDetailHide()
    {
        ProgramDetailPanel.SetActive(false);
    }
    
    //채팅 보내기 버튼 - 구현 예정
    public void SendChat()
    {
       
    }
    //타이머 패널 보이기
    public void ShowTimer(){
        timerPanel.SetActive(true);
    }
    //타이머 패널 숨기기
    public void HideTimer(){
        timerPanel.SetActive(false);
    }
    //사운드 패널 보이기
    public void ShowSound(){
        soundPanel.SetActive(true);
    }
    //사운드 패널 숨기기
    public void HideSound(){
        soundPanel.SetActive(false);
    }
    //페인트 카메라 보이기
    public void ShowPaint(){
        paintPanel.SetActive(true);
        MAIN_CAMERA.SetActive(false);
        SUB_CAMERA.SetActive(true);
    }
    //페인트 카메라 숨기기
    public void HidePaint(){
        paintPanel.SetActive(false);
        MAIN_CAMERA.SetActive(true);
        SUB_CAMERA.SetActive(false);
    }
    //내마이크 음소거
    public void OffRecord()
    {
        microPhonebtn.image.sprite = microPhoneImage[1];
        myRecorder.IsRecording = false;
    }
    //내 마이크 음소거 해제
    public void OnRecord()
    {
        microPhonebtn.image.sprite = microPhoneImage[0];
        myRecorder.IsRecording = true;
    }
    //마이크 버튼 클릭 시
    public void ClickMicroPhone()
    {
        if (!ismicro)
        {
            OnRecord();
            ismicro = true;
        }
        else
        {
            ismicro = false;
            OffRecord();
        }
    }
}
