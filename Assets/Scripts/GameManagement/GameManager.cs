using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;



	[Header("Game Settings")]
	public float enemyStartCurrency = 100f;
	public static float playerCurrency = 100f;
	public float enemyCurrencyMultiplier = 1.5f;
	public float timeBetweenRounds = 30f;
	public float timeBetweenSpawns = 3f;


	[Header("References")]
	public EnemyArray enemyArray;
	public GameObject startRoundButton;
	public Text roundCounter;
	public Text playerCurrencyText;

	private float enemyCurrentCurrency;
	private int roundNumber = 0;


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
				startRoundButton.SetActive (true);
			}
		}

		UpdateCurrency ();
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
		roundCounter.text = "Round " + roundNumber.ToString ();

		roundStarted = true;
	}

	public void UpdateCurrency() {
		playerCurrencyText.text = playerCurrency.ToString();
	}
		
}
