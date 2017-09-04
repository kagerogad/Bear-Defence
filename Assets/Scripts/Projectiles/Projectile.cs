using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	protected Transform target;
	public float damage;

	public float Speed;
	public float timeTillDeath = 3f;
	public float dbd; // Distance to enemy Before Death



	protected Vector3 dir;

	public void SetTarget(Transform target) {
		this.target = target;
	}

	public void SetDirection(Vector3 direction) {
		dir = direction;
	}

	public void Travel() {
		gameObject.transform.Translate (dir * Time.deltaTime * Speed, Space.World);
	}


	void Update() {
		if (target == null) {
			Destroy (gameObject);
			return;
		}
		Travel ();


	}
		
}
