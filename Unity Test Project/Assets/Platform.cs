using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    // Start is called before the first frame update

	public Transform pos1, pos2;
	public float speed;
	public Transform startPos;

	Vector3 nextPos;


    void Start()
    {
        nextPos = startPos.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    	//runs every update. logic only sets next position when we have reached our destination
    	if(transform.position == pos1.position){
    		nextPos = pos2.position;
    	}
    	if(transform.position == pos2.position){
    		nextPos = pos1.position;	
    	}

    	//actual movement happens here. 
        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }

    private void OnDrawGizmos(){
    	Gizmos.DrawLine(pos1.position, pos2.position);
    }
}
