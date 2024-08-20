using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human_Trigger : MonoBehaviour // 이 투명 박스에 부딪히면 사람이 튀어나온다
{
    public GameObject bus;
    private CharacterController cc;
    public float humanRunSpeed;

    void Start()
    {
        Busmove bus = GetComponent<Busmove>();

        humanRunSpeed = 15f;

    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name.Contains("Bus"))
        {
            HumanRun();
        }

    }

    public void HumanRun()
    {
        cc = GetComponent<CharacterController>();

        Vector3 humandir = Vector3.forward * Time.deltaTime;

        cc.Move(humandir * humanRunSpeed);
    }




}
