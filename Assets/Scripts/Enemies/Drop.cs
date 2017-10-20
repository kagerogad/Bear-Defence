using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour {

	public float rotateSpeed = 1f;
	public float disappearTimer = 3f;
	public float scrapAmount = 25f;


	// Update is called once per frame
	void Update () {
		disappearTimer -= Time.deltaTime;
		if (disappearTimer <= 0f) {
			Destroy (gameObject);
		}
		Revolve ();
	}

	void Revolve() {
		transform.Rotate(Vector3.right * rotateSpeed * Time.deltaTime);
		transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.World);
	}

	void OnTriggerEnter(Collider col) {
		GameObject go = col.gameObject;

		if (go.CompareTag("Player")) {
			float playerCurrency = GameManager.instance.playerCurrency;
			GameManager.instance.playerCurrency = playerCurrency + scrapAmount;
			Destroy (gameObject);
		}
	}
}
