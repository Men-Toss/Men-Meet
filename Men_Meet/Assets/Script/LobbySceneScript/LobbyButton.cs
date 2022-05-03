using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class LobbyButton : MonoBehaviour
{

    //캐릭터 성별 ( 0:남자  1:여자 )
    //캐릭터 인덱스
    public bool sexIndex = false;
    public int maleIndex = 1;
    public int femaleIndex = 1;
    //남자 캐릭터 배열,여자 캐릭터 배열
    [SerializeField] private Sprite[] CharLogoMaleArr;
    [SerializeField] private Sprite[] CharLogoFemaleArr;
    //표시할 Chractor Prefab
    public CharChoosePrefab[] choosePrefab = new CharChoosePrefab[6];
    //현재 인덱스 텍스트
    public Text indexText;
    //시작하기 버튼
    [SerializeField]private Button StartBtn;

    void Start() => CharLoadMale(1); 
    
    //남자 캐릭터 인덱스 메소드
    public void CharLoadMale(int index)
    {
        indexText.text = index.ToString() + " / 3";

        for (int i = (index - 1) * 6; i < index * 6; i++)
        {
            choosePrefab[i%6].setImg(CharLogoMaleArr[i]);
            choosePrefab[i%6].setCode("M"+i.ToString());
        }
    }
    public void CharLoadFemale(int index)
    {
        indexText.text = index.ToString() + " / 2";
        
        for (int i = (femaleIndex - 1) * 6; i < femaleIndex * 6; i++)
        {
            choosePrefab[i%6].setImg(CharLogoFemaleArr[i]);
            choosePrefab[i%6].setCode("W"+i.ToString());
        }
    }


    public void ClickLeft()
    {
        if (!sexIndex)
        {
            if (maleIndex != 1)
            {
                maleIndex--;
                CharLoadMale(maleIndex);
            }
        }
        else
        {
            if (femaleIndex != 1)
            {
                femaleIndex--;
                CharLoadFemale(femaleIndex);
            }
        }
    }

    public void ClickRight()
    {
        if (!sexIndex)
        {
            if (maleIndex !=3)
            {
                maleIndex++;
                CharLoadMale(maleIndex);
            }
        }
        else
        {
            if (femaleIndex !=2)
            {
                femaleIndex++;
                CharLoadFemale(femaleIndex);
            }
        }
    }
    public void ClickMale()
    {
        CharLoadMale(1);
        sexIndex = false;
    }

    public void ClickFemale()
    {
        CharLoadFemale(1);
        sexIndex = true ;
    }
    public void LogOutCLick() => SceneManager.LoadScene(0);
    public void StartClick() => SceneManager.LoadScene(2);
}
