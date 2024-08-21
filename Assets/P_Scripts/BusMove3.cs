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

       
        private Rigidbody rb;
        void Start()
        {
            rb = GetComponent<Rigidbody>();
            rb.centerOfMass = new Vector3(0, -0.5f, 0); // ���� �߽��� �����Ͽ� ������ ������ ���
            currentSpeed = 0;
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
                BusStart();
          
            }



            // ȸ��
            float steerAngle = steerInput * steering;
            Quaternion turnRotation = Quaternion.Euler(0, steerAngle, 0);

            rb.MoveRotation(rb.rotation * turnRotation);



            //// ����, AI�� ����� �ν��ߴٸ� ���⿡ �ڵ� �Է�
            //{
            //    BusStop();
            // }


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
            // �ӵ��� ���� ����
           currentSpeed -= deceleration * Time.fixedDeltaTime;
           // ����ӵ��� �ִ�ӵ��� 0���� ����(��������)
           currentSpeed = Mathf.Max(currentSpeed, 0);

           float stopSpeed = currentSpeed - -rb.velocity.magnitude;
           Vector3 idleForce = transform.forward * stopSpeed;

           rb.AddForce(idleForce, ForceMode.Acceleration);

           //if(currentSpeed < 5f)
           //{
           //    StartCoroutine(BusStartAgain(5f)); \���� ���������� �ϰ� ���ľ��� ������ �ڷ�ƾ
           //}
         }











    //private IEnumerator BusStartAgain(float time)
    //{
    //    yield return new WaitForSeconds(time);

    //    BusStart();

    //   isBusStop = false;
    //}






}

