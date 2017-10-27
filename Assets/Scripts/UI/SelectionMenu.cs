using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SelectionMenu : MonoBehaviour {

	void Update() {
		if (Input.GetKeyDown(KeyCode.Tab)) {
			gameObject.SetActive (true);
		}
	}


}
