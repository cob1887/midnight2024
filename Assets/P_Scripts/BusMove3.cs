using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class BusMove3 : MonoBehaviour
    {
        [Header("버스조작변수")]
        public float acceleration = 10f; // 조작할때 가속속도
        public float steering = 5f;
        public float maxSpeed = 20f; // 버스 최대속도

        public float idleAcceleration = 2f; // 조작 없을때 버스의 가속속도
        public float currentSpeed; // 현재속도

        public float deceleration =155f; // 감속 속도
        public bool isBusRun;
 


        private Rigidbody rb;
        void Start()
        {
            rb = GetComponent<Rigidbody>();
           // rb.centerOfMass = new Vector3(0, -0.5f, 0); // 무게 중심을 조정하여 차량의 안정성 향상
            currentSpeed = 0;

        isBusRun = true; // 시작할때 버스런을 true로
        }

        void Update()
        {

        }
        void FixedUpdate()
        {
            // 입력 값 가져오기
            float moveInput = Input.GetAxis("Vertical"); // W/S 또는 방향키 상하
            float steerInput = Input.GetAxis("Horizontal"); // A/D 또는 방향키 좌우


            // 조금이라도 키보드에 입력이 된다면
            if(Mathf.Abs(moveInput) > 0.1f)
            {
                // 가속도 및 속도 제한
                Vector3 moveForce = transform.forward * moveInput * acceleration;

                if (rb.velocity.magnitude < maxSpeed) // rb.velocity = rigid body의 위치의 변화 비율을 말함
                {
                    rb.AddForce(moveForce , ForceMode.Acceleration);
                }

                       
            }
            // 입력값이 없을때 BusStart 함수 실행
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

            // 회전
            float steerAngle = steerInput * steering;
            Quaternion turnRotation = Quaternion.Euler(0, steerAngle, 0);

            rb.MoveRotation(rb.rotation * turnRotation);




        }


        // 버스가 출발
        public void BusStart()
        {
             // 현재속도에 정지가속 * 시간을 누적
             currentSpeed += idleAcceleration * Time.fixedDeltaTime;
             // 현재속도는 현재속도 ~ 정해진 max속도로 제한
             currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);

             Vector3 idleForce = transform.forward * (currentSpeed - rb.velocity.magnitude);
             rb.AddForce(idleForce, ForceMode.Acceleration); // 질량에 따라 자연스럽게 속도가 증가
        }



        // 버스가 감속하다가 정지
        public void BusStop()
        {
    

        Vector3 decelerationForce = -rb.velocity.normalized * deceleration;

        // 실제 힘을 적용하여 속도를 감소시킵니다.
        rb.AddForce(decelerationForce, ForceMode.Acceleration);

        // 속도가 0 이하로 떨어지지 않도록 제한합니다.
        if (rb.velocity.magnitude < 0.1f) // 거의 정지 상태로 간주
        {
            rb.velocity = Vector3.zero;
            currentSpeed = 0;
        }



        //if(currentSpeed < 5f)
        //{
        //    StartCoroutine(BusStartAgain(5f)); \버스 정지조건을 하고 고쳐야함 개같은 코루틴
        //}
    }




    //// 만약, AI가 사람을 인식했다면 여기에 코드 입력
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

