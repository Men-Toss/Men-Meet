using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSoundScript : MonoBehaviour
{
    public AudioSource _Audio;
    public Slider _Slider;

    public void Update()
    {
        _Audio.volume = _Slider.value;
    }
}
