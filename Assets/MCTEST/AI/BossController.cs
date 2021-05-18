using System.Collections;
using System;
using UnityEngine;
using UnityEngine.Events;



public class BossController : MonoBehaviour
{
    //health stuffs...
    public float health = 25;
    public Animator animator;
    public bool dead;

    public Transform targetTransform;
    public float speed;

    //Animator m_Animator;
    //string m_ClipName;
    //AnimatorClipInfo[] m_CurrentClipInfo;
    //float m_CurrentClipLength;

    private void Start()
    {
        targetTransform = GameObject.Find("Player").transform;
        animator = GetComponent<Animator>();
        

    }

    void Update()
    {
        //Vector3 vectorToTarget = targetTransform.position - transform.position;
        //float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        //Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        //transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
        //var offset = 90f;
        //Vector2 direction = targetTransform.position - transform.position;
        //direction.Normalize();
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));


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
        if(!dead)
        {
            //Stuff to open the doors, big WOO YOU WON
            GameEvents.current.DoorwayTriggerExit();
            Debug.Log("Boss Defeated! Great Job!");
            Destroy(gameObject);
            dead = true;
        }

    }

    public void TakeDamage(int damage)
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
