using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemeyFireball : StateMachineBehaviour
{
    //public float fs;
    public Transform p, c;
    public GameObject pf;
    public float FireballForce = 20f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        p = GameObject.Find("Player").transform;
        c = animator.transform;
    }

    
    void Fire()
    { 
        GameObject fireball = Instantiate(pf, c.position, c.rotation);
        fireball.tag = "bossFireball"; //Debug.Log("FIring fireball at player");
        Rigidbody2D rb2d = fireball.GetComponent<Rigidbody2D>();
        rb2d.AddForce(c.up * FireballForce, ForceMode2D.Impulse);
        c.GetComponent<Animator>().SetBool("FireballAttack", false);
    }
}
