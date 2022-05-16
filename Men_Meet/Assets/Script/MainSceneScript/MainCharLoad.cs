using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.TestTools;

public class MainCharLoad : MonoBehaviour
{
    //사용자 프리팹 닉네임
    public string charNickName;
    //사용자 캐릭터,스킨,의상코드
    public string charCode;
    public int skinCode;
    public int clothCode;
    //메테리얼 배열
    public Material[] charTexture = new Material[18];
    //현재 선택인덱스  
    public int selectedChar = 0;
    public PhotonView PV;
    void Start()
    {
        charCode = PV.InstantiationData[0].ToString();
        skinCode = int.Parse(PV.InstantiationData[1].ToString());
        clothCode = int.Parse(PV.InstantiationData[2].ToString());
        charNickName = PV.InstantiationData[3].ToString();
        if (PV.IsMine)
        {
            GameObject.Find("Camera").GetComponent<CameraMovement>().PV = this.GetComponent<PhotonView>();
            GameObject.Find("Camera").GetComponent<CameraMovement>().objectTofollow =
                gameObject.transform.GetChild(36).transform;
            
              }
        
        PV.RPC("loadChar",RpcTarget.AllBuffered);
        
    }
    
    [PunRPC]
    public void loadChar()
    {
        gameObject.transform.GetChild(37).GetComponent<TextMesh>().text = charNickName;
        loadCharactor(charCode,skinCode,clothCode);
        
    }
    
    //메타버스 월드 처음 입장 시 캐릭터 정보 
    public void loadCharactor(string charCode,int skin,int cloth)
    {
        for (int i = 0; i <= 36; i++)
        {
            gameObject.transform.GetChild(i).gameObject.SetActive(false);
        } 
        if (charCode[0].Equals('M'))
        {
            switch (int.Parse(charCode.Substring(1)))
            {
                case 0:
                    gameObject.transform.GetChild(0).gameObject.SetActive(true);
                    selectedChar = 0;break;
                case 1:
                    gameObject.transform.GetChild(1).gameObject.SetActive(true); 
                    selectedChar = 1;break;
                case 2:
                    gameObject.transform.GetChild(2).gameObject.SetActive(true);
                    selectedChar = 2;break;
                case 3:
                    gameObject.transform.GetChild(5).gameObject.SetActive(true);
                    selectedChar = 5;break;
                case 4:
                    gameObject.transform.GetChild(6).gameObject.SetActive(true); 
                    selectedChar = 6;break;
                case 5:
                    gameObject.transform.GetChild(7).gameObject.SetActive(true); 
                    selectedChar = 7;break;
                case 6:
                    gameObject.transform.GetChild(13).gameObject.SetActive(true); 
                    selectedChar = 13;break;
                case 7:
                    gameObject.transform.GetChild(15).gameObject.SetActive(true); 
                    selectedChar = 15;break;
                case 8:
                    gameObject.transform.GetChild(17).gameObject.SetActive(true);
                    selectedChar = 17;break;
                case 9:
                    gameObject.transform.GetChild(18).gameObject.SetActive(true); 
                    selectedChar = 18;break;
                case 10:
                    gameObject.transform.GetChild(21).gameObject.SetActive(true);
                    selectedChar = 21;break;
                case 11:
                    gameObject.transform.GetChild(22).gameObject.SetActive(true); 
                    selectedChar = 22;break;
                case 12:
                    gameObject.transform.GetChild(20).gameObject.SetActive(true); 
                    selectedChar =20;break;
                case 13:
                    gameObject.transform.GetChild(26).gameObject.SetActive(true); 
                    selectedChar = 26;break;
                case 14:
                    gameObject.transform.GetChild(28).gameObject.SetActive(true); 
                    selectedChar = 28;break;
                case 15:
                    gameObject.transform.GetChild(29).gameObject.SetActive(true);
                    selectedChar = 29;break;
                case 16:
                    gameObject.transform.GetChild(30).gameObject.SetActive(true); 
                    selectedChar = 30;break;
                case 17:
                    gameObject.transform.GetChild(36).gameObject.SetActive(true);
                    selectedChar = 36;break;
                    
            }
        }
        else
        {
            switch (int.Parse(charCode.Substring(1)))
            {
                case 0:
                    gameObject.transform.GetChild(3).gameObject.SetActive(true); 
                    selectedChar = 3;break;
                case 1:
                    gameObject.transform.GetChild(4).gameObject.SetActive(true); 
                    selectedChar = 4;break;
                case 2:
                    gameObject.transform.GetChild(8).gameObject.SetActive(true); 
                    selectedChar = 8;break;
                case 3:
                    gameObject.transform.GetChild(9).gameObject.SetActive(true); 
                    selectedChar = 9;break;
                case 4:
                    gameObject.transform.GetChild(10).gameObject.SetActive(true); 
                    selectedChar = 10;break;
                case 5:
                    gameObject.transform.GetChild(12).gameObject.SetActive(true); 
                    selectedChar = 12;break;
                case 6:
                    gameObject.transform.GetChild(14).gameObject.SetActive(true); 
                    selectedChar = 14;break;
                case 7:
                    gameObject.transform.GetChild(16).gameObject.SetActive(true); 
                    selectedChar = 16;break;
                case 8:
                    gameObject.transform.GetChild(24).gameObject.SetActive(true);
                    selectedChar = 24;break;
                case 9:
                    gameObject.transform.GetChild(25).gameObject.SetActive(true); 
                    selectedChar = 25;break;
                case 10:
                    gameObject.transform.GetChild(31).gameObject.SetActive(true); 
                    selectedChar = 31;break;
                case 11:
                    gameObject.transform.GetChild(35).gameObject.SetActive(true); 
                    selectedChar = 35;break;

            }
        }
        
        Debug.Log(skin+"번스킨 + "+cloth+"번 의상");
        gameObject.transform.GetChild(selectedChar).gameObject
            .GetComponent<SkinnedMeshRenderer>().material = charTexture[cloth * 3 + skin];
    }


}
