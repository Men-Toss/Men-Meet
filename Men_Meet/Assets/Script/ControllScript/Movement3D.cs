using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement3D : MonoBehaviour
{
    Animator _animator;
    Camera _camera;
    CharacterController _controller;
    //중력 계수
    public float gravity = -9.8f; 
    //사용자 스피드
    public float speed = 5f;
    //플레이어 달리기 스피드
    public float runSpeed = 8f;
    //플레이어 최종 스피드
    public float finalSpeed;
    //주변 둘러보기 기능
    public bool toggleCameraRotation;
    //Smoothness : 부드러움 정도
    public float smoothness = 10f;
    //달리는지 체크 
    public bool isRun = false;
    public float jumpForce=20f;
    //땅에 닿았는지 체크
    public bool isGround = true;
    void Start()
    {
        _animator = this.GetComponent<Animator>();
        _camera=Camera.main;
        _controller = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //왼쪽 ALT 누를 시
        if (Input.GetKey(KeyCode.LeftAlt)) toggleCameraRotation = true;
        else toggleCameraRotation = false;
        //왼쪽 Shift 누를 시
        if (Input.GetKey(KeyCode.LeftShift)) isRun = true;
        else isRun = false;
        
        //매 프레임에 동작할 함수 실행
        InputMovement();
    }
    //업데이트 함수 실행 후 호출
    void LateUpdate()
    {
        //사용자가 ALt를 누르고 있다면
        if (!toggleCameraRotation) {
            Vector3 playerRotate = Vector3.Scale(_camera.transform.forward, new Vector3(1, 0, 1));
            transform.rotation=Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(playerRotate),Time.deltaTime*smoothness );
        }
    }

    void InputMovement()
    {
        
        //플레이어 스피드 결정
        finalSpeed = (isRun) ? runSpeed : speed;
        //움직임 구현
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        Vector3 movedDirection = forward * Input.GetAxisRaw("Vertical") + right * Input.GetAxisRaw("Horizontal");

        /*
        //SpaceBar 누를 시
        if (Input.GetKey(KeyCode.Space))
        {
            _animator.SetTrigger("Jumping");
            //movedDirection.y = jumpForce;
        }
        */
        //플레이어 중력 설정
        //movedDirection.y += gravity;
         
        
        _controller.Move(movedDirection.normalized * finalSpeed * Time.deltaTime);
       
        //Blend애니메이션
        float percent = ((isRun) ? 1f : 0.5f) * movedDirection.magnitude;
        _animator.SetFloat("Blend",percent,0.05f,Time.deltaTime);
    }
}