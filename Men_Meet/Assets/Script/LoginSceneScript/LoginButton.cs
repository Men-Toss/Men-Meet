using System.Collections;
using System.Collections.Generic;
using System.Text;
using ERP.Discord;
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
    [SerializeField] private UserStateScript stateScript;
    //테스트용 코드(삭제 예정)
    void Start()
    {
        
    }
    //회원가입 버튼 클릭 시 
   public void SignupClick() => Application.OpenURL(Signup);
    //로그인 버튼 클릭 시
    public void LoginClick() => StartCoroutine(Login());
    //Men-Meet소개 텍스트 클릭
    public void IntroduceClick() => Application.OpenURL(Introduce);
    //로그인 실패 안내 통지메세지
    public void ShowFailedPanel() => FailedPanel.SetActive(true);

    public void CloseFailedPanel() => FailedPanel.SetActive(false);

    class  LoginCompleteUser
    {
        public bool isLoginConfirmed;
        public string userId;
        public string userName;
        public LoginCompleteUser(bool isLoginConfirmed, string userId, string userName)
        {
            this.isLoginConfirmed = isLoginConfirmed;
            this.userId = userId;
            this.userName = userName;
        }
    }
    class LoginUser
    {
        public string userId;
        public string userPassword;

        public LoginUser(string userId, string userPassword)
        {
            this.userId = userId;
            this.userPassword = userPassword;
        }
    }
    //로그인 코루틴
    public IEnumerator Login()
    {
        //LoginSucceed();
        yield return null;
        
        string serverid = UIDInputText.text;
        string serverpw = UPWInputText.text;

        string serverPath = "http://52.79.209.184:8080/login";
        string json = JsonUtility.ToJson(new LoginUser(serverid,serverpw));
        Debug.Log(serverPath);
        Debug.Log(json);
        Encoding.UTF8.GetBytes(json);   
        
        using (UnityWebRequest webRequest = UnityWebRequest.Post(serverPath,json))
        {
            byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
            
            webRequest.uploadHandler = new UploadHandlerRaw(jsonToSend);
            webRequest.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            webRequest.SetRequestHeader("Content-Type","application/json");

            yield return webRequest.SendWebRequest(); 
                
            if (webRequest.isNetworkError || webRequest.isHttpError){
                Debug.Log(webRequest.error);
            }
            else
            {
                LoginCompleteUser result = JsonUtility.FromJson<LoginCompleteUser>(webRequest.downloadHandler.text);
                
                Debug.Log(result);

                    if (result.isLoginConfirmed)
                {
                    Debug.Log("로그인 성공했습니다.");
                    stateScript.UserNickName = result.userName;
                    LoginSucceed();
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
    //로그인 성공 시 다음 씬
    void LoginSucceed()
    {
        stateScript.UserId = UIDInputText.text;
        SceneManager.LoadScene(1);
    }
}