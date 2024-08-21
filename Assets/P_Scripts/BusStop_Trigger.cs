using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BusStop_Trigger : MonoBehaviour // 부딪히면 Busmove3 의 Busstop 함수를 실해ㅇㅎㅏㄴ다.
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
            Debug.Log("버스가 닿았습니다.");
            BusNav_Controller bus = other.GetComponent<BusNav_Controller>();

            if (bus != null)
            {
                Debug.Log("버스를 감속시킵니다");
                bus.isBusRun = false;
                bus.BusStop();

            }
        }
       
    }


}
