using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharChoosePrefab : MonoBehaviour
{
   public Image image;
   public string code;
   public void setImg(Sprite sprite) => image.sprite = sprite;
   public void setCode(string s) => code = s;
}
