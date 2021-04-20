using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float speed;
    public int damage;

    void Start()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject,5f);
     
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "enemy")
        {
            Destroy(gameObject);
        }
    }
}