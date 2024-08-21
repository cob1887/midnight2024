using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BusNav_Controller : MonoBehaviour
{
   
    public Transform[] destinations;
    private int currentDestinationIndex = 0; // 현재 목적지 인덱스
    public float stoppingDistance = 1.0f; // 도착 판별 거리

    public NavMeshAgent agent;
    void Start()
    {

        agent = GetComponent<NavMeshAgent>();

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
