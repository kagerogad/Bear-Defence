using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

	public GameObject building;
	public Vector3 offset;

	public static BuildManager instance = null;

	private Transform tile;

	void Awake() {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}

	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.Mouse0)) {
			Build ();
		}
	}

	void Build() {
		Instantiate (building, tile.position + offset, Quaternion.identity);
	}

	public void SetTile(Transform t) {
		tile = t;
	}

}
