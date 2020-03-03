using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroller : MonoBehaviour
{

	public float speed;

	public Transform[] moveSpots;
	private float waitTime;
	private float startWaitTime;
	private int randomSpot;

    // Start is called before the first frame update
    void Start()
    {
    	waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
    }

    // Update is called once per frame
	private void FixedUpdate()
    {

    	transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);//accepts current target and distance

    	if(Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f){
    		if (waitTime <= 0){
    			randomSpot = Random.Range(0, moveSpots.Length);
    			waitTime = startWaitTime;
    			} else{
    				waitTime -= Time.deltaTime;
    			}
    	}


    }
}
