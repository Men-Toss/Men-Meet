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
}
