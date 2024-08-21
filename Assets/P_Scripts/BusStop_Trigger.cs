using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BusStop_Trigger : MonoBehaviour // �ε����� Busmove3 �� Busstop �Լ��� ���ؤ���������.
{

    public BusNav_Controller bus;


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bus"))
        {
            Debug.Log("������ ��ҽ��ϴ�.");
            BusNav_Controller bus = other.GetComponent<BusNav_Controller>();

            if (bus != null)
            {
                Debug.Log("������ ���ӽ�ŵ�ϴ�");
                bus.isBusRun = false;
                bus.BusStop();

            }
        }
       
    }


}
