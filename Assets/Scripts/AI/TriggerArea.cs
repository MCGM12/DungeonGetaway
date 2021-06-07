using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    public bool bossDead, roomCleared;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            GameEvents.current.DoorwayTriggerEnter();
        }
    }
    private void Update()
    {
        if(bossDead || roomCleared)
        {
            GameEvents.current.DoorwayTriggerExit();
        }
      
    }
}
