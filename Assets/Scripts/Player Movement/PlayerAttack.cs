using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    PlayerStats characterStat;

    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public Animator PlayerAnim;
    private Animator bossAnim;
    float currentBHP;
    bool aR;
    
    
    public Transform AttackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage;


    void Start()
    {
        aR = true;
        characterStat = GetComponent<PlayerStats>();
        bossAnim = GameObject.Find("BossTest").GetComponent<Animator>();
    }

    void Update()
    {
        if(bossAnim != null) currentBHP = bossAnim.GetFloat("BossHealth");

        if (timeBtwAttack <= 0)
        {
            if (Input.GetKey(KeyCode.Mouse1))
            {
                PlayerAnim.SetTrigger("Attack");
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(AttackPos.position, attackRange,whatIsEnemies);
                if(Vector2.Distance(transform.position, bossAnim.transform.position) <= 2 && aR == true)
                {
                    bossAnim.SetFloat("BossHealth", currentBHP - damage);
                    timeBtwAttack = startTimeBtwAttack;
                    aR = false;
                    StartCoroutine(Wait());
                }

                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<EnemyHealth>().health -= damage; //enemiesToDamage[i].GetComponent<BossController>().TakeDamage(damage);
                    //enemiesToDamage[i].GetComponent<Animator>().SetFloat("BossHealth", currentBHP - damage);
                    if (GetComponent<BossController>() != null)
                    {
                        enemiesToDamage[i].GetComponent<BossController>().TakeDamage(damage);
                        Debug.Log("Boss Taking Sword Damage!");
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

    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(timeBtwAttack);
        aR = true;


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
