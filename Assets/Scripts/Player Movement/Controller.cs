using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float moveSpeed = 6f;

    Vector2 movement;

<<<<<<< HEAD
    Vector2 movement;

    private Rigidbody2D rb;
<<<<<<< HEAD
   //public Camera viewCamera;
=======
  
>>>>>>> main
=======
    private Rigidbody2D rb;
  
>>>>>>> main
    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * moveSpeed;

=======
        velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * moveSpeed;

>>>>>>> main
     
    }

    private void FixedUpdate()
    {
        rb.velocity = velocity;
    }
}
