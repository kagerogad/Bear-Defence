using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

	public Color selectedColor;
	public GameObject building;

	private Renderer rend;
	private Color startColor;

	void Start() {
		rend = GetComponent<Renderer> ();
		startColor = rend.material.color;
	}

	void OnMouseEnter() {
		Debug.Log ("Mouse Entered");
		rend.material.color = selectedColor;
	}

	void OnMouseExit() {
		rend.material.color = startColor;
	}

	void OnMouseDown() {
		Instantiate (building, transform.position, transform.rotation);
	}
}
