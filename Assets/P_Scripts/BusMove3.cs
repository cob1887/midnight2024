using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusMove3 : MonoBehaviour
{
    public float acceleration = 10f;
    public float steering = 5f;
    public float maxSpeed = 20f;

    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0, -0.5f, 0);
    }

    void Update()
    {
        
    }
    void FixedUpdate()
    {
        // 입력 값 가져오기
        float moveInput = Input.GetAxis("Vertical"); // W/S 또는 방향키 상하
        float steerInput = Input.GetAxis("Horizontal"); // A/D 또는 방향키 좌우

        // 가속도 및 속도 제한
        Vector3 moveForce = transform.forward * moveInput * acceleration;
        if (rb.velocity.magnitude < maxSpeed)
        {
            rb.AddForce(moveForce);
        }

        // 회전
        float steerAngle = steerInput * steering;
        Quaternion turnRotation = Quaternion.Euler(0, steerAngle, 0);
        rb.MoveRotation(rb.rotation * turnRotation);
    }


}

