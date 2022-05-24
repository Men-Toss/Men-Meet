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
    //학교 소개 프리팹리스트
    public List<RectTransform> ConfirmedUIobjects=new List<RectTransform>();
    //학교소개 리스트 프리팹
    public GameObject IPD;
    //프로그램 리스트는 고정 리스트 형태라서 필요 없을 듯
    public ProgramPrefabData[] Program_Array = new ProgramPrefabData[8];
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
    //프로그램 변수 저장
    public string Program_Name;
    public string Program_Introduce;
    public string Program_Start;
    public string Program_End;
    public int Program_Code;
    //프로그램 소개 인덱스, 배열
    public int Programcmd = 0;
    public int ProgramNowIndex = 1;
    public int ProgramMaxIndex = 0;
    //현재 인덱스,최대 인덱스 텍스트
    public Text ProgramIndexText;
    //교과 프로그램 제목,내용,시작시간,종료시간,프로그램코드
    public List<string>[] Program1=new List<string>[4];
    //비교과 프로그램 제목,내용,시작시간,종료시간,프로그램코드
    public List<string>[] Program2=new List<string>[4];
    //학과 프로그램 제목,내용,시작시간,종료시간,프로그램코드
    public List<string>[] Program3=new List<string>[4];
    //기타 프로그램 제목,내용,시작시간,종료시간,프로그램코드
    public List<string>[] Program4=new List<string>[4];
    //자주묻는 질문 제목,내용,시작시간,종료시간,프로그램코드
    public List<string>[] Program5=new List<string>[4];


    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            Program1[i] = new List<string>();
            Program2[i] = new List<string>();
            Program3[i] = new List<string>();
            Program4[i] = new List<string>();
            Program5[i] = new List<string>();
        }
        addSchoolData();
        addProgramData();

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
                addProgramListData();
            }
        }
    }
    //프로그램 소개 리스트 갱신하기
    public void addProgramListData()
    {
        XmlDocument AllVaccineXml=new XmlDocument();
        AllVaccineXml.LoadXml(API_Result);
        XmlNodeList all_nodes = AllVaccineXml.SelectNodes("Program_List/Element");

        foreach (XmlNode node in all_nodes)
        {
            Program_Name=node.SelectSingleNode("Program_Name").InnerText;
            Program_Introduce=node.SelectSingleNode("Program_Introduce").InnerText;
            Program_Start=node.SelectSingleNode("Program_Start").InnerText;
            Program_End=node.SelectSingleNode("Program_End").InnerText;
            Program_Code = int.Parse(node.SelectSingleNode("Program_Code").InnerText);
            Debug.Log(Program_Name);
            Debug.Log(Program_Introduce);
            Debug.Log(Program_Start);
            Debug.Log(Program_End);
            Debug.Log(Program_Code.ToString());
            addNode();
        }
    }
    //리스트 추가 함수
    public void addNode() {
        switch (Program_Code)
        {
            case 1:
                Program1[0].Add(Program_Name);
                Program1[1].Add(Program_Introduce);
                Program1[2].Add(Program_Start);
                Program1[3].Add(Program_End);
                break;
            case 2:
                Program2[0].Add(Program_Name);
                Program2[1].Add(Program_Introduce);
                Program2[2].Add(Program_Start);
                Program2[3].Add(Program_End);
                break;
            case 3:
                Program3[0].Add(Program_Name);
                Program3[1].Add(Program_Introduce);
                Program3[2].Add(Program_Start);
                Program3[3].Add(Program_End);
                break;
            case 4:
                Program4[0].Add(Program_Name);
                Program4[1].Add(Program_Introduce);
                Program4[2].Add(Program_Start);
                Program4[3].Add(Program_End);
                break;
            case 5:
                Program5[0].Add(Program_Name);
                Program5[1].Add(Program_Introduce);
                Program5[2].Add(Program_Start);
                Program5[3].Add(Program_End);
                break;
            default:
                Debug.Log("addNode입력 오류");
                break;
        }
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
                IPD.GetComponent<IntroducePrefabData>().Code1 = 1;
                IPD.GetComponent<IntroducePrefabData>().Code2 = i;
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
                IPD.GetComponent<IntroducePrefabData>().Code1 = 2;
                IPD.GetComponent<IntroducePrefabData>().Code2 = i; 
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
                IPD.GetComponent<IntroducePrefabData>().Code1 = 3;
                IPD.GetComponent<IntroducePrefabData>().Code2 = i; 
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
                IPD.GetComponent<IntroducePrefabData>().Code1 = 4;
                IPD.GetComponent<IntroducePrefabData>().Code2 = i; 
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
    //프로그램 소개 리스트 갱신하기
    public void LoadProgramListData()
    {
        if (Programcmd == 1)
            ProgramMaxIndex = (Program1[0].Count-1)/8+1;
        else if(Programcmd == 2)
            ProgramMaxIndex = (Program2[0].Count-1)/8+1;
        else if(Programcmd == 3)
            ProgramMaxIndex = (Program3[0].Count-1)/8+1;
        else if(Programcmd == 4)
            ProgramMaxIndex = (Program4[0].Count-1)/8+1;
        else 
            ProgramMaxIndex = (Program5[0].Count-1)/8+1;
        
        ProgramIndexText.text = ProgramNowIndex.ToString() + "  /  " + ProgramMaxIndex.ToString();

        if (Programcmd == 1)
        {
            for (int i =(ProgramNowIndex-1)*8; i <ProgramNowIndex*8 ; i++)
            {
                Program_Array[i%8].GetComponent<ProgramPrefabData>().NumberText.text = (i + 1).ToString();
                Program_Array[i%8].GetComponent<ProgramPrefabData>().TitleText.text = Program1[0][i];
                Program_Array[i%8].GetComponent<ProgramPrefabData>().StartTimeText.text = Program1[2][i];
                Program_Array[i%8].GetComponent<ProgramPrefabData>().EndTimeText.text = Program1[3][i];
                Program_Array[i%8].GetComponent<ProgramPrefabData>().Code1 = 1;
                Program_Array[i%8].GetComponent<ProgramPrefabData>().Code2 = i;
            }
        }
        else if (Programcmd == 2)
        {
            for (int i =(ProgramNowIndex-1)*8; i <ProgramNowIndex*8 ; i++)
            {
                Program_Array[i%8].GetComponent<ProgramPrefabData>().NumberText.text = (i + 1).ToString();
                Program_Array[i%8].GetComponent<ProgramPrefabData>().TitleText.text = Program2[0][i];
                Program_Array[i%8].GetComponent<ProgramPrefabData>().StartTimeText.text = Program2[2][i];
                Program_Array[i%8].GetComponent<ProgramPrefabData>().EndTimeText.text = Program2[3][i];
                Program_Array[i%8].GetComponent<ProgramPrefabData>().Code1 = 2;
                Program_Array[i%8].GetComponent<ProgramPrefabData>().Code2 = i;
            }
        }
        else if (Programcmd == 3)
        {
            for (int i =(ProgramNowIndex-1)*8; i <ProgramNowIndex*8 ; i++)
            {
                Program_Array[i%8].GetComponent<ProgramPrefabData>().NumberText.text = (i + 1).ToString();
                Program_Array[i%8].GetComponent<ProgramPrefabData>().TitleText.text = Program3[0][i];
                Program_Array[i%8].GetComponent<ProgramPrefabData>().StartTimeText.text = Program3[2][i];
                Program_Array[i%8].GetComponent<ProgramPrefabData>().EndTimeText.text = Program3[3][i];
                Program_Array[i%8].GetComponent<ProgramPrefabData>().Code1 = 3;
                Program_Array[i%8].GetComponent<ProgramPrefabData>().Code2 = i;
            }
        }
        else if (Programcmd == 4)
        {
            for (int i =(ProgramNowIndex-1)*8; i <ProgramNowIndex*8 ; i++)
            {
                Program_Array[i%8].GetComponent<ProgramPrefabData>().NumberText.text = (i + 1).ToString();
                Program_Array[i%8].GetComponent<ProgramPrefabData>().TitleText.text = Program4[0][i];
                Program_Array[i%8].GetComponent<ProgramPrefabData>().StartTimeText.text = Program4[2][i];
                Program_Array[i%8].GetComponent<ProgramPrefabData>().EndTimeText.text = Program4[3][i];
                Program_Array[i%8].GetComponent<ProgramPrefabData>().Code1 = 4;
                Program_Array[i%8].GetComponent<ProgramPrefabData>().Code2 = i;
            }
        }
        else if (Programcmd == 5)
        {
            for (int i =(ProgramNowIndex-1)*8; i <ProgramNowIndex*8 ; i++)
            {
                Program_Array[i%8].GetComponent<ProgramPrefabData>().NumberText.text = (i + 1).ToString();
                Program_Array[i%8].GetComponent<ProgramPrefabData>().TitleText.text = Program5[0][i];
                Program_Array[i%8].GetComponent<ProgramPrefabData>().StartTimeText.text = Program5[2][i];
                Program_Array[i%8].GetComponent<ProgramPrefabData>().EndTimeText.text = Program5[3][i];
                Program_Array[i%8].GetComponent<ProgramPrefabData>().Code1 = 5;
                Program_Array[i%8].GetComponent<ProgramPrefabData>().Code2 = i;
            }
        }
    }
    //프로그램 리스트 다음 버튼 클릭 시
    public void NextProgramList()
    {
        if (Programcmd == 1)
            ProgramMaxIndex = (Program1[0].Count-1)/8+1;
        else if(Programcmd == 2)
            ProgramMaxIndex = (Program2[0].Count-1)/8+1;
        else if(Programcmd == 3)
            ProgramMaxIndex = (Program3[0].Count-1)/8+1;
        else if(Programcmd == 4)
            ProgramMaxIndex = (Program4[0].Count-1)/8+1;
        else 
            ProgramMaxIndex = (Program5[0].Count-1)/8+1;

        if (ProgramNowIndex < ProgramMaxIndex)
        {
            ProgramNowIndex++;
            LoadProgramListData();
        }
    }

    public void PreviousProgramList()
    {
         if (Programcmd == 1)
            ProgramMaxIndex = (Program1[0].Count-1)/8+1;
        else if(Programcmd == 2)
            ProgramMaxIndex = (Program2[0].Count-1)/8+1;
        else if(Programcmd == 3)
            ProgramMaxIndex = (Program3[0].Count-1)/8+1;
        else if(Programcmd == 4)
            ProgramMaxIndex = (Program4[0].Count-1)/8+1;
        else 
            ProgramMaxIndex = (Program5[0].Count-1)/8+1;

        if (ProgramNowIndex > 1)
        {
            ProgramNowIndex--;
            LoadProgramListData();
        }
    }
}
