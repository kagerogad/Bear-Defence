using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour {

	[Header("Texture")]
	public Texture2D textureMap;


	public GameObject block;
	public GameObject blockTwo;

	public Color colorOne;
	public Color colorTwo;

	[Header("Offsets")]
	public float xOffset = 4f;
	public float yOffset = 0f;
	public float zOffset = 4f;


	public void GenerateLevel () {
		Debug.Log (textureMap.height);
		for (int z = 0; z < textureMap.width; z++) {
			for (int x = 0; x < textureMap.height; x++) {
				Vector3 pos = new Vector3 (x * xOffset, yOffset, z * zOffset);
				GeneratePath (x, z, pos);
			}
		}
	}

	void GeneratePath(int x, int z, Vector3 pos) {
		Color pixelColor = textureMap.GetPixel (x, z);

		if (pixelColor.a == 0) {
			Debug.Log ("Block Not Placed");
			return;
		}

		if (pixelColor == colorOne) {
			Instantiate (block, pos, block.transform.rotation);
		} else if (pixelColor == colorTwo) {
			Instantiate (blockTwo, pos, blockTwo.transform.rotation);
		}

		Debug.Log ("Block Placed");
	}
		
}
