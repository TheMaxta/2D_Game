using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
	public CharacterController2D controller;
	public Animator animator;
	public float runSpeed = 40f;
	public int index;
	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false; 
	public static int score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    	//debug.log is removable, it is just for testing
       horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;


       animator.SetFloat("Speed", Mathf.Abs(horizontalMove));





       if (Input.GetButtonDown("Jump")){
	       jump = true;
	       animator.SetBool("IsJumping", true);
	   }
	   if (Input.GetButtonDown("Crouch")){
	   		crouch = true;

	   }
       else if (Input.GetButtonUp("Crouch")){
	       crouch = false;

	   }
    }





    public void OnLanding(){
    	animator.SetBool("IsJumping", false);
    }

    public void OnCrouching(bool isCrouching){
    	animator.SetBool( "IsCrouching" , isCrouching );
    }

    void FixedUpdate(){
    	///move character, 2nd is crouch 3rd is jump
    	controller.Move(horizontalMove * Time.fixedDeltaTime , crouch, jump);
    	jump = false;
    }


		//On Trigger event occurs when collision with collider takes place.
	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.CompareTag("Coin")){
			Destroy(other.gameObject);
			score++;
		}



		if(other.gameObject.CompareTag("Spike")){

			//want to eventually deal damage and push player backwards
			Destroy(this.gameObject);
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

		}
		
		
	}




}
