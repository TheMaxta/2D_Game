using UnityEngine;
using System.Collections;


using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour {

	public int index;
	public string levelName;

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag("Player"))
		{

			//Loading level with scene index
			SceneManager.LoadScene(index);

			//or we can index with the actual name
			//SceneManager.LoadScene("level12");

		}
	}



	
}