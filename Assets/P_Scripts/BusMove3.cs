using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class BusMove3 : MonoBehaviour
    {
        [Header("�������ۺ���")]
        public float acceleration = 10f; // �����Ҷ� ���Ӽӵ�
        public float steering = 5f;
        public float maxSpeed = 20f; // ���� �ִ�ӵ�

        public float idleAcceleration = 2f; // ���� ������ ������ ���Ӽӵ�
        public float currentSpeed; // ����ӵ�

        public float deceleration =155f; // ���� �ӵ�
        public bool isBusRun;
 


        private Rigidbody rb;
        void Start()
        {
            rb = GetComponent<Rigidbody>();
           // rb.centerOfMass = new Vector3(0, -0.5f, 0); // ���� �߽��� �����Ͽ� ������ ������ ���
            currentSpeed = 0;

        isBusRun = true; // �����Ҷ� �������� true��
        }

        void Update()
        {

        }
        void FixedUpdate()
        {
            // �Է� �� ��������
            float moveInput = Input.GetAxis("Vertical"); // W/S �Ǵ� ����Ű ����
            float steerInput = Input.GetAxis("Horizontal"); // A/D �Ǵ� ����Ű �¿�


            // �����̶� Ű���忡 �Է��� �ȴٸ�
            if(Mathf.Abs(moveInput) > 0.1f)
            {
                // ���ӵ� �� �ӵ� ����
                Vector3 moveForce = transform.forward * moveInput * acceleration;

                if (rb.velocity.magnitude < maxSpeed) // rb.velocity = rigid body�� ��ġ�� ��ȭ ������ ����
                {
                    rb.AddForce(moveForce , ForceMode.Acceleration);
                }

                       
            }
            // �Է°��� ������ BusStart �Լ� ����
            else if(rb.velocity.magnitude < maxSpeed)
            {
                if(isBusRun == true)
            {
                BusStart();
            }

                                  
                          
          
            }

        if (isBusRun == false)
        {
            BusStop();
        }

            // ȸ��
            float steerAngle = steerInput * steering;
            Quaternion turnRotation = Quaternion.Euler(0, steerAngle, 0);

            rb.MoveRotation(rb.rotation * turnRotation);




        }


        // ������ ���
        public void BusStart()
        {
             // ����ӵ��� �������� * �ð��� ����
             currentSpeed += idleAcceleration * Time.fixedDeltaTime;
             // ����ӵ��� ����ӵ� ~ ������ max�ӵ��� ����
             currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);

             Vector3 idleForce = transform.forward * (currentSpeed - rb.velocity.magnitude);
             rb.AddForce(idleForce, ForceMode.Acceleration); // ������ ���� �ڿ������� �ӵ��� ����
        }



        // ������ �����ϴٰ� ����
        public void BusStop()
        {
    

        Vector3 decelerationForce = -rb.velocity.normalized * deceleration;

        // ���� ���� �����Ͽ� �ӵ��� ���ҽ�ŵ�ϴ�.
        rb.AddForce(decelerationForce, ForceMode.Acceleration);

        // �ӵ��� 0 ���Ϸ� �������� �ʵ��� �����մϴ�.
        if (rb.velocity.magnitude < 0.1f) // ���� ���� ���·� ����
        {
            rb.velocity = Vector3.zero;
            currentSpeed = 0;
        }



        //if(currentSpeed < 5f)
        //{
        //    StartCoroutine(BusStartAgain(5f)); \���� ���������� �ϰ� ���ľ��� ������ �ڷ�ƾ
        //}
    }




    //// ����, AI�� ����� �ν��ߴٸ� ���⿡ �ڵ� �Է�
    //{
    //    BusStop();
    // }








    //private IEnumerator BusStartAgain(float time)
    //{
    //    yield return new WaitForSeconds(time);

    //    BusStart();

    //   isBusStop = false;
    //}






}

