using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroducePrefabData : MonoBehaviour
{
    public Text MainText;
    public Text SubText;
    public int Code1;
    public int Code2;
    public void setColor(Color c)=>gameObject.GetComponent<Image>().color = c;

    public void ClickThisIntroducePrefab()
    {
        if (this.Code1 == 1 && this.Code2 == 0)
            GameObject.Find("ButtonManager").GetComponent<LoadingButtonManage>().ClickIntroduceImage(0);
        if (this.Code1 == 1 && this.Code2 == 1)
            GameObject.Find("ButtonManager").GetComponent<LoadingButtonManage>().ClickIntroduceImage(1);
        if (this.Code1 == 2 && this.Code2 == 0)
            GameObject.Find("ButtonManager").GetComponent<LoadingButtonManage>().ClickIntroduceImage(2);
        if (this.Code1 == 2 && this.Code2 == 1)
            GameObject.Find("ButtonManager").GetComponent<LoadingButtonManage>().ClickIntroduceImage(3);
        if (this.Code1 == 3 && this.Code2 == 0)
            GameObject.Find("ButtonManager").GetComponent<LoadingButtonManage>().ClickIntroduceImage(4);
        if (this.Code1 == 4 && this.Code2 == 0)
            GameObject.Find("ButtonManager").GetComponent<LoadingButtonManage>().ClickIntroduceImage(5);
    }
}
