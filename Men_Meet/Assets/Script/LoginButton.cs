using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class LoginButton : MonoBehaviour
{
    [SerializeField] private InputField UIDInputText;
    [SerializeField] private InputField UPWInputText;
    [SerializeField] string Signup;
    [SerializeField] string Introduce;
    [SerializeField] private GameObject FailedPanel;
    
    //회원가입 버튼 클릭 시 
   public void SignupClick() => Application.OpenURL(Signup);
    //로그인 버튼 클릭 시
    public void LoginClick() => StartCoroutine(Login());
    //Men-Meet소개 텍스트 클릭
    public void IntroduceClick() => Application.OpenURL(Introduce);
    //로그인 실패 안내 통지메세지
    public void ShowFailedPanel() => FailedPanel.SetActive(true);

    public void CloseFailedPanel() => FailedPanel.SetActive(false);
    //로그인 코루틴
    public IEnumerator Login()
    {
        string serverid = "UID="+UIDInputText.text;
        string serverpw = "UPW="+UPWInputText.text;
        string serverPath = "http://mentoss123.cafe24.com/SungjinTest/LoginTest.jsp?"+serverid+"&"+serverpw;
        Debug.Log(serverPath);
        using (UnityWebRequest webRequest = UnityWebRequest.Get(serverPath)) 
        {
            yield return webRequest.SendWebRequest(); 
                
            if (webRequest.isNetworkError || webRequest.isHttpError){
                Debug.Log(webRequest.error);
            }
            else
            {
                string result = webRequest.downloadHandler.text;
                Debug.Log(result);

                if (result.Trim().Equals("Correct"))
                {
                    Debug.Log("로그인 성공했습니다.");
                }
                else
                {
                    Debug.Log("로그인 실패했습니다.");
                    ShowFailedPanel();
                }

                UIDInputText.text = "";
                UPWInputText.text = "";
            }
        }
    }
}