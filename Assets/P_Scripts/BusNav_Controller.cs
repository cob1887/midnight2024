using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;

public class BusNav_Controller : MonoBehaviour
{
   
    public Transform[] destinations;
    private int currentDestinationIndex = 0; // ���� ������ �ε���
    public float stoppingDistance = 1.0f; // ���� �Ǻ� �Ÿ�


    public float acceleration = 10f; // ���ӵ�
    public float deceleration = 155f; // ���� �ӵ�
    public float maxSpeed = 20f; // �ִ� �ӵ�

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


        // �ʱ� �ӵ� ����
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
        // �������� �����ߴ��� Ȯ��
        if (agent.remainingDistance <= stoppingDistance && !agent.pathPending)
        {
            // ���� �������� �̵�
            currentDestinationIndex = (currentDestinationIndex + 1) % destinations.Length;
            SetDestination();
        }

        // ���� �� ���� ó��
        if (isBusRun)
        {
            MoveBus();
        }
        else if (isBusRun == false)
        {
            BusStop();
        }






    }
    // ���� ������
    void MoveBus()
    {
        // ���� �ӵ� ����
        currentSpeed += acceleration * Time.deltaTime;
        currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);
        agent.speed = currentSpeed;
    }

    public void BusStop()
    {
        // ���� ó��
        currentSpeed -= deceleration * Time.deltaTime;
        currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);
        agent.speed = currentSpeed;

        // �ӵ��� ���� 0�� �����ϸ� ����
        if (currentSpeed < 0.1f)
        {
            currentSpeed = 0;
            agent.speed = 0;
            agent.isStopped = true; // NavMeshAgent�� ���߰� ��
            //isBusRun = false; // ������ ���� ���·� ����
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
