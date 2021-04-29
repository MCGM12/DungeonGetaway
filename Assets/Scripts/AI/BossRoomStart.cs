using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;
using UnityEngine.EventSystems;

public class BossRoomStart : MonoBehaviour
{

    public GameObject Extras;
    public BossController BO;

    public void Awake()
    {
        BossController.current.onRoomTriggerEnter += OnDoorwayClose;
    }

    public void OnDoorwayClose()
    {
        Debug.Log("DOORWAY BEING CLOSED, PLAYER ENTERED");
        //Extras.SetActive(true);
        Extras.GetComponent<TilemapCollider2D>().enabled = true;
        Extras.GetComponent<TilemapRenderer>().enabled = true;
    }

    public bool detected = false;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            detected = true;
            BossController.current.RoomTriggerEnter();
        }
    }




}
