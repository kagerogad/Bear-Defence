using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {
	public float speed;

	Transform player;
	NavMeshAgent nav;
	bool isTouchingPlayer;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		nav = GetComponent<NavMeshAgent> ();
	}

	// Update is called once per frame
	void Update () {
		Move ();
	}

	void Move() {
		if (!isTouchingPlayer) {
			nav.SetDestination (player.position);
		}
		nav.acceleration = 100f;
		nav.speed = speed;
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
