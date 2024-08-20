using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Busmove : MonoBehaviour //������ ������
{
    [Header("���� �ӵ�����")]
    float maxSpeed = 60f;
    float currentSpeed;
    float accelTime = 5f; // 5��     
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
        //����, ����ӵ��� �ִ�ӵ����� �۴ٸ�
        if (currentSpeed < maxSpeed)
        {
            //���� ������ �ð��� ���ؼ� ������Ų��
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



    // ����� ���� �����ϴٰ� ����
    public void BusStop() 
    {
        // ai�� ����� �ν��ߴٸ�
        currentSpeed -= deaccelTime * Time.deltaTime;



        Invoke("BusStart", 5f);
    }



}
