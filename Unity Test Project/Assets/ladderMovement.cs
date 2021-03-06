﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladderMovement : MonoBehaviour
{
	public float speed;
	private Rigidbody2D rb;
	private float inputHorizontal;
	private float inputVertical;
	public float distance;
	public LayerMask whatIsLadder;
	private bool isClimbing;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, whatIsLadder);
    	
    	if(hitInfo.collider != null){
    		if(Input.GetButtonDown("Jump")){
    			isClimbing = true;
    		}
    	}

    	if(isClimbing == true){
    		inputVertical = Input.GetAxisRaw("Vertical");
			rb.velocity = new Vector2(rb.velocity.x, inputVertical * speed);
			rb.gravityScale = 0;
    	}

    }
}
