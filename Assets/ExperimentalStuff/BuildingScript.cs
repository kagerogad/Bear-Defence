using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingScript : MonoBehaviour {

	public GameObject building;
	Transform currentTile;


	void Update() {
		if (Input.GetKeyDown(KeyCode.J) && currentTile != null) {
			Instantiate (building, currentTile.position, Quaternion.identity);
		}
	}

	void OnTriggerEnter(Collider col) {
		GameObject go = col.gameObject;

		if (go.CompareTag("Tile")) {
			currentTile = go.transform;
		}
	}

	void OnTriggerExit(Collider col) {
		GameObject go = col.gameObject;

		if (go.CompareTag("Tile")) {
			currentTile = null;
		}
	}

}
