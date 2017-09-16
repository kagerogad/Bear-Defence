using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarPanel : MonoBehaviour {

	void OnTriggerStay(Collider col) {
		GameObject go = col.gameObject;
		Battery bat = null;
		if (go.CompareTag("Battery")) {
			bat = go.GetComponent<Battery> ();
		}
		if (bat != null) {
			bat.Charge (.5f);
		}
	}

}
