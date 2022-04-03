using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginButton : MonoBehaviour
{
    [SerializeField] string Signup;
    
   //회원 가입 링크 클릭시
   public void SignupClick() => Application.OpenURL(Signup);

    //로그인 버튼 클릭시
    public void LoginClick() => SceneManager.LoadScene(1);
}
