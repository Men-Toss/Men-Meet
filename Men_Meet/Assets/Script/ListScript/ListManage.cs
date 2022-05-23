using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ListManage : MonoBehaviour
{
    //리스트 스크롤 , 프리팹 사잉 스페이스
    public ScrollRect _ScrollRect;
    public Scrollbar _Scrollbar;
    public float Space = 50f;
    //학교소개 리스트 프리팹
    public GameObject IPD;
    //프리팹리스트
    public List<RectTransform> ConfirmedUIobjects=new List<RectTransform>();
    //학과소개 메인,서브 텍스트
    public List<string> SchoolMainText;
    public List<string> SchoolSubText;
    //부처 소개 메인,서브 텍스트
    public List<string> DepartmentMainText;
    public List<string> DepartmentSubText;
    //건물 소개 메인,서브 텍스트
    public List<string> StructureMainText;
    public List<string> StructureSubText;
    //동아리 소개 메인,서브 텍스트
    public List<string> CirclesMainText;
    public List<string> CirclesSubText;
    //API로드 결과값 저장 스트링
    public string API_Result;
    //교과 프로그램 제목,내용,시작시간,종료시간,프로그램코드
    public List<string>[] Program1=new List<string>[5];
    //비교과 프로그램 제목,내용,시작시간,종료시간,프로그램코드
    public List<string>[] Program2=new List<string>[5];
    //학과 프로그램 제목,내용,시작시간,종료시간,프로그램코드
    public List<string>[] Program3=new List<string>[5];
    //기타 프로그램 제목,내용,시작시간,종료시간,프로그램코드
    public List<string>[] Program4=new List<string>[5];
    //자주묻는 질문 제목,내용,시작시간,종료시간,프로그램코드
    public List<string>[] Program5=new List<string>[5];


    void Start()
    {
        addSchoolData();
    }
    //학교 리스트 데이터 추가
    public void addSchoolData()
    {
        //공학계열
        SchoolMainText.Add("컴퓨터전자공학과");
        SchoolSubText.Add("공학계열");
        SchoolMainText.Add("전기공학과");
        SchoolSubText.Add("공학계열");
        SchoolMainText.Add("정보통신공학과");
        SchoolSubText.Add("공학계열");
        SchoolMainText.Add("소프트웨어공학과");
        SchoolSubText.Add("공학계열");
        SchoolMainText.Add("건축과");
        SchoolSubText.Add("공학계열");
        SchoolMainText.Add("생명화학공학과");
        SchoolSubText.Add("공학계열");
        SchoolMainText.Add("건설시스템공학과");
        SchoolSubText.Add("공학계열");
        SchoolMainText.Add("스마트자동차공학과");
        SchoolSubText.Add("공학계열");
        SchoolMainText.Add("산업경영학과");
        SchoolSubText.Add("공학계열");
        SchoolMainText.Add("스마트승강기학과");
        SchoolSubText.Add("공학계열");
        SchoolMainText.Add("AI융합콘텐츠학과");
        SchoolSubText.Add("공학계열");
        //인문사회계열
        SchoolMainText.Add("유아교육학과");
        SchoolSubText.Add("인문사회계열");
        SchoolMainText.Add("자산법률학과");
        SchoolSubText.Add("인문사회계열");
        SchoolMainText.Add("비즈니스영어과");
        SchoolSubText.Add("인문사회계열");
        SchoolMainText.Add("비즈니스일본어과");
        SchoolSubText.Add("인문사회계열");
        SchoolMainText.Add("중국어문화학과");
        SchoolSubText.Add("인문사회계열");
        SchoolMainText.Add("미디어출판학과");
        SchoolSubText.Add("인문사회계열");
        SchoolMainText.Add("사회복지학과");
        SchoolSubText.Add("인문사회계열");
        SchoolMainText.Add("세무회계학과");
        SchoolSubText.Add("인문사회계열");
        //자연계열
        SchoolMainText.Add("간호학과");
        SchoolSubText.Add("자연계열");
        SchoolMainText.Add("식품영양학과");
        SchoolSubText.Add("자연계열");
        //예체능 계열
        SchoolMainText.Add("영화방송공연예술학과");
        SchoolSubText.Add("예체능계열");
        SchoolMainText.Add("패션산업학과");
        SchoolSubText.Add("예체능계열");
        SchoolMainText.Add("생활가구디자인학과");
        SchoolSubText.Add("예체능계열");
        SchoolMainText.Add("실내디자인학과");
        SchoolSubText.Add("예체능계열");
        SchoolMainText.Add("커뮤니케이션디자인학과");
        SchoolSubText.Add("예체능계열");
        SchoolMainText.Add("레저스포츠학과");
        SchoolSubText.Add("예체능계열");
        SchoolMainText.Add("VMD&전시디자인학과");
        SchoolSubText.Add("예체능계열");
        SchoolMainText.Add("웹툰스토리텔링학과");
        SchoolSubText.Add("예체능계열");
        
        
        
        //부처 소개
        DepartmentMainText.Add("대학평의원회");
        DepartmentSubText.Add("대학조직");
        DepartmentMainText.Add("기획조정처");
        DepartmentSubText.Add("대학조직");
        DepartmentMainText.Add("교무처");
        DepartmentSubText.Add("대학조직");
        DepartmentMainText.Add("학생지원처");
        DepartmentSubText.Add("대학조직");
        DepartmentMainText.Add("산학협력처");
        DepartmentSubText.Add("대학조직");
        DepartmentMainText.Add("입학홍보처");
        DepartmentSubText.Add("대학조직");
        DepartmentMainText.Add("사무처");
        DepartmentSubText.Add("대학조직");
        DepartmentMainText.Add("건설본부");
        DepartmentSubText.Add("대학조직");
        DepartmentMainText.Add("부속기관");
        DepartmentSubText.Add("대학조직");
        DepartmentMainText.Add("부설기관");
        DepartmentSubText.Add("대학조직");

        
        //건물소개
        StructureMainText.Add("흥학관");
        StructureSubText.Add("CAMPUS TOUR");
        StructureMainText.Add("호천관");
        StructureSubText.Add("CAMPUS TOUR");
        StructureMainText.Add("세종관");
        StructureSubText.Add("CAMPUS TOUR");
        StructureMainText.Add("서일관");
        StructureSubText.Add("CAMPUS TOUR");
        StructureMainText.Add("지덕관");
        StructureSubText.Add("CAMPUS TOUR");
        StructureMainText.Add("누리관");
        StructureSubText.Add("CAMPUS TOUR");
        StructureMainText.Add("도서관");
        StructureSubText.Add("CAMPUS TOUR");
        StructureMainText.Add("배양관");
        StructureSubText.Add("CAMPUS TOUR");
        StructureMainText.Add("동아리관");
        StructureSubText.Add("CAMPUS TOUR");
        StructureMainText.Add("정문/어린이집");
        StructureSubText.Add("CAMPUS TOUR");
        
        //동아리소개
        CirclesMainText.Add("행랑 ESC");
        CirclesSubText.Add("동아리");
        CirclesMainText.Add("SENSATION");
        CirclesSubText.Add("동아리");
        CirclesMainText.Add("설계반");
        CirclesSubText.Add("동아리");
        CirclesMainText.Add("ART 마당");
        CirclesSubText.Add("동아리");
        CirclesMainText.Add("형상 사진회");
        CirclesSubText.Add("동아리");
        CirclesMainText.Add("VIC");
        CirclesSubText.Add("동아리");
        CirclesMainText.Add("WINGS");
        CirclesSubText.Add("동아리");
        CirclesMainText.Add("도시락");
        CirclesSubText.Add("동아리");
        CirclesMainText.Add("막내동이");
        CirclesSubText.Add("동아리");
        CirclesMainText.Add("컴퓨닉스");
        CirclesSubText.Add("동아리");
        CirclesMainText.Add("SISB");
        CirclesSubText.Add("동아리");
        CirclesMainText.Add("ThreeQ");
        CirclesSubText.Add("동아리");
        CirclesMainText.Add("니랑 극 예술 연구회");
        CirclesSubText.Add("동아리");
        CirclesMainText.Add("RCY");
        CirclesSubText.Add("동아리");
        CirclesMainText.Add("SAM");
        CirclesSubText.Add("동아리");
        CirclesMainText.Add("유스호스텔");
        CirclesSubText.Add("동아리");
        CirclesMainText.Add("MAC");
        CirclesSubText.Add("동아리");
        CirclesMainText.Add("C.C.C");
        CirclesSubText.Add("동아리");
    }
    //프로그램 리스트 데이터 추가
    public void addProgramData()
    {
        StartCoroutine(LoadProgramCorutine());
    }
    //프로그램 리스트 코루틴
    //로그인 코루틴
    public IEnumerator LoadProgramCorutine()
    {
        string serverPath = "http://mentoss123.cafe24.com/SungjinTest/LoadProgramList.jsp";
        Debug.Log(serverPath);
        using (UnityWebRequest webRequest = UnityWebRequest.Get(serverPath)) 
        {
            yield return webRequest.SendWebRequest(); 
                
            if (webRequest.isNetworkError || webRequest.isHttpError){
                Debug.Log(webRequest.error);
            }else
            {
                API_Result=System.Text.Encoding.UTF8.GetString(webRequest.downloadHandler.data).ToString();
                loadProgramListData();
            }
        }
    }
    //프로그램 소개 리스트 갱신하기
    public void loadProgramListData()
    {
        XmlDocument AllVaccineXml=new XmlDocument();
        AllVaccineXml.LoadXml(API_Result);
        XmlNodeList all_nodes = AllVaccineXml.SelectNodes("response/body/items/item");
    }
    //학교 소개 리스트 갱신하기
    public void loadIntroListData(int cmd)
    {
        ConfirmedUIobjects.Clear();
        
        if (cmd == 1)
        {
            for (int i = 0; i < SchoolMainText.Count; i++)
            {
                IPD.GetComponent<IntroducePrefabData>().MainText.text = SchoolMainText[i];
                IPD.GetComponent<IntroducePrefabData>().SubText.text = SchoolSubText[i];
                IPD.GetComponent<IntroducePrefabData>().Code = "1_" + i.ToString();
                IPD.GetComponent<IntroducePrefabData>().setColor(Color.cyan);
                var newUI = Instantiate(IPD, _ScrollRect.content).GetComponent<RectTransform>();
                ConfirmedUIobjects.Add(newUI);
            }
        }
        else if (cmd == 2)
        {
            for (int i = 0; i < DepartmentMainText.Count; i++)
            {
                IPD.GetComponent<IntroducePrefabData>().MainText.text = DepartmentMainText[i];
                IPD.GetComponent<IntroducePrefabData>().SubText.text = DepartmentSubText[i];
                IPD.GetComponent<IntroducePrefabData>().Code = "2_" + i.ToString();
                IPD.GetComponent<IntroducePrefabData>().setColor(Color.magenta);
                var newUI = Instantiate(IPD, _ScrollRect.content).GetComponent<RectTransform>();
                ConfirmedUIobjects.Add(newUI);
            }
        }
        else if (cmd == 3)
        {
            for (int i = 0; i < StructureMainText.Count; i++)
            {
                IPD.GetComponent<IntroducePrefabData>().MainText.text = StructureMainText[i];
                IPD.GetComponent<IntroducePrefabData>().SubText.text = StructureSubText[i];
                IPD.GetComponent<IntroducePrefabData>().Code = "3_" + i.ToString();
                IPD.GetComponent<IntroducePrefabData>().setColor(Color.yellow);
                var newUI = Instantiate(IPD, _ScrollRect.content).GetComponent<RectTransform>();
                ConfirmedUIobjects.Add(newUI);
            }
        }
        else
        {
            for (int i = 0; i < CirclesMainText.Count; i++)
            {
                IPD.GetComponent<IntroducePrefabData>().MainText.text = CirclesMainText[i];
                IPD.GetComponent<IntroducePrefabData>().SubText.text = CirclesSubText[i];
                IPD.GetComponent<IntroducePrefabData>().Code = "4_" + i.ToString();
                IPD.GetComponent<IntroducePrefabData>().setColor(Color.green);
                var newUI = Instantiate(IPD, _ScrollRect.content).GetComponent<RectTransform>();
                ConfirmedUIobjects.Add(newUI);
            }
        }
        
        float y=20f;
        for(int i=0;i<ConfirmedUIobjects.Count;i++){
            ConfirmedUIobjects[i].anchoredPosition=new Vector2(0f,-y);
            y+=ConfirmedUIobjects[i].sizeDelta.y+Space;
        }
        _ScrollRect.content.sizeDelta=new Vector2(_ScrollRect.content.sizeDelta.x,y);
        _Scrollbar.value = 1.00f;
    }
}
