using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGrid : MonoBehaviour {

	[Header("References")]
	public GameObject node;

	[Header("Deminsions")]
	public int length;
	public int width;

	[Header("Offsets")]
	public float xOffset;
	public float yOffset;
	public float zOffset;

	public void BuildGrid() {
		for (int x = 0; x < length; x++) {
			for (int z = 0; z < width; z++) {
				PlaceNode (x * xOffset, yOffset, z * zOffset);
			}
		}
	}

	void PlaceNode(float x, float y, float z) {
		Vector3 pos = new Vector3 (x, y, z);
		Instantiate (node, pos, transform.rotation);
	}
}
