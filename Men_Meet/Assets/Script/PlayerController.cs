using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Movement3D movement3D;
    void Update()
    {
        //x축, y축 입력
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        movement3D.MoveTo(new Vector3(x, 0, z));
    }
}
