using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class BossControlls : StateMachineBehaviour
{
    public float speed = 5f;
    public Transform player;
    public GameObject bhp;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.Find("Player").transform;
        bhp = player.GetComponent<BHPholder>().BHP;
        bhp.SetActive(true);

    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //animator.transform.forward = Vector2.up;

        Vector2 direction = player.position - animator.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90 , Vector3.forward);
        rotation.x = player.rotation.x;
        rotation.y = player.rotation.y;
        animator.transform.rotation = Quaternion.Slerp(animator.transform.rotation, rotation, speed * Time.deltaTime);
    }

  


    
}
