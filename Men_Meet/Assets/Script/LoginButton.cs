using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginButton : MonoBehaviour
{
    [SerializeField] string Signup;
    [SerializeField] string Introduce;
    
   //ȸ�� ���� ��ũ Ŭ����
   public void SignupClick() => Application.OpenURL(Signup);
    //�α��� ��ư Ŭ����
    public void LoginClick() => SceneManager.LoadScene(1);
    //������Ʈ �Ұ� ������ Ŭ����
    public void IntroduceClick() => Application.OpenURL(Introduce);
}
