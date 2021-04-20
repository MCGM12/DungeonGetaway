using UnityEngine;
using Pathfinding;

public class EnemyAI : VersionedMonoBehaviour
{

    public Transform target;
    public GameObject player;
    public float speed = 200;
    public float nextWaypointDistance = 4f;

    AIPath aiPath;
    AIBase aiBase;
    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;
    Seeker seeker;
    Rigidbody2D rb2;

    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player");
        target = player.GetComponent<Transform>();
        seeker = GetComponent<Seeker>();
        rb2 = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, .5f);
        aiPath.enableRotation = true;
    }

    void UpdatePath()
    {
        if(seeker.IsDone())
           seeker.StartPath(rb2.position, target.position, OnPathComplete);
       
    }

    void OnPathComplete(Path p)
    {
        if(!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
   
    void FixedUpdate()
    {
        if (path == null)
            return;

        if(currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb2.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb2.AddForce(force);

        float distance = Vector2.Distance(rb2.position, path.vectorPath[currentWaypoint]);

        if(distance <= nextWaypointDistance)
        {
            currentWaypoint++;
        }
    }
}
