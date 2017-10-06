using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InteractableObject : MonoBehaviour, IsInteractable {

	public Color selectedColor;


	protected Renderer rend;
	protected Color startColor;


	void Start() {
		rend = GetComponent<Renderer> ();
		startColor = rend.material.color;
	}

	public virtual void Selected(Transform player_) {
		if (rend != null) {
			rend.material.color = selectedColor;
		}

		Transform player = player_;
		player.GetComponent<Player> ().ObjectSelected (transform);
	}

	public virtual void DeSelected(Transform player_) {
		Transform player = player_;
		if (rend != null) {
			rend.material.color = startColor;
		}

		player.GetComponent<Player> ().ObjectedDeselected ();
	}

	public virtual void Interact(Transform holdPosition) {
		transform.SetPositionAndRotation (holdPosition.position, holdPosition.rotation);
		transform.SetParent (holdPosition, true);
	}
		
}
