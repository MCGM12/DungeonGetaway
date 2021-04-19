using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float movementspeed ;
    public Rigidbody2D rb2D;

    Vector2 movement;
    Vector2 MousePos;
    public Camera cam;    // Update is called once per frame
    void Update()
    {
        // Inputs 

     movement.x =  Input.GetAxisRaw("Horizontal"); // moves player left or right with wasd arrow keys 
     movement.y =  Input.GetAxisRaw("Vertical"); // Moves player Up or down 
        MousePos = cam.ScreenToWorldPoint(Input.mousePosition); // Will let the player rotate or turn around 

        if (Input.GetKey(KeyCode.LeftShift)) // Lets Player sprint 
      
          movementspeed = 10f;
        else
           movementspeed = 5f; 



    }

   public void FixedUpdate()
    {
        // Movement 


        rb2D.MovePosition(rb2D.position + movement * movementspeed * Time.fixedDeltaTime);

        Vector2 lookDir = MousePos - rb2D.position; 
        float angle = Mathf.Atan2(lookDir.y,lookDir.x)*Mathf.Rad2Deg-90f; // Z pos

        rb2D.rotation = angle;
    }

}
