using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyButton : MonoBehaviour
{
    public void LogOutCLick() => SceneManager.LoadScene(0);
    public void StartClick() => SceneManager.LoadScene(3);
}
