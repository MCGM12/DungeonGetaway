using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class ChasePlayer : StateMachineBehaviour
{
    public Transform target;
    IAstarAI ai;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        target = GameObject.Find("Player").transform;
        ai = animator.GetComponent<IAstarAI>();
        animator.SetBool("PlayerChase", true);
        if (ai != null) ai.onSearchPath += Update;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Update();
    }
    void Update()
    {
        if (target != null && ai != null) ai.destination = target.position;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

   
}
