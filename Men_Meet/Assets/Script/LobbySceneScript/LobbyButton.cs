using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UIElements.Image;

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
    //남자 버튼, 여자버튼
    public Button maleButton;
    public Button femaleButton;
    //시작하기 버튼
    [SerializeField]private Button StartBtn;
    //현재 캐릭터 선택 코드
    public string nowCharCode;
    //캐릭터 매니저 임포트
    public CharactorManage _CharactorManage;
    //캐릭터 스킨 코드
    public int skinCode=0;
    //캐릭터 의상 코드
    public int clothCode=0;
    //사운드 버튼
    public Button soundButton;
    // 현재 사운드 인덱스 0:음소거 / 1,2 / 3:최대
    public int soundIndex;
    //사운드 버튼 이미지 배열
    public Sprite[] soundSprite = new Sprite[4];
    void Start() => ClickMale();
    
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
        maleIndex = 1;
        femaleIndex = 1;
        CharLoadMale(1);
        sexIndex = false;
        maleButton.image.color = new Color(255, 0, 255);
        femaleButton.image.color = Color.white;
    }

    public void ClickFemale()
    {
        maleIndex = 1;
        femaleIndex = 1;
        CharLoadFemale(1);
        sexIndex = true ;
        maleButton.image.color = Color.white;
        femaleButton.image.color = new Color(255, 0, 255);
    }
    //프리팹 클릭시 현재 클릭한 버튼 정보 
    public void ClickPrefab(CharChoosePrefab c)
    {
        nowCharCode = c.getCode();
        _CharactorManage.setPrefabActive(nowCharCode);
    }

    public void ClickSkin(int skin)
    {
        this.skinCode = skin;
        _CharactorManage.setSkinClothColor(skinCode, clothCode);
    }
    public void ClickCloth(int cloth)
    {
        this.clothCode = cloth;
        _CharactorManage.setSkinClothColor(skinCode, clothCode);
    }
    public void LogOutCLick() => SceneManager.LoadScene(0);
    public void StartClick()
    {
        GameObject.Find("UserManager").GetComponent<UserStateScript>().userCharCode = nowCharCode;
        GameObject.Find("UserManager").GetComponent<UserStateScript>().userSkin = this.skinCode;
        GameObject.Find("UserManager").GetComponent<UserStateScript>().userCloth = this.clothCode;
        SceneManager.LoadScene(2); 
    }

    public void SoundClick()
    {
        soundIndex++;
        if (soundIndex == 4) soundIndex = 0;
        //LobbySoundScript.setSound(soundIndex);

        soundButton = soundSprite[soundIndex];
    }
}
