using System.Collections;
using System;
using UnityEngine;
using UnityEngine.Events;



public class BossController : MonoBehaviour
{
    //health stuffs...
    public float health = 25;
    public Animator animator;


    //Animator m_Animator;
    //string m_ClipName;
    //AnimatorClipInfo[] m_CurrentClipInfo;
    //float m_CurrentClipLength;

    private void Start()
    {
        animator = GetComponent<Animator>();
        ////health = animator.GetFloat("BossHealth");
        //m_Animator = gameObject.GetComponent<Animator>();
        ////Fetch the current Animation clip information for the base layer
        //m_CurrentClipInfo = this.m_Animator.GetCurrentAnimatorClipInfo(0);
        ////Access the current length of the clip
        //m_CurrentClipLength = m_CurrentClipInfo[0].clip.length;
        ////Access the Animation clip name
        //m_ClipName = m_CurrentClipInfo[0].clip.name;

    }

    void Update()
    {
        if (animator.GetFloat("BossHealth") >= 25) health = animator.GetFloat("BossHealth"); else if (animator.GetFloat("BossHealth") < 0) BossDead();
        if (Input.GetKeyDown(KeyCode.P))
        {
           
        }
        if(health <= 0)
        {
           // BossDead();
        }
    }

    void BossDead()
    {
        //Stuff to open the doors, big WOO YOU WON
        GameEvents.current.DoorwayTriggerExit();
        Debug.Log("Boss Defeated! Great Job!");
        //Destroy(gameObject);
    }

    void TakeDamage(int damage)
    {
        animator.SetFloat("BossHealth", health -= damage);
        //health -= damage;
        health = animator.GetFloat("BossHealth");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Fireball")
        {
            TakeDamage(collision.GetComponent<FireBall>().damage);
        }
    }

}
