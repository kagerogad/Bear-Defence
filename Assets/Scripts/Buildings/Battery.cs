using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battery : MonoBehaviour {

	public Color selectedColor;
	public float capacity;
	public Image chargeBar;

	float currentCharge;

	Renderer rend;
	Color startColor;

	void Start() {
		rend = GetComponent<Renderer> ();
		startColor = rend.material.color;
		currentCharge = capacity;
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

	public void Discharge(float discharge) {
		if (currentCharge > 0) {
			currentCharge -= discharge;
			if (currentCharge < 0) {
				currentCharge = 0;
			}
		}
		chargeBar.fillAmount = currentCharge / capacity;
	}

	public void Charge(float charge) {
		if (currentCharge < capacity) {
			currentCharge += charge;
			if (currentCharge > capacity) {
				currentCharge = capacity;
			}
		}

		chargeBar.fillAmount = currentCharge / capacity;
	}
}
