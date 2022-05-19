using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterButtonManager : MonoBehaviour
{
    //유저 스타팅 포인트 (0:프로그램 1:멘토링 2:학교소개 3:만남의 광장 )
    public void startWith(int num)
    {
        GameObject.Find("UserManager").GetComponent<UserStateScript>().userStartPoint=num;
        //LoadingScene
        SceneManager.LoadScene(3);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
