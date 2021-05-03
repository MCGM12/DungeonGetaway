using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DoorControllers : MonoBehaviour
{
    public GameObject Extras;

    void Start()
    {
        GameEvents.current.onDoorwayTriggerEnter += OnDoorwayOpen;
        GameEvents.current.onDoorwayTriggerExit += OnDoorwayClose;
    }

    private void OnDoorwayOpen()
    {
        Debug.Log("DOORWAY BEING CLOSED, PLAYER ENTERED");
        //Extras.SetActive(true);
        Extras.GetComponent<TilemapCollider2D>().enabled = true;
        Extras.GetComponent<TilemapRenderer>().enabled = true;
    }

    private void OnDoorwayClose()
    {
        Debug.Log("DOORWAY BEING OPENED, PLAYER CAN EXIT");
        //Extras.SetActive(true);
        Extras.GetComponent<TilemapCollider2D>().enabled = false;
        Extras.GetComponent<TilemapRenderer>().enabled = false;
    }


}
