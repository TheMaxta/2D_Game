using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
	public Text textScore;
	public GameObject Player;
	public int current_score;

    // Update is called once per frame
    void Update()
    {


    	//we have to access the player movement script that stores the score variable to update the score text
    	//use get component on the player object to get the script component we need
    	//then, we index the score variable with the dot prefix on the script component we named. 
    	
    	//PlayerMovement playerScript = Player.GetComponent<PlayerMovement>();
    	current_score = PlayerMovement.score;
        textScore.text = "Score: x" + (current_score.ToString());

    }
}