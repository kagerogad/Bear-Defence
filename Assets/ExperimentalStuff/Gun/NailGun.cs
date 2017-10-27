using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NailGun : GunBaseClass {


	void Update() {
		if (Input.GetKeyDown(KeyCode.G)) {
			Fire ();
		}
	}

	void Fire() {
		GameObject proj = (GameObject)Instantiate (projectile, FirePosition.position, FirePosition.rotation);
		proj.GetComponent<Projectile> ().SetTarget (target);
	}
}
