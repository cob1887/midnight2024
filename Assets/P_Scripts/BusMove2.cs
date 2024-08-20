using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusMove2 : MonoBehaviour // 휠 콜라이더 쓰기
{
    //public WheelCollider[] wheelColliders;
    //public Transform[] wheelTransforms;
    //public float maxTorque = 200f; // 최도속도
    //public float maxSteerAngle = 30f; // 각도는 30도
    //public float brakeTorque = 3000f;

    public WheelCollider frontLeftWheel;
    public WheelCollider frontRightWheel;
    public WheelCollider rearLeftWheel;
    public WheelCollider rearRightWheel;

    public Transform frontLeftWheelMesh;
    public Transform frontRightWheelMesh;
    public Transform rearLeftWheelMesh;
    public Transform rearRightWheelMesh;

    public float maxTorque = 1000f;
    public float maxSteerAngle = 30f;

    Rigidbody rb;

    void Start()
    {
       rb = GetComponent<Rigidbody>();

        rb.mass = 50f;

    }

    void Update()
    {
        float steer = Input.GetAxis("Horizontal") * maxSteerAngle;
        float torque = Input.GetAxis("Vertical") * maxTorque;

        ApplySteering(steer); // 바퀴의 좌우 회전값
        ApplyTorque(torque);  // 바퀴의 토크값(전후)
        UpdateWheelMeshes();
    }


    private void ApplySteering(float steerAngle)
    {
        frontLeftWheel.steerAngle = steerAngle;
        frontRightWheel.steerAngle = steerAngle;

    }


    private void ApplyTorque(float torque)
    {
        frontLeftWheel.motorTorque = torque;
        frontRightWheel.motorTorque = torque;
    }

    private void UpdateWheelMeshes()
    {
        UpdateWheelMesh(frontLeftWheel, frontLeftWheelMesh);
        UpdateWheelMesh(frontRightWheel, frontRightWheelMesh);
        UpdateWheelMesh(rearLeftWheel, rearLeftWheelMesh);
        UpdateWheelMesh(rearRightWheel, rearRightWheelMesh);


    }

    private void UpdateWheelMesh(WheelCollider wheelCollider, Transform wheelMesh)
    {
        Vector3 position;
        Quaternion rotation;
        wheelCollider.GetWorldPose(out position, out rotation);
        
        wheelMesh.position = position;
        wheelMesh.rotation = rotation;  

    }


}




//// 버스 움직임
//float moveInput = Input.GetAxis("Vertical");
//float steerInput = Input.GetAxis("Horizontal");


//for (int i = 0; i < wheelColliders.Length; i++)
//{
//    // 휠 콜라이더의 정면 움직임
//    wheelColliders[i].motorTorque = moveInput * maxTorque;
//}
//// 좌우 앞바퀴의 회전각도
//wheelColliders[0].steerAngle = steerInput * maxSteerAngle; // 앞바퀴 좌
//wheelColliders[1].steerAngle = steerInput * maxSteerAngle; // 앞바퀴 우



//// 만약, 스페이스바를 누른다면
//if (Input.GetKeyDown(KeyCode.Space))
//{
//    for (int i = 0; i < wheelColliders.Length; i++)
//    {
//        wheelColliders[i].brakeTorque = brakeTorque;
//    }
//}
//else
//{
//    for (int i = 0; i < wheelColliders.Length; i++)
//    {
//        wheelColliders[i].brakeTorque = 0;
//    }
//}

//for (int i = 0; i < wheelColliders.Length; i++)
//{
//    // 바퀴의 레이캐스트
//    WheelHit hit; // 휠과 지면사이의 상호작용

//    // 바퀴가 지면과 닿아있는지 확인
//    if (wheelColliders[i].GetGroundHit(out hit))
//    {
//        wheelTransforms[i].position = hit.point;
//        wheelTransforms[i].rotation = Quaternion.LookRotation(transform.forward, hit.normal);

//    }


//}
    
