using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	protected Transform target;

	public float Speed;
	public float damage;
	public float timeTillDeath = 3f;



	protected Vector3 dir;

	public void SetTarget(Transform target) {
		this.target = target;
		dir = target.position - transform.position;
		dir.y = 0f;
		dir = dir.normalized;
	}

	public void Travel() {
		gameObject.transform.Translate (dir * Time.deltaTime * Speed, Space.World);
	}


	void Update() {
		if (target == null) {
			Destroy (gameObject);
			return;
		}

		timeTillDeath -= Time.deltaTime;


		if (timeTillDeath <= 0f) {
			Destroy (gameObject);
		}

		Travel ();


	}

	void OnTriggerEnter(Collider col) {
		GameObject go = col.gameObject;

		if (go.CompareTag("Enemy")) {
			go.GetComponent<Enemy> ().TakeDamage (damage);
			Destroy (gameObject);
		}
	}
		
}
