using System.Collections;
using System;
using UnityEngine;
using UnityEngine.Events;



public class BossController : MonoBehaviour
{
    //health stuffs...
    public float health = 2500;

    //event stuffs...
    [SerializeField] public static BossController current;
    

    public void Awake()
    {
        current = this;
    }

    public event Action onRoomTriggerEnter;

    public void RoomTriggerEnter()
    {
        if(onRoomTriggerEnter != null)
        {
            onRoomTriggerEnter();
        }
       
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            RoomTriggerEnter();
            Debug.Log("Invoking Test Event!");
        }
    }

}
