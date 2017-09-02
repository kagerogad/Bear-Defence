using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour {

	public Color selectedColor;

	Renderer rend;
	Color startColor;

	void Start() {
		rend = GetComponent<Renderer> ();
		startColor = rend.material.color;
	}

	void OnTriggerEnter(Collider col) {
		GameObject go = col.gameObject;

		if (go.CompareTag("Player")) {
			rend.material.color = selectedColor;
			go.GetComponent<Player> ().ObjectSelected (transform);
		}
	}

	void OnTriggerExit(Collider col) {
		rend.material.color = startColor;
		if (col.gameObject.CompareTag("Player")) {
			col.gameObject.GetComponent<Player> ().ObjectedDeselected ();
		}

	}
}
