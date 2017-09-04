using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;

	public float timeBetweenRounds;
	private float timer;

	public EnemyArray enemyArray;
	private GameObject[] enemySpawners;
	public static System.Random rand;

	void Awake() {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}

		rand = new System.Random ();
		enemySpawners = GameObject.FindGameObjectsWithTag ("EnemySpawner");
		timer = timeBetweenRounds;
	}


	void Update() {
		timer -= Time.deltaTime;
		if (timer <= 0f) {
			SpawnEnemy (enemyArray.enemies[0]);
			timer = timeBetweenRounds;
		}
	}


	void SpawnEnemy(GameObject enemy) {
		int randomIndex = rand.Next (0, enemySpawners.Length);
		Debug.Log (randomIndex);
		enemySpawners [randomIndex].GetComponent<Spawner> ().Spawn (enemy);
		return;
	}
}
