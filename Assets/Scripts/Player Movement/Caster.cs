using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caster : MonoBehaviour
{
    public Transform FirePoint; // Transform used to shoot the fire ball 
    public GameObject FireBallPrefab;

    public float FireballForce = 20f; // FireBall Speed
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }


    void Shoot()
    {
        GameObject fireball = Instantiate(FireBallPrefab, FirePoint.position, FirePoint.rotation);

        Rigidbody2D rb2d = fireball.GetComponent<Rigidbody2D>();
        rb2d.AddForce(FirePoint.up * FireballForce, ForceMode2D.Impulse);
    }
}
