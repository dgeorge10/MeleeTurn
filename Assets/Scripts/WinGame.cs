using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour {
	
	public Transform canvas;
	public Text gameOverText;
	public int maxScore;
	GameObject player1;
	PlayerPlatformerController playerScript1; 


	GameObject player2;
	PlayerPlatformerController2 playerScript2; 

	void Start(){
		canvas.gameObject.SetActive (false);
		player1 =  GameObject.FindWithTag("Player1");
		playerScript1 = player1.GetComponent<PlayerPlatformerController>();

		player2 =  GameObject.FindWithTag("Player2");
		playerScript2 = player2.GetComponent<PlayerPlatformerController2>();

		//Debug.Log (playerScript2.getScore ());
	}
	void Update () {
		if (playerScript1.getScore () >= maxScore && canvas.gameObject.activeInHierarchy == false) {
			gameOverText.text = "Player 1 Wins!";
			canvas.gameObject.SetActive (true);
			Time.timeScale = 0;
		}
		if (playerScript2.getScore() >= maxScore && canvas.gameObject.activeInHierarchy == false) {
			gameOverText.text = "Player 2 Wins!";
			canvas.gameObject.SetActive (true);
			Time.timeScale = 0;
		}
	}
	public void reset(int sceneIndex){
		Time.timeScale = 1;
		SceneManager.LoadScene (sceneIndex);
	}

}

