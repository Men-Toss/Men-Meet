using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoadingButtonManage : MonoBehaviour
{
    public void ClickStart()
    {
        SceneManager.LoadScene(4);
    }
}
