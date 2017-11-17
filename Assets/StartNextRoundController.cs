using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartNextRoundController : MonoBehaviour {

	GameObject[] turrets;
	private Button button;

	void Start() {
		button = gameObject.GetComponent<Button> ();
	}

	void Update() {
		if (NumberOfTurrets () <= 0) {
			button.interactable = false;
		} else {
			button.interactable = true;
		}
	}

	int NumberOfTurrets() {
		turrets = GameObject.FindGameObjectsWithTag ("Turret");
		return turrets.Length;
	}
}
