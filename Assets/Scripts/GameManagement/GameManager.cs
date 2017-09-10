using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;



	[Header("Game Settings")]
	public float enemyStartCurrency = 100f;
	public float playerStartCurrency = 100f;
	public float enemyCurrencyMultiplier = 1.5f;
	public float timeBetweenRounds = 30f;
	public float timeBetweenSpawns = 3f;


	[Header("References")]
	public EnemyArray enemyArray;


	private float playerCurrentCurrency;
	private float enemyCurrentCurrency;
	private int roundNumber = 1;


	private float timer;
	private bool roundStarted;


	private GameObject[] enemySpawners;
	public static System.Random rand;

	void Awake() {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}

		playerCurrentCurrency = playerStartCurrency;
		enemyCurrentCurrency = enemyStartCurrency;

		rand = new System.Random ();
		enemySpawners = GameObject.FindGameObjectsWithTag ("EnemySpawner");
		timer = timeBetweenRounds;
	}


	void Update() {
		/*timer -= Time.deltaTime;
		if (timer <= 0f) {
			SpawnEnemy (enemyArray.enemies[0]);
			timer = timeBetweenRounds;
		}*/

		if (roundStarted) {
			timer -= Time.deltaTime;
			if (timer <= 0f) {
				SpawnEnemy (enemyArray.enemies[0]);
				Debug.Log (enemyCurrentCurrency);
				timer = timeBetweenSpawns;
			}
			if (enemyCurrentCurrency <= 0f) {
				roundStarted = false;
			}
		}
	}


	void SpawnEnemy(GameObject enemy) {
		int randomIndex = rand.Next (0, enemySpawners.Length);
		float cost = enemy.GetComponent<Enemy> ().cost;
		Debug.Log (cost);
		enemyCurrentCurrency = enemyCurrentCurrency - cost;
		enemySpawners [randomIndex].GetComponent<Spawner> ().Spawn (enemy);
		return;
	}



	public void StartRound() {
		enemyStartCurrency = enemyStartCurrency * enemyCurrencyMultiplier;
		enemyCurrentCurrency = enemyStartCurrency;
		roundNumber = roundNumber + 1;

		roundStarted = true;
	}
}
