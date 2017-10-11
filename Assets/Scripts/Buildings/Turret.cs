using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turret : PlaceableObject, IsDamageable {

	[Header("Turret Attributes")]
	public string enemyTag;
	public float range;
	public float batteryRange;
	public float turnSpeed;
	public float rateOfFire = 1f;
	public float startDurability = 100f;
	public float durabilityLossPerShot = 10f;

	private float rateOfFire_;

	[Header("Turret References")]
	public Transform partToRotate;
	public Transform firingPoint;
	public GameObject projectile;
	public Image durabilityBar;
	public GameObject wire;

	private Transform target;
	private bool isOn;
	private float durability;


	void Start() {
		rateOfFire_ = rateOfFire;
		durability = startDurability;
		InvokeRepeating ("UpdateTarget", 0f, 0.5f);
		InvokeRepeating ("UpdateBattery", 0f, 0.5f);
	}

	void Update() {
		if (target == null) {
			return;
		}

		rateOfFire_ -= Time.deltaTime;

		if (isOn && durability > 0f) {
			Aim (target);
			if (rateOfFire_ <= 0f) {
				Fire ();
				rateOfFire_ = rateOfFire;
			}
		}

	}

	public void UpdateTarget() {
		GameObject[] enemies = GameObject.FindGameObjectsWithTag (enemyTag);
		float shortestDistance = Mathf.Infinity;
		GameObject nearestEnemy = null;

		foreach (GameObject enemy in enemies) {

			float distanceToEnemy = Vector3.Distance (transform.position, enemy.transform.position);
			if (distanceToEnemy < shortestDistance) {
				shortestDistance = distanceToEnemy;
				nearestEnemy = enemy;
			}
		}

		if (nearestEnemy != null && shortestDistance <= range) {
			target = nearestEnemy.transform;
		} else {
			target = null;
		}

	}

	public void UpdateBattery() {
		GameObject[] batteries = GameObject.FindGameObjectsWithTag ("Battery");
		float shortestDistance = Mathf.Infinity;
		GameObject nearestBattery = null;

		foreach (GameObject battery in batteries) {
			float distanceToBattery = Vector3.Distance (transform.position, battery.transform.position);
			if (distanceToBattery < shortestDistance) {
				shortestDistance = distanceToBattery;
				nearestBattery = battery;
			}
		}

		if (nearestBattery != null && shortestDistance <= batteryRange) {
			isOn = true;
		} else {
			isOn = false;
		}
	}

		
		

	public void Aim(Transform target) {
		Vector3 dir = target.transform.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation (dir);

		Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
		partToRotate.rotation = Quaternion.Euler (0f, rotation.y, 0f);
	}

	void Fire() {
		GameObject proj = (GameObject)Instantiate (projectile, firingPoint.position, firingPoint.rotation);
		proj.GetComponent<Projectile> ().SetTarget (target);
		durability -= durabilityLossPerShot;
		durabilityBar.fillAmount = durability / startDurability;
	}




	public void TakeDamage(float damageTaken) {

	}

	public void Heal(float amountHealed) {
		if (durability + amountHealed > startDurability) {
			durability = startDurability;
		} else {
			durability += amountHealed;
		}
		durabilityBar.fillAmount = durability / startDurability;
	}

	public void Die() {

	}
		


	void OnTriggerEnter(Collider col) {
		GameObject go = col.gameObject;
		if (go.CompareTag("Battery")) {
			isOn = true;
		}
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
			isOn = false;
		}
	}
}
