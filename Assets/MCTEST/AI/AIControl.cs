using UnityEngine;
using System.Collections;
using Pathfinding;

public class AIControl : MonoBehaviour
{
    
    public AIPatrol patrol;
    public AIPath aiPath;
    public EnemyAI enemyAI;
    public TestFOV fov;
    public AIDestinationSetter dest;

    GameObject enemy, player;

    public bool playerSpotted;


    void Start()
    {
        patrol = GetComponent<AIPatrol>();
        aiPath = GetComponent<AIPath>();
        enemyAI = GetComponent<EnemyAI>();
        fov = GetComponent<TestFOV>();
        dest = GetComponent<AIDestinationSetter>();

        enemy = gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
        dest.target = player.transform;

    }

    
    void Update()
    {
        dest.target = player.transform;
        if (playerSpotted)
        {
            //enemyAI.enabled = true;
            patrol.enabled = false;
            //aiPath.enabled = false;
            dest.enabled = true;
            if (Vector2.Distance(transform.position, player.transform.position) <= 0.75f && PlayerManager.grabbed == false)
            {
                PlayerManager.grabbed = true;
                fov.spotted = false;
                playerSpotted = false;
            } 
            else PlayerManager.grabbed = false;
        }
        else
        {
            //enemyAI.enabled = false;
            patrol.enabled = true;
            //aiPath.enabled = true;
            dest.enabled = false;
        }

    }
    IEnumerator Wait(float time, bool change)
    {
        if(change)
        {
            yield return new WaitForSeconds(time);
            change = false;
        }

    }
}
