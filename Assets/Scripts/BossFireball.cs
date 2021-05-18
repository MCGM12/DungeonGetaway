using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFireball : StateMachineBehaviour
{
    public float fs;
    public Transform p, c;
    public GameObject pf;


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        p = GameObject.Find("Player").transform; c = animator.transform;


    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    void Fire()
    {

    }

}
