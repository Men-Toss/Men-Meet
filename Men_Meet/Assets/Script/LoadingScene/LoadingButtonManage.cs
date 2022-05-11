using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoadingButtonManage : MonoBehaviour
{
    public GameObject loadingPanel;

    public void ClickStart()
    {
        loadingPanel.SetActive(false);
    }
    //종료버튼 클릭 시
    public void ClickExit()=> Application.Quit();
    //설정버튼 클릭 시
    public void ClickSetting()
    {
        
    }
    //마이크 음소거 / 음소거 해제
    public void ClickMicroPhone()
    {
        
    }
    //전체 볼륨 조정 / 0,1,2,3
    public void ClickVolume()
    {
        
    }
}
