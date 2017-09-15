using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarPanel : MonoBehaviour {

	public float chargeRate;


	void OnTriggerStay(Collider col) {
		GameObject go = col.gameObject;
		Battery bat = null;
		if (go.CompareTag("Battery")) {
			bat = go.GetComponent<Battery> ();
		}
		if (bat != null) {
			bat.Charge (chargeRate);
		}
	}

}
