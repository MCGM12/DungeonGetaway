using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    public bool bossDead;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            GameEvents.current.DoorwayTriggerEnter();
        }
    }
    private void Update()
    {
        if(bossDead)
        {
            GameEvents.current.DoorwayTriggerExit();
        }
    }
}
