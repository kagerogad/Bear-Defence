using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InteractableObject : MonoBehaviour, IsInteractable {

	public Color selectedColor;


	protected Renderer rend;
	protected Color startColor;
	protected Transform player;


	void Start() {
		rend = GetComponent<Renderer> ();
		startColor = rend.material.color;
	}

	public void Selected(Transform player_) {
		rend.material.color = selectedColor;
		Transform player = player_;
		player.GetComponent<Player> ().ObjectSelected (transform);
	}

	public void DeSelected(Transform player_) {
		Transform player = player_;
		rend.material.color = startColor;
		player.GetComponent<Player> ().ObjectedDeselected ();
	}

	public void Interact() {
		
	}

	/*void OnTriggerEnter(Collider col) {
		GameObject go = col.gameObject;

		if (go.CompareTag("Player")) {
			Selected ();
		}
	}

	void OnTriggerExit(Collider col) {
		GameObject go = col.gameObject;

		if (go.CompareTag("Player")) {
			DeSelected ();
		}
	}*/

}
