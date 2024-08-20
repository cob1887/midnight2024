using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusMove2 : MonoBehaviour // �� �ݶ��̴� ����
{
    //public WheelCollider[] wheelColliders;
    //public Transform[] wheelTransforms;
    //public float maxTorque = 200f; // �ֵ��ӵ�
    //public float maxSteerAngle = 30f; // ������ 30��
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

        ApplySteering(steer); // ������ �¿� ȸ����
        ApplyTorque(torque);  // ������ ��ũ��(����)
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




//// ���� ������
//float moveInput = Input.GetAxis("Vertical");
//float steerInput = Input.GetAxis("Horizontal");


//for (int i = 0; i < wheelColliders.Length; i++)
//{
//    // �� �ݶ��̴��� ���� ������
//    wheelColliders[i].motorTorque = moveInput * maxTorque;
//}
//// �¿� �չ����� ȸ������
//wheelColliders[0].steerAngle = steerInput * maxSteerAngle; // �չ��� ��
//wheelColliders[1].steerAngle = steerInput * maxSteerAngle; // �չ��� ��



//// ����, �����̽��ٸ� �����ٸ�
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
//    // ������ ����ĳ��Ʈ
//    WheelHit hit; // �ٰ� ��������� ��ȣ�ۿ�

//    // ������ ����� ����ִ��� Ȯ��
//    if (wheelColliders[i].GetGroundHit(out hit))
//    {
//        wheelTransforms[i].position = hit.point;
//        wheelTransforms[i].rotation = Quaternion.LookRotation(transform.forward, hit.normal);

//    }


//}
    
