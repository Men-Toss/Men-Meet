using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class LobbyButton : MonoBehaviour
{
    //public ScrollView scrollView;
    public int index = 0;
    [SerializeField] private ScrollRect scrollRect;
    [SerializeField] private List<RectTransform> ConfirmedUIobjects = new List<RectTransform>();
    [SerializeField] private Sprite[] CharLogomenArr;
    [SerializeField] private Sprite[] CharLogoWomenArr;
    public CharChoosePrefab[] choosePrefab = new CharChoosePrefab[6];
    private int[] CharChooseRectX = new int[3] { -300, 0, 300 };

    public void CharLoadMen(int menindex)
    {
        //scrollView.Clear();
        ConfirmedUIobjects.Clear();
        float y = 0f;
        menindex = 0;
        
        for (int i = menindex * 6; i < menindex * 6 + 6; i++)
            choosePrefab[i].SetImg(CharLogomenArr[i]);
    }


public void LogOutCLick() => SceneManager.LoadScene(0);
    public void StartClick() => SceneManager.LoadScene(2);
}
