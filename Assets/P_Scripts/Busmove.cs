using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Busmove : MonoBehaviour //버스의 움직임
{
    [Header("버스 속도변수")]
    float maxSpeed = 60f;
    float currentSpeed;
    float accelTime = 5f; // 5초     
    float deaccelTime = 5f;
    float accelRate;
    float deaccelRate;



    private CharacterController cc;
    private Rigidbody rb;
    
    
    void Start()
    {
        cc = GetComponent<CharacterController>();
        rb = gameObject.GetComponent<Rigidbody>();

        accelRate = maxSpeed / accelTime;

        deaccelRate = currentSpeed / deaccelTime;

        currentSpeed = 0f;
    }



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentSpeed = 0;
        }


       
        BusStart();


    }




    public void BusStart()
    {
        //만약, 현재속도가 최대속도보다 작다면
        if (currentSpeed < maxSpeed)
        {
            //가속 비율과 시간을 곱해서 누적시킨다
            currentSpeed += accelRate * Time.deltaTime;


            if (currentSpeed > maxSpeed)
            {
                currentSpeed = maxSpeed;
            }

        }

        //float meterpersecond = currentSpeed / 3.6f;

        Vector3 movedir = Vector3.forward * Time.deltaTime;


        cc.Move(movedir * currentSpeed);
        movedir = movedir.normalized;

        
    }



    // 사람을 보면 감속하다가 정지
    public void BusStop() 
    {
        // ai가 사람을 인식했다면
        currentSpeed -= deaccelTime * Time.deltaTime;



        Invoke("BusStart", 5f);
    }



}
