using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour {
	
	public Transform canvas;
	public Text gameOverText;
	int maxScore = 0;
	GameObject player1;
	PlayerPlatformerController playerScript1; 

	GameObject player2;
	PlayerPlatformerController2 playerScript2;

    //public GameObject gems;

	void Start(){
		canvas.gameObject.SetActive (false);
		player1 =  GameObject.FindWithTag("Player1");
		playerScript1 = player1.GetComponent<PlayerPlatformerController>();

		player2 =  GameObject.FindWithTag("Player2");
		playerScript2 = player2.GetComponent<PlayerPlatformerController2>();

        //SelectGems winAmount = GetComponent<SelectGems>();

        var selectGems = GameObject.Find("GemController");
        SelectGems winAmount = selectGems.GetComponent<SelectGems>();
        maxScore = winAmount.Gems;
        Debug.Log(maxScore);

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

