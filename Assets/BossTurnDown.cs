using UnityEngine;
using Pathfinding;

public class BossTurnDown : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<AIPath>().slowWhenNotFacingTarget = true;
        animator.GetComponent<AIPath>().rotationSpeed = 180;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    
}
