using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgramPrefabData : MonoBehaviour
{
    public Text NumberText;
    public Text TitleText;
    public Text StartTimeText;
    public Text EndTimeText;
    public int Code1;
    public int Code2;
    public void setColor(Color c)=>gameObject.GetComponent<Image>().color = c;

    public void ClickthisPrefab()
    {
        GameObject.Find("ButtonManager").GetComponent<LoadingButtonManage>()
            .ClickProgramPrefab(Code1,Code2);
    }
}
