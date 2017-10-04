using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingScript : MonoBehaviour {

	public GameObject Building;
	public Transform holdPosition;

	public Vector3 offset;

	bool isHoldingSomething;

	GameObject heldObject;

	void Start () {
		
	}

	void Update () {
		Debug.Log (holdPosition.position);
		if (Input.GetKeyDown(KeyCode.J) && !isHoldingSomething) {
			heldObject = (GameObject)Instantiate (Building, holdPosition);
			isHoldingSomething = true;
		} else if (Input.GetKeyDown(KeyCode.J) && isHoldingSomething) {
			

			float x = roundToPosition (holdPosition.position.x);
			float y = roundToPosition (holdPosition.position.y);
			float z = roundToPosition (holdPosition.position.z);



			Vector3 pos = new Vector3 (x, y, z) + offset;

			holdPosition.DetachChildren ();
			heldObject.transform.SetPositionAndRotation (pos, Quaternion.identity);
			isHoldingSomething = false;
		}
	}


	float roundToPosition(float num) {
		float num1 = Mathf.Round (num);
		bool roundedUp = false;
		bool isEven = false;

		if (num < num1) {
			roundedUp = true;
		}

		if ((num1 % 2) == 0) {
			isEven = true;
		}

		if (!isEven) {
			if (roundedUp) {
				num1 = num1 - 1f;
			} else {
				num1 = num1 + 2f;
			}
		}
		return num1;
	}


}
