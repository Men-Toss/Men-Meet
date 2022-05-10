using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class Movement3D : MonoBehaviour
{
    //유저 현재 상태 스크립트
    private UserStateScript _stateScript;
    //메테리얼 배열
    public Material[] charTexture = new Material[18];
    //현재 선택인덱스  
    public int selectedChar = 0;
    Animator _animator;
    Camera _camera;
    CharacterController _controller;
    //포톤 뷰
    public PhotonView PV;
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
    private bool IsCheckGrounded()
    {
        // CharacterController.IsGrounded가 true라면 Raycast를 사용하지 않고 판정 종료
        if (_controller.isGrounded) return true;
        // 발사하는 광선의 초기 위치와 방향
        // 약간 신체에 박혀 있는 위치로부터 발사하지 않으면 제대로 판정할 수 없을 때가 있다.
        var ray = new Ray(this.transform.position + Vector3.up * 0.1f, Vector3.down);
        // 탐색 거리
        var maxDistance = 1.3f;
        // 광선 디버그 용도
        Debug.DrawRay(transform.position + Vector3.up * 0.1f, Vector3.down * maxDistance, Color.blue);
        // Raycast의 hit 여부로 판정
        // 지상에만 충돌로 레이어를 지정
        return Physics.Raycast(ray, maxDistance, 3);
    }
    void Start()
    {
        _animator = this.GetComponent<Animator>();
        _camera=Camera.main;
        _controller = this.GetComponent<CharacterController>();
        if (PV.IsMine)
        {
            Invoke("LOAD",2f);
        }
        
    }
    
    public void LOAD()=>
    PV.RPC("LOADCHAR",RpcTarget.AllBuffered);

    
    void Update()
    {
        if (PV.IsMine)
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
    [PunRPC]
    void InputMovement()
    {
        
        //플레이어 스피드 결정
        finalSpeed = (isRun) ? runSpeed : speed;
        //움직임 구현
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        Vector3 movedDirection = forward * Input.GetAxisRaw("Vertical") + right * Input.GetAxisRaw("Horizontal");

    //Debug.Log(IsCheckGrounded());
        
        //SpaceBar 누를 시
        if (Input.GetKey(KeyCode.Space))
        {
            _animator.SetTrigger("Jumping");
            //movedDirection.y = jumpForce;
        }
        
        //플레이어 중력 설정
       // movedDirection.y += gravity;
         
        _controller.Move(movedDirection.normalized * finalSpeed * Time.deltaTime);
       
        //Blend애니메이션
        float percent = ((isRun) ? 1f : 0.5f) * movedDirection.magnitude;
        _animator.SetFloat("Blend",percent,0.05f,Time.deltaTime);
    }
    
    [PunRPC]
    public void LOADCHAR()
    {
        //Debug.Log("loadChar실행됨"+_stateScript.userCharCode.ToString()+" "+_stateScript.userSkin.ToString()+" "+_stateScript.userCloth);
        _stateScript = GameObject.Find("UserManager").GetComponent<UserStateScript>();
        loadCharactor(_stateScript.userCharCode,_stateScript.userSkin,_stateScript.userCloth);
        //GameObject.Find("Camera").GetComponent<CameraMovement>().objectTofollow =
        //    gameObject.transform;       
    }
     //메타버스 월드 처음 입장 시 캐릭터 정보 
    public void loadCharactor(string charCode,int skin,int cloth)
    {
        for (int i = 0; i <= 36; i++)
        {
            this.transform.GetChild(i).gameObject.SetActive(false);
        } 
        if (charCode[0].Equals('M'))
        {
            switch (int.Parse(charCode.Substring(1)))
            {
                case 0:
                    this.transform.GetChild(0).gameObject.SetActive(true);
                    selectedChar = 0;break;
                case 1:
                    this.transform.GetChild(1).gameObject.SetActive(true); 
                    selectedChar = 1;break;
                case 2:
                    this.transform.GetChild(2).gameObject.SetActive(true);
                    selectedChar = 2;break;
                case 3:
                    this.transform.GetChild(5).gameObject.SetActive(true);
                    selectedChar = 5;break;
                case 4:
                    this.transform.GetChild(6).gameObject.SetActive(true); 
                    selectedChar = 6;break;
                case 5:
                    this.transform.GetChild(7).gameObject.SetActive(true); 
                    selectedChar = 7;break;
                case 6:
                    this.transform.GetChild(13).gameObject.SetActive(true); 
                    selectedChar = 13;break;
                case 7:
                    this.transform.GetChild(15).gameObject.SetActive(true); 
                    selectedChar = 15;break;
                case 8:
                    this.transform.GetChild(17).gameObject.SetActive(true);
                    selectedChar = 17;break;
                case 9:
                    this.transform.GetChild(18).gameObject.SetActive(true); 
                    selectedChar = 18;break;
                case 10:
                    this.transform.GetChild(21).gameObject.SetActive(true);
                    selectedChar = 21;break;
                case 11:
                    this.transform.GetChild(22).gameObject.SetActive(true); 
                    selectedChar = 22;break;
                case 12:
                    this.transform.GetChild(20).gameObject.SetActive(true); 
                    selectedChar =20;break;
                case 13:
                    this.transform.GetChild(26).gameObject.SetActive(true); 
                    selectedChar = 26;break;
                case 14:
                    this.transform.GetChild(28).gameObject.SetActive(true); 
                    selectedChar = 28;break;
                case 15:
                    this.transform.GetChild(29).gameObject.SetActive(true);
                    selectedChar = 29;break;
                case 16:
                    this.transform.GetChild(30).gameObject.SetActive(true); 
                    selectedChar = 30;break;
                case 17:
                    this.transform.GetChild(36).gameObject.SetActive(true);
                    selectedChar = 36;break;
                    
            }
        }
        else
        {
            switch (int.Parse(charCode.Substring(1)))
            {
                case 0:
                    this.transform.GetChild(3).gameObject.SetActive(true); 
                    selectedChar = 3;break;
                case 1:
                    this.transform.GetChild(4).gameObject.SetActive(true); 
                    selectedChar = 4;break;
                case 2:
                    this.transform.GetChild(8).gameObject.SetActive(true); 
                    selectedChar = 8;break;
                case 3:
                    this.transform.GetChild(9).gameObject.SetActive(true); 
                    selectedChar = 9;break;
                case 4:
                    this.transform.GetChild(10).gameObject.SetActive(true); 
                    selectedChar = 10;break;
                case 5:
                    this.transform.GetChild(12).gameObject.SetActive(true); 
                    selectedChar = 12;break;
                case 6:
                    this.transform.GetChild(14).gameObject.SetActive(true); 
                    selectedChar = 14;break;
                case 7:
                    this.transform.GetChild(16).gameObject.SetActive(true); 
                    selectedChar = 16;break;
                case 8:
                    this.transform.GetChild(24).gameObject.SetActive(true);
                    selectedChar = 24;break;
                case 9:
                    this.transform.GetChild(25).gameObject.SetActive(true); 
                    selectedChar = 25;break;
                case 10:
                    this.transform.GetChild(31).gameObject.SetActive(true); 
                    selectedChar = 31;break;
                case 11:
                    this.transform.GetChild(35).gameObject.SetActive(true); 
                    selectedChar = 35;break;

            }
        }
        
        Debug.Log(skin+"번스킨 + "+cloth+"번 의상");
        this.transform.GetChild(selectedChar).gameObject
            .GetComponent<SkinnedMeshRenderer>().material = charTexture[cloth * 3 + skin];
    }
}