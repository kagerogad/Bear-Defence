using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileHighlightController : MonoBehaviour {

	BoxCollider bc;
	List<GameObject> tiles = new List<GameObject>();

	// Use this for initialization
	void Start () {
		bc = GetComponent<BoxCollider> ();
		//coroutine = DumpTiles(5f);
		//StartCoroutine(coroutine);
	}

	void Highlight(GameObject tile) {
		tile.GetComponent<TileSelectController> ().isHighlighted = true;
	}
	void UnHighlight(GameObject tile) {
		tile.GetComponent<TileSelectController> ().isHighlighted = false;
	}
	
	void OnTriggerEnter(Collider col) {
		GameObject go = col.gameObject;
		if (go.CompareTag("Tile")) {
			go.GetComponent<SpriteRenderer> ().enabled = true;
			Highlight (go);
		}
	}

	void OnTriggerStay(Collider col) {
		GameObject go = col.gameObject;
		if (go.CompareTag("Tile")) {
			go.GetComponent<SpriteRenderer> ().enabled = true;
			Highlight (go);
		}
	}

	void OnTriggerExit(Collider col) {
		GameObject go = col.gameObject;
		if (go.CompareTag("Tile")) {
			go.GetComponent<SpriteRenderer> ().enabled = false;
			tiles.Add (go);
			UnHighlight (go);
		}
	}
		
}
