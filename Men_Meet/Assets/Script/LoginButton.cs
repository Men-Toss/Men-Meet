using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginButton : MonoBehaviour
{
    [SerializeField] string Signup;
    [SerializeField] string Introduce;
    
   //회원 가입 링크 클릭시
   public void SignupClick() => Application.OpenURL(Signup);
    //로그인 버튼 클릭시
    public void LoginClick() => SceneManager.LoadScene(1);
    //프로젝트 소개 페이지 클릭시
    public void IntroduceClick() => Application.OpenURL(Introduce);
}
