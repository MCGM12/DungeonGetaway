using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100;

    void Start()
    {
        
    }


    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Fireball")
        {
            health -= 50;
        }
        if(collision.tag == "Sword")
        {
            Debug.Log("Basic Enemy Taking Sword Damage");
            health -= 100;
        }
    }
}
