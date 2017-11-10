using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitAnimation : MonoBehaviour {

	public GameObject bearMesh;

	Renderer bearMeshRenderer;

	void Start() {
		bearMeshRenderer = bearMesh.GetComponent<Renderer> ();

	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.P)) {
			
			for (int i = 0; i <= 5; i++) {
				Debug.Log ("blah " + i);
				//DeactivateMesh ();
				StartCoroutine(Wait (1f));
				StopCoroutine(Wait(1f));
				//ActivateMesh ();
			}
			//StartCoroutine (FlashMesh (1, 1f));
		}
	}

	void DeactivateMesh() {
		bearMeshRenderer.enabled = false;
	} 

	void ActivateMesh() {
		bearMeshRenderer.enabled = true;
	}

	IEnumerator FlashMesh(int i, float timeBetweenFlashes) {
		while (i > 0) {
			Debug.Log ("coroutine has ran: " + i);
			DeactivateMesh ();
			yield return new WaitForSeconds (timeBetweenFlashes);
			ActivateMesh ();
			i = i - 1;
		}
	}



	private IEnumerator Wait(float seconds)
	{
		Debug.Log ("Entered wait");
		yield return new WaitForSeconds(seconds);
	}
		
}
