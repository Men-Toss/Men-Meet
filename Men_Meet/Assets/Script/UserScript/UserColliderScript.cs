using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserColliderScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        LoadingButtonManage LBM = GameObject.Find("ButtonManager").GetComponent<LoadingButtonManage>();
        string triggerTag = other.transform.tag;
        LBM.Intro_Pro_btnShow();
        if (triggerTag.Equals("Introduce_1"))
            LBM.Intro_Pro_btnSetText("학과 소개");
        else if (triggerTag.Equals("Introduce_2"))
            LBM.Intro_Pro_btnSetText("부처 소개");
        else if (triggerTag.Equals("Introduce_3"))
            LBM.Intro_Pro_btnSetText("건물 소개");
        else if (triggerTag.Equals("Introduce_4"))
            LBM.Intro_Pro_btnSetText("동아리 소개");
        else if (triggerTag.Equals("Program_1"))
            LBM.Intro_Pro_btnSetText("교과 프로그램");
        else if (triggerTag.Equals("Program_2"))
            LBM.Intro_Pro_btnSetText("비교과 프로그램");
        else if (triggerTag.Equals("Program_3"))
            LBM.Intro_Pro_btnSetText("학과 프로그램");
        else if (triggerTag.Equals("Program_4"))
            LBM.Intro_Pro_btnSetText("기타 프로그램");
        else if (triggerTag.Equals("Program_5"))
            LBM.Intro_Pro_btnSetText("자주 묻는 질문");
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit");
        GameObject.Find("ButtonManager").GetComponent<LoadingButtonManage>().Intro_Pro_btnHide();
    }
}
