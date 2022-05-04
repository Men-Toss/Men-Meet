using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbySceneManager : MonoBehaviour
{
    [SerializeField] private Text welcomeText;
    [SerializeField] private Text subText;
    
    //사용자 정보 닉네임 불러와서 텍스트 교체 
    private void Awake()
    {
        string userNickname = GameObject.Find("UserManager").GetComponent<UserStateScript>().UserNickName;
        welcomeText.text = "안녕하세요! " + userNickname + "님!";
        subText.text = userNickname+"님의 캐릭터";
    }
}
