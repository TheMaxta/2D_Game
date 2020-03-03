using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InteractionObject : MonoBehaviour
{
	public bool openable;
	public bool locked;

	public Text doorText; 
	bool doorPresent = false;


	public int ScoreRequirement;
	public int index;

    // Start is called before the first frame update
    void Start()
    {
		doorText.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
		if (Input.GetButtonDown("Interact")){
       	// if current object is door pull index from door for next level if(interactObj)

			if(doorPresent)
			{

					//only allow player to enter next level if they have the required amount of coins
					if (PlayerMovement.score >= ScoreRequirement)
					{
						SceneManager.LoadScene(index);

					}
				}
			}
    }


	void OnTriggerStay2D(Collider2D other){
		if(other.gameObject.CompareTag("Player")){
			doorPresent = true;
			doorText.text = "Press E to Enter: Required: "+ ScoreRequirement;
			doorText.gameObject.SetActive(true);
		}
	}    


	void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.CompareTag("Player")){

				doorPresent = false;
				doorText.gameObject.SetActive(false);				
		}
	}


}
