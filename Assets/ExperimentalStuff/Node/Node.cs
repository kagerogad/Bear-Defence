using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

	public Vector3 offset;

	private GameObject building;

	public void Build(GameObject building) {
		if (building != null) {
			return;
		}

		GameManager.instance.Build1 (transform);
	}

	void OnTriggerEnter(Collider col) {
		GameObject go = col.gameObject;

		if (go.CompareTag("Player")) {
			go.GetComponent<Player> ().SetTile (transform);
			Debug.Log ("Set tile transform");
		}
	}

	void OnTriggerExit(Collider col) {
		GameObject go = col.gameObject;

		if (go.CompareTag("Player")) {
			go.GetComponent<Player> ().SetTile (null);
			Debug.Log ("De-Set tile transform");
		}
	}
}
