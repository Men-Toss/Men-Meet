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
}
