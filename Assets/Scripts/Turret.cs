using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

	public float dischargeTimer = 1f;
	private float dischargeRate;

	void Start() {
		dischargeRate = dischargeTimer;
	}

	void Update() {
		dischargeRate -= Time.deltaTime;
	}

	void OnTriggerStay(Collider col) {
		GameObject go = col.gameObject;
		Battery bat = null;
		if (go.CompareTag("Battery")) {
			bat = go.GetComponent<Battery> ();
		}
		if (bat != null) {
			bat.Discharge (.1f);
		}
	}

	void OnTriggerExit(Collider col) {
		GameObject go = col.gameObject;
		if (go.CompareTag("Battery")) {
			Debug.Log ("Battery has exited");
		}
	}
}
