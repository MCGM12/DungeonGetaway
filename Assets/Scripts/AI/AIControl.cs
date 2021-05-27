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
    public bool PIRM;

    void Start()
    {
        patrol = GetComponent<AIPatrol>();
        //aiPath = GetComponent<AIPath>();
        //enemyAI = GetComponent<EnemyAI>();
        fov = GetComponent<TestFOV>();
        dest = GetComponent<AIDestinationSetter>();

        enemy = gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
        dest.target = player.transform;

    }

    void Update()
    {
        playerSpotted = fov.spotted;
        dest.target = player.transform;
        PIRM = Vector2.Distance(transform.position, player.transform.position) < 2;
        GetComponent<BossMelee>().PIRM = PIRM;
        if (playerSpotted)
        {
            patrol.enabled = false;
            dest.enabled = true;

            
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
