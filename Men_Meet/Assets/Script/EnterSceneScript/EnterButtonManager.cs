using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterButtonManager : MonoBehaviour
{
    //정문 클릭시
    public void Start_Front()
    {
        GameObject.Find("UserManager").GetComponent<UserStateScript>().userStartPoint=false;
        //LoadingScene
        SceneManager.LoadScene(3);
    }
    //후문 클릭시
    public void Start_Back()
    {
        GameObject.Find("UserManager").GetComponent<UserStateScript>().userStartPoint=true;
        //LoadingScene
        SceneManager.LoadScene(3);
    }
}
