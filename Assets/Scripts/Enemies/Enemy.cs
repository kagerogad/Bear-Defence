using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour, IsDamageable {

	[Header("Enemy Attributes")]
	public float speed;
	public float damage;
	public float startHealth;
	public float cost;
	public int chanceOfDrop;
	public float attackRange;

	[Header("References")]
	public Image healthBar;
	public GameObject drop;

	[Header("Drop Offset")]
	public Vector3 offSet;

	Transform player;
	NavMeshAgent nav;
	bool isTouchingPlayer;
	float health;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Bear1").transform;
		nav = GetComponent<NavMeshAgent> ();

		health = startHealth;
		InvokeRepeating ("Attack", 0.0f, .5f);
	}

	// Update is called once per frame
	void Update () {
		Move ();

		if (health <= 0f) {
			Die ();
		}
	}

	void Attack() {
		if (Vector3.Distance(player.position, transform.position) <= attackRange) {
			player.GetComponent<Player> ().Damage (damage);
		}
	}
	void Move() {
		if (!isTouchingPlayer) {
			nav.SetDestination (player.position);
		}
		nav.acceleration = 100f;
		nav.speed = speed;
	}

	/*void OnTriggerEnter(Collider col) {
		GameObject go = col.gameObject;

		if (go.CompareTag("Player")) {
			isTouchingPlayer = true;
			go.GetComponent<Player> ().Damage (damage);
		}
	}

	void OnTriggerExit(Collider col) {
		GameObject go = col.gameObject;

		if (go.CompareTag("Player")) {
			isTouchingPlayer = false;
		}
	}*/

	public void TakeDamage(float damageTaken) {
		health -= damageTaken;
		healthBar.fillAmount = health / startHealth;
	}

	public void Heal(float amountHealed) {
		health += amountHealed;
		healthBar.fillAmount = health / startHealth;
	}

	public void Die() {
		if (drop != null) {
			DropObject (drop);
		}
		Destroy (gameObject);
	}

	public void DropObject(GameObject drop) {
		int randomInt = GameManager.rand.Next (0, 100);
		if (randomInt <= chanceOfDrop) {
			Instantiate (drop, transform.position + offSet, transform.rotation);
		}
	}
		
}

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy: MonoBehaviour {

	private Transform player;

	[Header("Enemy Attributes")]
	public float speed;
	public float startHealth;

	private float health;


	[Header("Don't Mess with")]
	public Image healthBar;

	void Start() {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		health = startHealth;
	}

	void Update() {
		Move ();

		if (health <= 0) {
			Die ();
		}
	}

	void Move() {

		Vector3 desiredPosition = player.position;
		Vector3 currentPosition = transform.position;

		Vector3 moveDirection = desiredPosition - currentPosition;

		if (Vector3.Distance(desiredPosition, currentPosition) > 1.5f) {
			transform.Translate (moveDirection.normalized * speed * Time.deltaTime);
		}

	}
		
		

	void Die() {
		Destroy (gameObject);
	}


}*/
