using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

	public Vector3 offset;

	private GameObject building;

	public void Build(GameObject building) {
		if (building != null) {
			return;
		}

		GameManager.instance.Build1 (transform);
	}

}
