using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbySceneManager : MonoBehaviour
{
    [SerializeField] private Text welcomeText;
    [SerializeField] private Text subText;
    private void Start()
    {
        //string userNickname = GameObject.Find("UserManager").GetComponent<UserStateScript>().UserNickName;
        //welcomeText.text = "안녕하세요! " + userNickname + "님!";
        //subText.text = userNickname+"님의 캐릭터";
    }
}
