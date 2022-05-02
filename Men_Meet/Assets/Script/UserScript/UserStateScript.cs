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
    //유저 스타팅 포인트 (0:정문 1:후문)
    public bool userStartPoint = false;
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
    //씬 이동해도 오브젝트 파괴 X
    void Awake() => DontDestroyOnLoad(gameObject);
}
