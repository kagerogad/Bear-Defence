using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour {

	public float rotateSpeed = 1f;
	public float bobSpeed = 1f;
	public float yLimit = 2f;
	public float disappearTimer = 3f;
	public float scrapAmount = 25f;
	public GameObject effect;


	// Update is called once per frame
	void Update () {
		disappearTimer -= Time.deltaTime;
		if (disappearTimer <= 0f) {
			Destroy (gameObject);
		}
		Revolve ();
		Bob ();
	}

	void Revolve() {
		transform.Rotate(Vector3.right * rotateSpeed * Time.deltaTime);
		transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.World);
	}

	void Bob() {
		if (transform.position.y >= yLimit) {
			transform.Translate (Vector3.down * bobSpeed);
		} else if (transform.position.y <= 0f) {
			transform.Translate (Vector3.up * bobSpeed);
		}

	}

	void OnTriggerEnter(Collider col) {
		GameObject go = col.gameObject;

		if (go.CompareTag("Player")) {
			float playerCurrency = GameManager.instance.playerCurrency;
			GameManager.instance.playerCurrency = playerCurrency + scrapAmount;
			GameObject ef = (GameObject)Instantiate (effect, transform.position + new Vector3(0f, 2f, 0), Quaternion.identity);
			Destroy (ef, 0.2f);
			Destroy (gameObject);
		}
	}
}
