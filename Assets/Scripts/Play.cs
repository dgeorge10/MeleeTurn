using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour {

	public GameObject player1;
	public GameObject player2;

	public GameObject[] gems;
	public float spawnTime;

	// Use this for initialization
	void Start () {
		Debug.Log("Start");
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
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

	}
}
