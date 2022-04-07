using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement3D : MonoBehaviour
{
    //ĳ���� ���ǵ�
    [SerializeField] private float moveSpeed = 5.0f;
    //ĳ���� �̵� ����
    private Vector3 moveDirection;
    private CharacterController CC;
    [SerializeField] private float gravity = -5.0f;
    private void Awake() => CC = GetComponent<CharacterController>();
    
    void Update()
    {
        if (CC.isGrounded == false)
            moveDirection.y += gravity * Time.deltaTime;

        CC.Move(moveDirection * moveSpeed * Time.deltaTime);
    }
    public void MoveTo(Vector3 direction)
    {
        moveDirection = new Vector3(direction.x, moveDirection.y, direction.z);
    }
}
