using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	protected Transform target;

	public float Speed;
	public float damage;
	public float lifeTime = 3f;
	public GameObject effect;

	protected Vector3 dir;

    private void OnEnable()
    {
        Invoke("RemoveObject", lifeTime);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

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
			RemoveObject ();
			return;
		}

		Travel ();
	}

    private void RemoveObject()
    {
        gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider col) {
		GameObject go = col.gameObject;

		if (go.CompareTag("Enemy")) {
			go.GetComponent<Enemy> ().TakeDamage (damage);
			GameObject ef = (GameObject)Instantiate (effect, transform.position, transform.rotation);
			Destroy (ef, 0.2f);
			RemoveObject();
		}
	}
		
}
