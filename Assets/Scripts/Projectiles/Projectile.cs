using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	protected Transform target;

	public float Speed;
	public float damage;
	public float heal;
	public float lifeTime = 3f;
	public GameObject effect;

	public bool isNail;

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
		Debug.Log (go.gameObject.name);
		if (go.CompareTag("Enemy")) {
			go.GetComponent<Enemy> ().TakeDamage (damage);
			GameObject ef = (GameObject)Instantiate (effect, transform.position, transform.rotation);
			Destroy (ef, 0.2f);
			RemoveObject();
		} else if (go.CompareTag("Turret") && isNail) {
			go.GetComponent<Turret> ().Heal (heal);
			GameObject ef = (GameObject)Instantiate (effect, transform.position, transform.rotation);
			Destroy (ef, 0.2f);
			RemoveObject ();
		}
	}
		
}
