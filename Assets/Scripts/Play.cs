using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Play : MonoBehaviour {

	public GameObject player1;
	public GameObject player2;
	PlayerPlatformerController playerScript1; 
	PlayerPlatformerController playerScript2; 

	public int activePlayer;
	public float timeLeft;
	public Text info;
	public Text timer;

	public GameObject[] gems;
	public float spawnTime;



	// Use this for initialization
	void Start () {
		Debug.Log("Start");
		activePlayer = Random.Range(1,3);
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
		SwapPlayer ();
		playerScript1 = player1.GetComponent<PlayerPlatformerController>();
		playerScript2 = player2.GetComponent<PlayerPlatformerController>();
	}

	void SwapPlayer() {
		timeLeft = 15.0f;
		info.text = "Player " + activePlayer + " is up!";
		if (activePlayer == 1) {
			playerScript2.deactivate ();
			playerScript1.activate ();
		} else {
			playerScript1.deactivate ();
			playerScript2.activate ();
		}
	}

	void Spawn() {
		Debug.Log ("Spawning...");
		// Find a random index between zero and one less than the number of spawn points.
		int spawnPointIndex = Random.Range (0, gems.Length);

		// Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
		if (!gems [spawnPointIndex].activeInHierarchy) {
			GemBehaviour sample = gems [spawnPointIndex].GetComponent("GemBehaviour") as GemBehaviour; 
			sample.GemSpawned ();
			Debug.Log ("Spawned.");
		} else {
			Debug.Log ("Gem is already active!");
		}
	}

	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
		if (timeLeft < 0) {
			SwapPlayer ();
		}
		timer.text = "Time: " + Mathf.Floor (timeLeft);
	}
}
