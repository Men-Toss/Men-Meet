using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorManage : MonoBehaviour
{
    //캐릭터 화면 프리팹
    public GameObject LobbyCharPrefab;
    //메테리얼 배열
    public Material[] charTexture = new Material[18];
    //현재 선택인덱스
    public int selectedChar = 0;
    private void Start()
    {
        PrefabReset();
    }

    private void PrefabReset()
    {
        for (int i = 0; i <= 36; i++)
        {
            LobbyCharPrefab.transform.GetChild(i).gameObject.SetActive(false);
        } 
    }
    public void setPrefabActive(string cmd)
    {
        
        PrefabReset();
        
        if (cmd[0].Equals('M'))
        {
            switch (int.Parse(cmd.Substring(1)))
            {
                case 0:
                    LobbyCharPrefab.transform.GetChild(0).gameObject.SetActive(true);
                    selectedChar = 0;break;
                case 1:
                    LobbyCharPrefab.transform.GetChild(1).gameObject.SetActive(true); 
                    selectedChar = 1;break;
                case 2:
                    LobbyCharPrefab.transform.GetChild(2).gameObject.SetActive(true);
                    selectedChar = 2;break;
                case 3:
                    LobbyCharPrefab.transform.GetChild(5).gameObject.SetActive(true);
                    selectedChar = 5;break;
                case 4:
                    LobbyCharPrefab.transform.GetChild(6).gameObject.SetActive(true); 
                    selectedChar = 6;break;
                case 5:
                    LobbyCharPrefab.transform.GetChild(7).gameObject.SetActive(true); 
                    selectedChar = 7;break;
                case 6:
                    LobbyCharPrefab.transform.GetChild(13).gameObject.SetActive(true); 
                    selectedChar = 13;break;
                case 7:
                    LobbyCharPrefab.transform.GetChild(15).gameObject.SetActive(true); 
                    selectedChar = 15;break;
                case 8:
                    LobbyCharPrefab.transform.GetChild(17).gameObject.SetActive(true);
                    selectedChar = 17;break;
                case 9:
                    LobbyCharPrefab.transform.GetChild(18).gameObject.SetActive(true); 
                    selectedChar = 18;break;
                case 10:
                    LobbyCharPrefab.transform.GetChild(21).gameObject.SetActive(true);
                    selectedChar = 21;break;
                case 11:
                    LobbyCharPrefab.transform.GetChild(22).gameObject.SetActive(true); 
                    selectedChar = 22;break;
                case 12:
                    LobbyCharPrefab.transform.GetChild(20).gameObject.SetActive(true); 
                    selectedChar =20;break;
                case 13:
                    LobbyCharPrefab.transform.GetChild(26).gameObject.SetActive(true); 
                    selectedChar = 26;break;
                case 14:
                    LobbyCharPrefab.transform.GetChild(28).gameObject.SetActive(true); 
                    selectedChar = 28;break;
                case 15:
                    LobbyCharPrefab.transform.GetChild(29).gameObject.SetActive(true);
                    selectedChar = 29;break;
                case 16:
                    LobbyCharPrefab.transform.GetChild(30).gameObject.SetActive(true); 
                    selectedChar = 30;break;
                case 17:
                    LobbyCharPrefab.transform.GetChild(36).gameObject.SetActive(true);
                    selectedChar = 36;break;
                    
            }
        }
        else
        {
            switch (int.Parse(cmd.Substring(1)))
            {
                case 0:
                    LobbyCharPrefab.transform.GetChild(3).gameObject.SetActive(true); 
                    selectedChar = 3;break;
                case 1:
                    LobbyCharPrefab.transform.GetChild(4).gameObject.SetActive(true); 
                    selectedChar = 4;break;
                case 2:
                    LobbyCharPrefab.transform.GetChild(8).gameObject.SetActive(true); 
                    selectedChar = 8;break;
                case 3:
                    LobbyCharPrefab.transform.GetChild(9).gameObject.SetActive(true); 
                    selectedChar = 9;break;
                case 4:
                    LobbyCharPrefab.transform.GetChild(10).gameObject.SetActive(true); 
                    selectedChar = 10;break;
                case 5:
                    LobbyCharPrefab.transform.GetChild(12).gameObject.SetActive(true); 
                    selectedChar = 12;break;
                case 6:
                    LobbyCharPrefab.transform.GetChild(14).gameObject.SetActive(true); 
                    selectedChar = 14;break;
                case 7:
                    LobbyCharPrefab.transform.GetChild(16).gameObject.SetActive(true); 
                    selectedChar = 16;break;
                case 8:
                    LobbyCharPrefab.transform.GetChild(24).gameObject.SetActive(true);
                    selectedChar = 24;break;
                case 9:
                    LobbyCharPrefab.transform.GetChild(25).gameObject.SetActive(true); 
                    selectedChar = 25;break;
                case 10:
                    LobbyCharPrefab.transform.GetChild(31).gameObject.SetActive(true); 
                    selectedChar = 31;break;
                case 11:
                    LobbyCharPrefab.transform.GetChild(35).gameObject.SetActive(true); 
                    selectedChar = 35;break;

            }
        }
    }

    //프리팹 사용자 스킨색상, 옷 색상 정하기
    public void setSkinClothColor(int skin,int cloth)
    {
        Debug.Log(skin+"번스킨 + "+cloth+"번 의상");
LobbyCharPrefab.transform.GetChild(selectedChar).gameObject
    .GetComponent<SkinnedMeshRenderer>().material = charTexture[cloth * 3 + skin];
    }

}
