using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusStop_Trigger : MonoBehaviour // �ε����� Busmove3 �� Busstop �Լ��� ���ؤ���������.
{

    public BusMove3 bus;


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        BusMove3 bus = other.GetComponent<BusMove3>();

        if(bus != null)
        {
            bus.BusStop();
        }
    }


}
