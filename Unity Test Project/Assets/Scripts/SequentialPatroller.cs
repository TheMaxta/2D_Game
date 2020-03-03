using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequentialPatroller : MonoBehaviour
{

	public float speed;

	public Transform[] moveSpots;
	private float waitTime;
	private float startWaitTime;
	private int randomSpot;
    private int index; 

    // Start is called before the first frame update
    void Start()
    {
    	waitTime = startWaitTime;
        index =0;
    }

    // Update is called once per frame
	private void FixedUpdate()
    {
        if(Vector2.Distance(transform.position, moveSpots[index].position) < 0.2f){
            if (index <= moveSpots.Length){
            	transform.position = Vector2.MoveTowards(transform.position, moveSpots[index].position, speed * Time.deltaTime);//accepts current target and distance

            }
            else {
                index = 0;
            }
            index++;
        }

    }
}
