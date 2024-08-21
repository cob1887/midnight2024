using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;

public class BusNav_Controller : MonoBehaviour
{
   
    public Transform[] destinations;
    private int currentDestinationIndex = 0; // 현재 목적지 인덱스
    public float stoppingDistance = 1.0f; // 도착 판별 거리


    public float acceleration = 10f; // 가속도
    public float deceleration = 155f; // 감속 속도
    public float maxSpeed = 20f; // 최대 속도

    public NavMeshAgent agent;
    private float currentSpeed;
    public bool isBusRun;
    void Start()
    {

        agent = GetComponent<NavMeshAgent>();

        if (destinations.Length > 0) 
        {
            SetDestination();
        }


        // 초기 속도 설정
        agent.speed = 0;
        currentSpeed = 0;
        isBusRun = true;

        if (destinations.Length > 0)
        {
            SetDestination();
        }
    }

    void Update()   
    {
        // 목적지에 도착했는지 확인
        if (agent.remainingDistance <= stoppingDistance && !agent.pathPending)
        {
            // 다음 목적지로 이동
            currentDestinationIndex = (currentDestinationIndex + 1) % destinations.Length;
            SetDestination();
        }

        // 감속 및 정지 처리
        if (isBusRun)
        {
            MoveBus();
        }
        else if (isBusRun == false)
        {
            BusStop();
        }






    }
    // 버스 움직임
    void MoveBus()
    {
        // 현재 속도 설정
        currentSpeed += acceleration * Time.deltaTime;
        currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);
        agent.speed = currentSpeed;
    }

    public void BusStop()
    {
        // 감속 처리
        currentSpeed -= deceleration * Time.deltaTime;
        currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);
        agent.speed = currentSpeed;

        // 속도가 거의 0에 도달하면 정지
        if (currentSpeed < 0.1f)
        {
            currentSpeed = 0;
            agent.speed = 0;
            agent.isStopped = true; // NavMeshAgent를 멈추게 함
            //isBusRun = false; // 버스가 정지 상태로 설정
        }
    }

    // 
    void SetDestination()
    {
        if (destinations.Length > 0)
        {
            agent.SetDestination(destinations[currentDestinationIndex].position);
        }
    }
}
