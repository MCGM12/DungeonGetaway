using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyPatrol : StateMachineBehaviour
{
    public Transform[] targets;
    public Transform cT;
    public float delay = 0;
    int index;
    IAstarAI agent;
    float switchTime = float.PositiveInfinity;
    public static Transform sct;
    public Transform player;

    public float speed = 5f;

    public GameObject pf;
    public float FireballForce = 20f;
    public float FireBallCoolDown = 2;
    private float nextFireTime = 0;

    void Fire(Animator animator)
    {
        GameObject fireball = Instantiate(pf, animator.transform.position, animator.transform.rotation);
        fireball.tag = "bossFireball"; //Debug.Log("FIring fireball at player");
        Rigidbody2D rb2d = fireball.GetComponent<Rigidbody2D>();
        rb2d.AddForce(animator.transform.up * FireballForce, ForceMode2D.Impulse);
        animator.SetBool("FireballAttack", false);
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        agent = animator.GetComponent<IAstarAI>();
        targets = animator.GetComponent<PatrolHolder>().targets;
        agent.destination = sct.position;

    }

    void Rotation(Animator _animator, Transform _player)
    {
        Vector2 direction = _player.position - _animator.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        rotation.x = _player.rotation.x;
        rotation.y = _player.rotation.y;
        _animator.transform.rotation = Quaternion.Slerp(_animator.transform.rotation, rotation, speed * Time.deltaTime);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (targets.Length == 0) return;

        if (Vector2.Distance(animator.transform.position, player.position) <= 10)
        {
            Rotation(animator, player);
            if (Time.time > nextFireTime)
            {
                Fire(animator);
                nextFireTime = Time.time + FireBallCoolDown;
                
            }
        }
        
        bool search = false;

        if (agent.reachedEndOfPath && !agent.pathPending && float.IsPositiveInfinity(switchTime)) 
            //NOTE: This is when the AI reaches one of its patrol points. 
            //Activate stuff you want to happen inbetween patrol points here
        {
            switchTime = Time.time + delay;
            //if(Vector2.Distance(animator.transform.position, GameObject.Find("Player").transform.position) <= 10)
            //{
            //    Fire(animator);
            //}
            
        }

        if (Time.time >= switchTime)
        {
            index = index + 1;
            search = true;
            switchTime = float.PositiveInfinity;
        }

        index = index % targets.Length;
        agent.destination = targets[index].position;
        cT = targets[index];
        sct = cT;

        if (search) agent.SearchPath();
    }

    public void FireBall(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("FireballAttack", true); //Debug.Log("Boss preparing to launch fireball!");

    }

   
}
