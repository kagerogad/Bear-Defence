using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NailGun : GunBaseClass {


	void Update() {
		if (Input.GetKeyDown(KeyCode.Space)) {
			Fire ();
		}
	}
		

	void Fire() {

		GameObject newbullet = null;

		newbullet = ObjectPoolNails.instance.GetPoolObject ();

		if (newbullet == null) {
			return;
		}

		newbullet.transform.SetPositionAndRotation (FirePosition.position, FirePosition.rotation);
		newbullet.SetActive (true);
		newbullet.GetComponent<Projectile> ().SetTarget (target);
	}
}
