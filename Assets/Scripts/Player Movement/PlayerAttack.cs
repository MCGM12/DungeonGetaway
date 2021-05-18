using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    PlayerStats characterStat;

    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public Animator PlayerAnim;
    
    
    public Transform AttackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage;


     void Start()
    {
        characterStat = GetComponent<PlayerStats>();
    }




    void Update()
    {
        if (timeBtwAttack <= 0)
        {
            if (Input.GetKey(KeyCode.Mouse1))

            {
                PlayerAnim.SetTrigger("Attack");
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(AttackPos.position, attackRange,whatIsEnemies );

                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<EnemyHealth>().health -= damage;
                    if(GetComponent<BossController>())
                    {
                        enemiesToDamage[i].GetComponent<BossController>().TakeDamage(damage); Debug.Log("Boss Taking Sword Damage!");
                    }
                }
            }
            timeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
        
      
  
    }

    public void Attack( PlayerStats targetStats)
    {
        
    }




    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(AttackPos.position, attackRange);
    }


}
