using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusStop_Trigger : MonoBehaviour // 부딪히면 Busmove3 의 Busstop 함수를 실해ㅇㅎㅏㄴ다.
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
