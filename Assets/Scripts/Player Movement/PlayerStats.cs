using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth; //{ get; set; }

    public CharacterStat Attack;

    public CharacterStat Speed;

    public Healthbar healthbar;

   

    public CharacterStat Health;

    private void Awake()
    {
        currentHealth = maxHealth;

        healthbar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage( int damage)
    {
        

        currentHealth -= damage;
        //currentHealth = currentHealth - damage;
        healthbar.SetHealth(currentHealth);
        Debug.Log(transform.name + " takes " + damage + " damage.");

        if (currentHealth <= 0)
        {
            Die();

        }


    }

     void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(10);
        }
    }

    public virtual void  Die()
    {
        // Dies in some way so like game over or respawn to a certain point 

        Debug.Log(transform.name + "died ");
    }

}
