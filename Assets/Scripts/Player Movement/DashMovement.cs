using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashMovement : MonoBehaviour
{
    public Rigidbody2D Rgb2d;

    private Vector2 mouseSpot;

    public int dashSpeed = 200;

    bool dash = false;

    //bool yes = false;

    bool mousePos = true;

  public  int dashCooldown = 80;

    // Update is called once per frame
    void FixedUpdate()

    {

        if (dashCooldown == 0)
        {
            dash = true;
            mousePos = true;
           // yes = false;
        }
        else
        {
            dashCooldown--;
        }




        //Rgb2d.velocity = Vector2.zero;


        if (Input.GetKey(KeyCode.LeftShift) && dash == true)
        {
            if(mousePos)
            {
                Rgb2d.velocity = Vector2.zero;
                mouseSpot = Input.mousePosition;
                mouseSpot = Camera.main.ScreenToWorldPoint(mouseSpot);
                mousePos = false;
            }
            
            
            Vector2 mouseDirection = (Input.mousePosition - new Vector3(Screen.width / 2, Screen.height / 2)).normalized;

            Rgb2d.AddForce(mouseDirection * dashSpeed * Time.deltaTime*2);

            //Rgb2d.MovePosition(Vector2.Lerp(mouseDirection, mouseSpot, dashSpeed * Time.deltaTime));
            //this.transform.position = Vector2.Lerp(transform.position, mouseSpot, dashSpeed);//* Time.deltaTime);
            //Rgb2d.MovePosition(Vector2.Lerp(transform.position, mouseSpot, dashSpeed * Time.deltaTime).normalized);
            dash = false;
            dashCooldown = 80;
        }
    }
}
