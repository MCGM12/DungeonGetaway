using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float moveSpeed = 6f;
    Vector2 movement;
    private Rigidbody2D rb;
   //public Camera viewCamera;
    Vector3 velocity;
    PlayerStats Speed;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(transform.position.x,transform.position.y,-2);
        }

        velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * moveSpeed;

        velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * moveSpeed;

     
    }

    private void FixedUpdate()
    {
        rb.velocity = velocity;
    }

   
}
