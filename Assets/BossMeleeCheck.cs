using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMeleeCheck : StateMachineBehaviour
{
    //public bool PIRM = false;
    Transform p;
    Transform b;
    public float dist;
    BossMelee bm;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bm = GameObject.Find("BossTest").GetComponent<BossMelee>();
        bm.enabled = true;
        //Debug.Log("Found boss melee script");
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        b = GameObject.Find("BossTest").transform;
        p = GameObject.Find("Player").transform;


        if (Vector2.Distance(p.position, b.position) <= dist)
        {
            bm.PIRM = true;
            animator.SetBool("PIRM", true); 
        } else
        {
            if(bm.startTimeBtwAttack >= 0)
            {
                animator.SetBool("PIRM", false);
                bm.PIRM = false;
            }
            
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //bm.enabled = false;
    }

}
