using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileHighlightController : MonoBehaviour {

	BoxCollider bc;
	List<GameObject> tiles = new List<GameObject>();

	private IEnumerator coroutine;

	// Use this for initialization
	void Start () {
		bc = GetComponent<BoxCollider> ();
		//coroutine = DumpTiles(5f);
		//StartCoroutine(coroutine);
	}
	
	void OnTriggerEnter(Collider col) {
		Debug.Log ("Collider called");
		GameObject go = col.gameObject;
		if (go.CompareTag("Tile")) {
			go.GetComponent<SpriteRenderer> ().enabled = true;
		}
	}

	void OnTriggerStay(Collider col) {
		GameObject go = col.gameObject;
		if (go.CompareTag("Tile")) {
			go.GetComponent<SpriteRenderer> ().enabled = true;
		}
	}

	void OnTriggerExit(Collider col) {
		GameObject go = col.gameObject;
		if (go.CompareTag("Tile")) {
			go.GetComponent<SpriteRenderer> ().enabled = false;
			tiles.Add (go);
		}
	}

	/*private IEnumerator DumpTiles(float waitTime)
	{
		while (true)
		{
			yield return new WaitForSeconds(waitTime);
			foreach (GameObject tiles in tiles) {
				tiles.GetComponent<SpriteRenderer> ().enabled = false;
			}
		}
	}*/
}
