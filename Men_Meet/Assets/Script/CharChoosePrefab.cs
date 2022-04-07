using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharChoosePrefab : MonoBehaviour
{
   public Image image;
    public int Code;
    public void SetImg(Sprite sprite) => image.sprite = sprite;
}
