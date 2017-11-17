﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour {

	[Header("Player Attributes")]
	public float speed;
	public float startHealth;
    public float healPerSecond = 5f;

    [Header("Player References")]
	public Transform holdPosition;
	public Image healthBar;
	public GameObject building;
	public GameObject header;

	public SkinnedMeshRenderer renderer;

	private Rigidbody playerRB;
	private Vector3 movement;

	private Transform selectedObject;
	private bool isObjectSelected;
	private bool isCarrying;
	private float health;
	private bool swing;

	private int floorMask;
	private float camRayLength = 100f;

	//-----------------------Test---------------------------//

	private Transform tile;

	//----------------------EndTest------------------------//

	private Animator anim;

	[Header("Timers")]
	public float startPickUpTimer = 1f;
	public float startBuildTimer = 1f;
    public float startHealTimer = 1f;

	private float pickupTimer;
	private float buildTimer;
    private float healTimer;

	void Awake() {
		floorMask = LayerMask.GetMask ("Floor");
		playerRB = GetComponent<Rigidbody> ();
		health = startHealth;
		anim = GetComponent<Animator> ();
	}

	void FixedUpdate() {
		float horizontal = Input.GetAxisRaw ("Horizontal");
		float vertical = Input.GetAxisRaw ("Vertical");
		swing = Input.GetKeyDown(KeyCode.Space);

		Move (horizontal, vertical);
		Turn ();
		Animate (horizontal, vertical, swing);


		if (isObjectSelected && !isCarrying && Input.GetKeyDown(KeyCode.E)) {
			if (pickupTimer <= 0f) {
				selectedObject.GetComponent<InteractableObject> ().Interact (holdPosition);
				isCarrying = true;
				pickupTimer = startPickUpTimer;
			}
		} else if (isCarrying && Input.GetKeyDown(KeyCode.E)) {
			if (pickupTimer <= 0f) {
				Drop ();
				pickupTimer = startPickUpTimer;
			}
		}

		if (swing && selectedObject != null && selectedObject.CompareTag("Turret")) {
			if (selectedObject.GetComponent<Turret> () != null) {
				selectedObject.GetComponent<Turret> ().Heal (10f);
			} else {
				selectedObject.GetComponent<tp> ().Heal (10f);
			}
		}

		if (Input.GetKeyDown(KeyCode.F) && buildTimer <= 0f) {
			//Build ();
			if (tile != null) {
				//GameManager.instance.Build1 (tile);
				Instantiate(building, tile.position, tile.rotation);
			}
			buildTimer = startBuildTimer;
		}

        if (healTimer <= 0f)
        {
            healTimer = startHealTimer;
            Damage(-healPerSecond);
        }


        healTimer -= Time.deltaTime;
		buildTimer -= Time.deltaTime;
		pickupTimer -= Time.deltaTime;
	}

	void Move(float horizontal, float vertical) {
		movement.Set (horizontal, 0f, vertical);
		movement = movement.normalized * speed * Time.deltaTime;


		playerRB.MovePosition (transform.position + movement);
	}

	void Turn() {
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit floorHit;

		if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask)) {
			Vector3 playerToMouse = floorHit.point - transform.position;
			playerToMouse.y = 0f;

			Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
			playerRB.MoveRotation(newRotation);
		}
	}

	//-----------------------Test---------------------//
	public void SetTile(Transform tile) {
		this.tile = tile;
		Debug.Log ("Tile has been set");
	}
	//---------------------EndTest--------------------//
	void PickUp() {
		selectedObject.transform.SetPositionAndRotation (holdPosition.position, holdPosition.rotation);
		selectedObject.transform.SetParent (holdPosition);
		isCarrying = true;
	}

	void Drop() {
		holdPosition.DetachChildren ();
		isCarrying = false;
	}

	void Animate(float h, float v, bool swing) {
		bool running = h != 0f || v != 0f;
		anim.SetBool ("IsRunning", running);
		if (swing) {
			anim.SetTrigger ("Swing");
		}

	}

	/*void Build() {
		GameManager.instance.Build();
		return;
	}*/

	public void ObjectSelected(Transform selectedObject) {
		this.selectedObject = selectedObject;
		isObjectSelected = true;
	}

	public void ObjectedDeselected() {
		selectedObject = null;
		isObjectSelected = false;
	}

	public void Damage(float damage) {
		health -= damage;
		header.GetComponent<Animator> ().SetTrigger ("TakeDamage");

        if (health >= 100f)
        {
            health = 100f;
        }

		if (health <= 0f) {
			GameManager.instance.SetIsDead (true);
		}
        //healthBar.fillAmount = health / startHealth;
        healthBar.rectTransform.localScale = new Vector3(1, health / startHealth, 1);
	}

	void OnTriggerEnter(Collider col) {
		GameObject go = col.gameObject;

		if (go.CompareTag ("Turret")) {
			go.GetComponent<InteractableObject> ().Selected (transform);
		}
		if (go.CompareTag("Battery")) {
			go.GetComponent<InteractableObject> ().Selected (transform);
		}
	}

	void OnTriggerExit(Collider col) {
		GameObject go = col.gameObject;

		if (go.CompareTag("Turret")) {
			go.GetComponent<InteractableObject> ().DeSelected (transform);
		}
		if (go.CompareTag("Battery")) {
			go.GetComponent<InteractableObject> ().DeSelected (transform);
		}
	}

}