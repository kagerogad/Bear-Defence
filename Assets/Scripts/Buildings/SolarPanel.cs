using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarPanel : MonoBehaviour {
	public float radius = 10f;
	public float chargeAmount = .1f;

	Transform battery;

	void Start() {
		battery = GameObject.FindGameObjectWithTag ("Battery").transform;
	}

	void Update() {
		if (isBatteryNear ()) {
			battery.GetComponent<Battery> ().Charge (chargeAmount);
			battery.GetComponent<Battery> ().charging = true;
		} else {
			battery.GetComponent<Battery> ().charging = false;
		}
	}

	bool isBatteryNear() {
		return Vector3.Distance(transform.position, battery.position) <= radius;
	}

	/*void OnTriggerStay(Collider col) {
		GameObject go = col.gameObject;
		Battery bat = null;
		if (go.CompareTag("Battery")) {
			bat = go.GetComponent<Battery> ();
		}
		if (bat != null) {
			bat.Charge (chargeAmount);
		}
	}*/

}
