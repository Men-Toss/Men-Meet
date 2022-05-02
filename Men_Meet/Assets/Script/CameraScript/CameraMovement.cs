using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //팔로우 할 오브젝트
    public Transform objectTofollow;
    //카메라 스피드
    public float followSpeed=10f;
    //카메라 민감도
    public float sensitivity=100f;
    //카메라 각도
    public float clampAngle=70f;
    //카메로 방향 X/Y
    private float rotX;
    private float rotY;
    //카메라 위치
    public Transform realCamera;
    //카메라 일반 위치
    public Vector3 dirNormalized;
    //카메라 최종 위치
    public Vector3 finalDir;
    //최소거리
    public float minDistance;
    //최대거리
    public float maxDistance;
    //최종거리
    public float finalDistance;
    //부드러운 정도
    public float smoothness=10f;
    void Start()
    {
        //카메라 방향은 초기화
        rotX = transform.localRotation.eulerAngles.x;
        rotY = transform.localRotation.eulerAngles.y;
        
        //카메라 오브젝트의 위치(Position)를  초기화(방향X)
        dirNormalized = realCamera.localPosition.normalized;
        finalDistance = realCamera.localPosition.magnitude;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        //마우스 X / Y축 값 입력받음
        rotX += -1 * (Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime);
        rotY += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX ,- clampAngle, clampAngle);
        
        //쿼터니언 설정
        Quaternion rot=Quaternion.Euler(rotX,rotY,0);
        transform.rotation = rot;
    }
    //업데이트 끝난 다음에 실행됨
    private void LateUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, objectTofollow.position, followSpeed);
        finalDir = transform.TransformPoint(dirNormalized * maxDistance);
        
        //물체가 있는지 확인을 위해 RaycastHit 활용
        RaycastHit hit;
        if (Physics.Linecast(transform.position, finalDir, out hit))
            finalDistance = Mathf.Clamp(hit.distance, minDistance, maxDistance);
        else
            finalDistance = maxDistance;

        realCamera.localPosition = Vector3.Lerp(realCamera.localPosition,dirNormalized*finalDistance,Time.deltaTime*smoothness);
    }
}
