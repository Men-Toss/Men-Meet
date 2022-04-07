using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyButton : MonoBehaviour
{
    [SerializeField] private ScrollRect scrollRect;
    [SerializeField] private List<RectTransform> ConfirmedUIobjects=new List<RectTransform>();
    [SerializeField] private Sprite[] CharLogomenArr;
    [SerializeField] private Sprite[] CharLogoWomenArr;
    public CharChoosePrefab  choosePrefab;
    private int[] CharChooseRectX = new int[3] { -300, 0, 300 };
    public void CharLoadMen()
    {
        ConfirmedUIobjects.Clear();
        for (int i = 0; i < CharLogomenArr.Length; i++)
        {
            choosePrefab.SetImg(CharLogomenArr[i]);
            var newButton = Instantiate(choosePrefab, scrollRect.content).GetComponent<RectTransform>();
            ConfirmedUIobjects.Add(newButton);
        }

        for (int i = 0; i < ConfirmedUIobjects.Count; i++)
            ConfirmedUIobjects[i].anchoredPosition = new Vector2(CharChooseRectX[i%3], -40 + (-240*(i/3)));

            //scrollRect.content.sizeDelta = new Vector2(scrollRect.content.sizeDelta.x, -40 + (-240 * ((ConfirmedUIobjects.Count - 1) / 3)));

    }
    public void LogOutCLick() => SceneManager.LoadScene(0);
    public void StartClick() => SceneManager.LoadScene(3);
}
