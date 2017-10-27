using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;



	[Header("Game Settings")]
	public float enemyStartCurrency = 100f;
	public float playerCurrency = 100f;
	public float enemyCurrencyMultiplier = 1.5f;
	public float timeBetweenRounds = 30f;
	public float timeBetweenSpawns = 3f;

	private bool isDead;

	public float timeBuildPhase = 5f;
	private float timeBuildPhase_;


	[Header("References")]
	public Transform player;
	public EnemyArray enemyArray;
	public Buildings buildings;
	public GameObject startRoundButton;
	public Text roundCounter;
	public Text playerCurrencyText;
	public GameObject selectionMenu;
	public GameObject gameOverPanel;
	public Text gameOverRoundText;

	private AudioSource gameMusic;

	private float enemyCurrentCurrency;
	public int roundNumber = 0;

	private GameObject selectedBuilding;

	private float timer;
	private bool roundStarted;

	private bool isPaused = false;

	public GameObject tiles;
	private GameObject[] enemySpawners;
	public static System.Random rand;

	void Awake() {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}

		gameMusic = GetComponent<AudioSource> ();
		gameMusic.volume = PlayerPrefs.GetFloat("MusicVolume");
		enemyCurrentCurrency = enemyStartCurrency;
		selectedBuilding = buildings.buildingsArray [0];
		timeBuildPhase_ = timeBuildPhase;

		rand = new System.Random ();
		enemySpawners = GameObject.FindGameObjectsWithTag ("EnemySpawner");
		timer = timeBetweenRounds;
	}


	void Update() {
		if (roundStarted) {
			timer -= Time.deltaTime;
			if (timer <= 0f && enemyCurrentCurrency > 0f) {
				SpawnEnemy (enemyArray.enemies[0]);
				Debug.Log (enemyCurrentCurrency);
				timer = timeBetweenSpawns;
			}
			if (enemyCurrentCurrency <= 0f) {
				if (CheckIfNoEnemiesAlive()) {
					roundStarted = false;
					startRoundButton.SetActive (true);
				}
			}
		}

		if (!roundStarted) {
			tiles.SetActive (true);
			timeBuildPhase_ -= Time.deltaTime;
			roundCounter.text = timeBuildPhase_.ToString ();

			if (timeBuildPhase_ <= 0f) {
				StartRound ();
				timeBuildPhase_ = timeBuildPhase;
			}
		}

		if (isDead) {
			gameOverPanel.SetActive (true);
			gameOverRoundText.text = "You made to " + roundCounter.text;
			PlayerPrefs.SetInt ("RoundNumber", roundNumber);
			Time.timeScale = 0;
		}

		UpdateCurrency ();

		if (Input.GetKeyDown(KeyCode.Tab)) {
			MenuSelect ();
		}
	}

	bool CheckIfNoEnemiesAlive() {
		GameObject[] enems = GameObject.FindGameObjectsWithTag ("Enemy");
		return enems.Length <= 0f;
	}
	void SpawnEnemy(GameObject enemy) {
		int randomIndex = rand.Next (0, enemySpawners.Length);
		float cost = enemy.GetComponent<Enemy> ().cost;
		Debug.Log (cost);
		enemyCurrentCurrency = enemyCurrentCurrency - cost;
		enemySpawners [randomIndex].GetComponent<Spawner> ().Spawn (enemy);
		return;
	}

	public void SetIsDead(bool isDead) {
		this.isDead = isDead;
	}

	public void StartRound() {
		tiles.SetActive (false);
		enemyStartCurrency = enemyStartCurrency * enemyCurrencyMultiplier;
		enemyCurrentCurrency = enemyStartCurrency;
		roundNumber = roundNumber + 1;
		roundCounter.text = "Round " + roundNumber.ToString ();

		roundStarted = true;
	}

	public void UpdateCurrency() {
		playerCurrencyText.text = playerCurrency.ToString();
	}


	//Building
	/*public void Build() {
		float cost = selectedBuilding.GetComponent<PlaceableObject> ().cost;
		if (playerCurrency - cost >= 0f) {
			playerCurrency -= cost;
			Transform holdPosition = player.GetComponent<Player> ().holdPosition;
			Instantiate (selectedBuilding, holdPosition.position, holdPosition.rotation);
			Debug.Log ("Built something using Gamemanager");
		}

	}*/

	public void Build1(Transform tile) {
		/*float cost = selectedBuilding.GetComponent<PlaceableObject> ().cost;
		if (playerCurrency - cost >= 0f) {
			playerCurrency -= cost;
			//Transform holdPosition = player.GetComponent<Player> ().holdPosition;
			Instantiate (selectedBuilding, tile.position, tile.rotation);
			Debug.Log ("Built something using Gamemanager");
		}*/
		Instantiate (selectedBuilding, tile.position, tile.rotation);

	}

	public void ChangeSelectedBuilding(int index) {

	}

	public void UnLockArea() {

	}



	//UI
	public void MenuSelect() {
		isPaused = !isPaused;
		selectionMenu.SetActive (isPaused);
		if (isPaused) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
	}
		
}
