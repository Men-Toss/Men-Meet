using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class MainSceneChactorManage : MonoBehaviour
{
    //사용자 게임 오브젝트
    public GameObject userCharactor;
    private UserStateScript _stateScript;
    //메테리얼 배열
    public Material[] charTexture = new Material[18];
    //현재 선택인덱스  
    public int selectedChar = 0;
    //카메라가 보는 오브젝트 설정
    public CameraMovement CM;
    public InstatiateCallback _callback;
    void Awake()
    {
       // _stateScript = GameObject.Find("UserManager").GetComponent<UserStateScript>();
      //  loadCharactor(_stateScript.userCharCode,_stateScript.userSkin,_stateScript.userCloth);
        PhotonNetwork.Instantiate("Player",new Vector3(-323f,70f,45f),Quaternion.identity);
    }
    
    //메타버스 월드 처음 입장 시 캐릭터 정보 
    public void loadCharactor(string charCode,int skin,int cloth)
    {
        for (int i = 0; i <= 36; i++)
        {
            userCharactor.transform.GetChild(i).gameObject.SetActive(false);
        } 
        if (charCode[0].Equals('M'))
        {
            switch (int.Parse(charCode.Substring(1)))
            {
                case 0:
                    userCharactor.transform.GetChild(0).gameObject.SetActive(true);
                    selectedChar = 0;break;
                case 1:
                    userCharactor.transform.GetChild(1).gameObject.SetActive(true); 
                    selectedChar = 1;break;
                case 2:
                    userCharactor.transform.GetChild(2).gameObject.SetActive(true);
                    selectedChar = 2;break;
                case 3:
                    userCharactor.transform.GetChild(5).gameObject.SetActive(true);
                    selectedChar = 5;break;
                case 4:
                    userCharactor.transform.GetChild(6).gameObject.SetActive(true); 
                    selectedChar = 6;break;
                case 5:
                    userCharactor.transform.GetChild(7).gameObject.SetActive(true); 
                    selectedChar = 7;break;
                case 6:
                    userCharactor.transform.GetChild(13).gameObject.SetActive(true); 
                    selectedChar = 13;break;
                case 7:
                    userCharactor.transform.GetChild(15).gameObject.SetActive(true); 
                    selectedChar = 15;break;
                case 8:
                    userCharactor.transform.GetChild(17).gameObject.SetActive(true);
                    selectedChar = 17;break;
                case 9:
                    userCharactor.transform.GetChild(18).gameObject.SetActive(true); 
                    selectedChar = 18;break;
                case 10:
                    userCharactor.transform.GetChild(21).gameObject.SetActive(true);
                    selectedChar = 21;break;
                case 11:
                    userCharactor.transform.GetChild(22).gameObject.SetActive(true); 
                    selectedChar = 22;break;
                case 12:
                    userCharactor.transform.GetChild(20).gameObject.SetActive(true); 
                    selectedChar =20;break;
                case 13:
                    userCharactor.transform.GetChild(26).gameObject.SetActive(true); 
                    selectedChar = 26;break;
                case 14:
                    userCharactor.transform.GetChild(28).gameObject.SetActive(true); 
                    selectedChar = 28;break;
                case 15:
                    userCharactor.transform.GetChild(29).gameObject.SetActive(true);
                    selectedChar = 29;break;
                case 16:
                    userCharactor.transform.GetChild(30).gameObject.SetActive(true); 
                    selectedChar = 30;break;
                case 17:
                    userCharactor.transform.GetChild(36).gameObject.SetActive(true);
                    selectedChar = 36;break;
                    
            }
        }
        else
        {
            switch (int.Parse(charCode.Substring(1)))
            {
                case 0:
                    userCharactor.transform.GetChild(3).gameObject.SetActive(true); 
                    selectedChar = 3;break;
                case 1:
                    userCharactor.transform.GetChild(4).gameObject.SetActive(true); 
                    selectedChar = 4;break;
                case 2:
                    userCharactor.transform.GetChild(8).gameObject.SetActive(true); 
                    selectedChar = 8;break;
                case 3:
                    userCharactor.transform.GetChild(9).gameObject.SetActive(true); 
                    selectedChar = 9;break;
                case 4:
                    userCharactor.transform.GetChild(10).gameObject.SetActive(true); 
                    selectedChar = 10;break;
                case 5:
                    userCharactor.transform.GetChild(12).gameObject.SetActive(true); 
                    selectedChar = 12;break;
                case 6:
                    userCharactor.transform.GetChild(14).gameObject.SetActive(true); 
                    selectedChar = 14;break;
                case 7:
                    userCharactor.transform.GetChild(16).gameObject.SetActive(true); 
                    selectedChar = 16;break;
                case 8:
                    userCharactor.transform.GetChild(24).gameObject.SetActive(true);
                    selectedChar = 24;break;
                case 9:
                    userCharactor.transform.GetChild(25).gameObject.SetActive(true); 
                    selectedChar = 25;break;
                case 10:
                    userCharactor.transform.GetChild(31).gameObject.SetActive(true); 
                    selectedChar = 31;break;
                case 11:
                    userCharactor.transform.GetChild(35).gameObject.SetActive(true); 
                    selectedChar = 35;break;

            }
        }
        
        Debug.Log(skin+"번스킨 + "+cloth+"번 의상");
        userCharactor.transform.GetChild(selectedChar).gameObject
            .GetComponent<SkinnedMeshRenderer>().material = charTexture[cloth * 3 + skin];
    }
}
