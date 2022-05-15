using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookCam : MonoBehaviour
{
    public GameObject Cam;

    private void Start()
    {

        Cam=GameObject.Find("Camera");
    }

    void Update()
    {
        transform.rotation = Cam.transform.rotation;
        
    }
}
