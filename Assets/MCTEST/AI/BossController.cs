using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;


public class BossController : MonoBehaviour
{
    //health stuffs...
    public float health = 2500;

    //event stuffs...
    public static BossController current;
    //[SerializeField] private UnityEvent myTestTrigger;

    public void Awake()
    {
        current = this;
    }

    public event UnityAction onRoomTriggerEnter;

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
