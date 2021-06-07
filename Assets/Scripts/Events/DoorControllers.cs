using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DoorControllers : MonoBehaviour
{
    public GameObject Extras;
    [SerializeField] private Animator bossControls;
    public TilemapCollider2D t2d;
    public TilemapRenderer tr;

    void Start()
    {
        GameEvents.current.onDoorwayTriggerEnter += OnDoorwayOpen;
        GameEvents.current.onDoorwayTriggerExit += OnDoorwayClose;
    }

    private void OnDoorwayOpen()
    {
        Debug.Log("DOORWAY BEING CLOSED, PLAYER ENTERED");
        //Extras.SetActive(true);
        if (bossControls != null) { bossControls.enabled = true; }

        tr.enabled = true;
        t2d.enabled = true;
    }

    private void OnDoorwayClose()
    {
        Debug.Log("DOORWAY BEING OPENED, PLAYER CAN EXIT");
        //Extras.SetActive(true);
        tr.enabled = false;
        t2d.enabled = false;
    }


}
