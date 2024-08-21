using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusSlow_Tirgger : MonoBehaviour // 버스가 닿으면 최대속도를 n값으로 줄이는 트리거 박스
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
