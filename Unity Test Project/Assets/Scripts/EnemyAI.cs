using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class EnemyAI : MonoBehaviour
{

	public Transform target;
	public Transform target2;

	public float speed = 200f;
	public float nextWaypointDistance = 3f;


	public Transform BirdGFX;


	Path path;
	int currentWaypoint = 0;
	bool reachedEndOfPath = false;

	Seeker seeker;
	Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, 0.5f);

    }

    void UpdatePath(){
    	if(seeker.IsDone())
	        seeker.StartPath(rb.position, target.position, OnPathComplete);
    }


    void OnPathComplete(Path p){
    	if (!p.error)
    	{
    		path = p;
    		currentWaypoint = 0;
    	}
    }


    // Update is called once per frame
    void FixedUpdate()
    {
    	if (path == null)
    		return;

    	if(currentWaypoint >= path.vectorPath.Count)
    	{
    		reachedEndOfPath = true;
    		return;
    	} else{
    		reachedEndOfPath = false;
    	}

    	//sets up actual movement of AI Object
    	//(current path - current position) :  1 = right -1 = left
    	Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance){
        	currentWaypoint++;
        }



        	//desired velocity is where the enemy is pathfinding
        if(rb.velocity.x >= 0.01f){
        	//Executes when moving to right

        	//sets the sprite to face the right
			BirdGFX.localScale = new Vector3(-4f,4f,4f); 
        } else if (rb.velocity.x <= -0.01f) //velocirty will be negative if pathfinding to the left
        {
        	//Executes when moving to left
        	//Sets sprite vector to face left
        	BirdGFX.localScale = new Vector3(4f, 4f, 4f);
        }
    }
}
