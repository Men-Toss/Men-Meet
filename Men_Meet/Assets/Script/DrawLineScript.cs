using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLineScript : MonoBehaviour
{
    public GameObject linePrefab;

    private LineRenderer lr;
    private List<Vector3> points = new List<Vector3>();
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject go = Instantiate(linePrefab);
            lr = go.GetComponent<LineRenderer>();
            points.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            lr.positionCount = 1;
            lr.SetPosition(0,points[0]);
        }
        else if(Input.GetMouseButton(0))
        {
            Vector2 pos=Camera.main.ScreenToWorldPoint((Input.mousePosition));
            lr.positionCount++;
            lr.SetPosition(lr.positionCount-1,pos);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            points.Clear();
        }
    }
}
