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
        // �Է� �� ��������
        float moveInput = Input.GetAxis("Vertical"); // W/S �Ǵ� ����Ű ����
        float steerInput = Input.GetAxis("Horizontal"); // A/D �Ǵ� ����Ű �¿�

        // ���ӵ� �� �ӵ� ����
        Vector3 moveForce = transform.forward * moveInput * acceleration;
        if (rb.velocity.magnitude < maxSpeed)
        {
            rb.AddForce(moveForce);
        }

        // ȸ��
        float steerAngle = steerInput * steering;
        Quaternion turnRotation = Quaternion.Euler(0, steerAngle, 0);
        rb.MoveRotation(rb.rotation * turnRotation);
    }


}

