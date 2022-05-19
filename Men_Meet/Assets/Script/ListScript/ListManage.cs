using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListManage : MonoBehaviour
{
    public IntroducePrefabData IPD;
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
        
        
        
    }
}
