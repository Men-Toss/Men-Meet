using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingTextScript : MonoBehaviour
{
    [SerializeField] Text LoadingMainText;

    void Start() => Invoke("PlusMain", 0.25f);
    public void PlusMain()
    {
        LoadingMainText.text += ".";

        if (LoadingMainText.text.Equals("������.....")) 
        LoadingMainText.text = "������.";

        Invoke("PlusMain", 0.25f);   
    }
    public void StopAni(){
        CancelInvoke();
    }
}
