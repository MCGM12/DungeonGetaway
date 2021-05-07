using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Pathfinding;

public class BossMelee : VersionedMonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public SpriteRenderer sword;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRangeX;
    public float attackRangeY;
    public int damage;

    public bool PIRM = false;


    

    void Update()
    {
        if(timeBtwAttack <= 0) //if can attack...
        {
            if(PIRM) // if player in range...
            {
                sword.enabled = true;
                Collider2D[] playerToDamage = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackRangeX, attackRangeY), 0);  //finds player collider
                for (int i = 0; i < playerToDamage.Length; i++)
                {
                    playerToDamage[i].GetComponent<Controller>().TakeDamage(damage); //player takes damage
                }
            }
            timeBtwAttack = startTimeBtwAttack;
            sword.enabled = false;
        } else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPos.position, new Vector2(attackRangeX, attackRangeY));
    }

    

    
}
