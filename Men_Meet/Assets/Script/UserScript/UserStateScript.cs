using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserStateScript : MonoBehaviour
{
    //유저 아이디
    [SerializeField] private string userID;
    //유저 비밀번호
    [SerializeField] private string userNickName;
    //유저 스타팅 포인트 (0:프로그램 1:멘토링 2:학교소개 3:만남의 광장 )
    public int userStartPoint = 3;
    //유저 아이디.비밀번호 프로퍼티(Property)
    public string UserId
    {
        get { return userID; }
        set { userID = value; }
    }
    public string UserNickName
    {
        get { return userNickName; }
        set { userNickName = value; }
    }
    //유저 캐릭터 코드/스킨/의상 색상정보
    public string userCharCode;
    public int userSkin;
    public int userCloth;
    
    
    //씬 이동해도 오브젝트 파괴 X
    void Awake() => DontDestroyOnLoad(gameObject);
}
