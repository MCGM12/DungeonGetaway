using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Boss_Patrol : StateMachineBehaviour
{

    //Transform p1;
    //Transform p2;
    //Transform p3;
    //Transform p4;
    //Transform p5;
    //Transform p6;
    public Transform[] targets;
    public float delay = 0;
    int index;
    IAstarAI agent;
    float switchTime = float.PositiveInfinity;



    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //base.Awake();

        //p1 = GameObject.Find("BP1").GetComponent<Transform>(); p2 = GameObject.Find("BP2").GetComponent<Transform>();
        //p3 = GameObject.Find("BP3").GetComponent<Transform>(); p4 = GameObject.Find("BP4").GetComponent<Transform>();
        //p5 = GameObject.Find("BP5").GetComponent<Transform>(); p6 = GameObject.Find("BP6").GetComponent<Transform>();
        agent = animator.GetComponent<IAstarAI>();
        targets = animator.GetComponent<PatrolHolder>().targets;

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (targets.Length == 0) return;

        bool search = false;

        // Note: using reachedEndOfPath and pathPending instead of reachedDestination here because
        // if the destination cannot be reached by the agent, we don't want it to get stuck, we just want it to get as close as possible and then move on.
        if (agent.reachedEndOfPath && !agent.pathPending && float.IsPositiveInfinity(switchTime))
        {
            switchTime = Time.time + delay;
        }

        if (Time.time >= switchTime)
        {
            index = index + 1;
            search = true;
            switchTime = float.PositiveInfinity;
        }

        index = index % targets.Length;
        agent.destination = targets[index].position;

        if (search) agent.SearchPath();
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }


}
