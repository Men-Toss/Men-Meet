using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginButton : MonoBehaviour
{
    [SerializeField] string Signup;
    
   //ȸ�� ���� ��ũ Ŭ����
   public void SignupClick() => Application.OpenURL(Signup);

    //�α��� ��ư Ŭ����
    public void LoginClick() => SceneManager.LoadScene(1);
}
