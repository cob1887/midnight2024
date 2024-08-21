using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BusNav_Controller : MonoBehaviour
{
   
    public Transform[] destinations;
    private int currentDestinationIndex = 0; // ���� ������ �ε���
    public float stoppingDistance = 1.0f; // ���� �Ǻ� �Ÿ�

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
        // �������� �����ߴ��� Ȯ��
        if (agent.remainingDistance <= stoppingDistance && !agent.pathPending)
        {
            // ���� �������� �̵�
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
