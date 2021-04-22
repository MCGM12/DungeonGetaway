using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashMovement : MonoBehaviour
{
    public Rigidbody2D Rgb2d;

    public int dashSpeed = 200;

    bool dash = false;

  public  int dashCooldown = 80;

    // Update is called once per frame
    void FixedUpdate()

    {

        if (dashCooldown == 0)
        {
            dash = true;
        }
        else
        {
            dashCooldown--;
        }




        //Rgb2d.velocity = Vector2.zero;


        if (Input.GetKey(KeyCode.LeftShift) && dash == true)
        {
            Rgb2d.velocity = Vector2.zero;
            Vector2 mouseDirection = (Input.mousePosition - new Vector3(Screen.width / 2, Screen.height / 2)).normalized;

            Rgb2d.AddForce(mouseDirection * dashSpeed * Time.deltaTime*2);
            dash = false;
            dashCooldown = 80;
        }
    }
}
