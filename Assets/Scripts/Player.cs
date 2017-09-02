using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour {
	//Checking
	public float speed;

	public Transform holdPosition;

	private Rigidbody playerRB;
	private Vector3 movement;

	private Transform selectedObject;
	private bool isObjectSelected;
	private bool isCarrying;

	private int floorMask;
	private float camRayLength = 100f;

	//Timers
	public float startPickUpTimer = 1f;
	private float pickupTimer;

	void Awake() {
		floorMask = LayerMask.GetMask ("Floor");
		playerRB = GetComponent<Rigidbody> ();

	}

	void FixedUpdate() {
		float horizontal = Input.GetAxisRaw ("Horizontal");
		float vertical = Input.GetAxisRaw ("Vertical");

		Move (horizontal, vertical);
		Turn ();

		if (isObjectSelected && !isCarrying && Input.GetKeyDown(KeyCode.E)) {
			if (pickupTimer <= 0f) {
				PickUp ();
				pickupTimer = startPickUpTimer;
			}
		} else if (isCarrying && Input.GetKeyDown(KeyCode.E)) {
			if (pickupTimer <= 0f) {
				Drop ();
				pickupTimer = startPickUpTimer;
			}
		}

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

	void PickUp() {
		selectedObject.transform.SetPositionAndRotation (holdPosition.position, holdPosition.rotation);
		selectedObject.transform.SetParent (holdPosition);
		isCarrying = true;
		Debug.Log ("PickedUp");
	}

	void Drop() {
		Debug.Log ("Dropped");
		holdPosition.DetachChildren ();
		isCarrying = false;
	}

	public void ObjectSelected(Transform selectedObject) {
		this.selectedObject = selectedObject;
		isObjectSelected = true;
	}

	public void ObjectedDeselected() {
		selectedObject = null;
		isObjectSelected = false;
	}

}