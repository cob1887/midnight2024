using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusSlow_Tirgger : MonoBehaviour // ������ ������ �ִ�ӵ��� n������ ���̴� Ʈ���� �ڽ�
{

    BusMove3 bus;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        bus = other.GetComponent<BusMove3>();

        if (bus != null)
        {
            bus.maxSpeed = 20;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        bus = other.GetComponent<BusMove3>();

        if (bus != null)
        {
            bus.maxSpeed = 50;
        }
    }
}
