using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BossController : MonoBehaviour
{
    [SerializeField] private UnityEvent myTestTrigger;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            myTestTrigger.Invoke();
            Debug.Log("Invoking Test Event!");
        }
    }
}
