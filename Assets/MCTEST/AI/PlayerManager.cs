using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour
{
    public static GameObject player;
    public static bool grabbed;
    public Vector3 lastCheckpoint;
    public static Transform playerTransform;

    void Start()
    {
        player = gameObject;
        lastCheckpoint = new Vector3(0, 0, 0);
    }

    void Update()
    {
        playerTransform = transform;
        
        if(grabbed)
        {
            player.transform.position = lastCheckpoint;
            grabbed = false;
        }
        if(Input.GetKeyDown(KeyCode.C))
        {
            player.transform.position = lastCheckpoint;
            grabbed = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Checkpoint")
        {
            lastCheckpoint = collision.gameObject.transform.position;
        }
    }
    IEnumerator Wait(float time, bool change)
    {
        if (change)
        {
            yield return new WaitForSeconds(time);
            change = false;
        }

    }
}
