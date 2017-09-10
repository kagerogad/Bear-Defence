using UnityEngine;

public class CameraControl : MonoBehaviour {

	public float smoothSpeed;
	public Transform player;

	public float xOffset;
	public float yOffset;
	public float zOffset;

	void FixedUpdate() {
		Move ();
	}

	void Move() {

		Vector3 desiredPosition = player.position + new Vector3(xOffset, yOffset, zOffset);
		Vector3 currentPosition = transform.position;

		Vector3 smoothedPosition = Vector3.Lerp (currentPosition, desiredPosition, smoothSpeed * Time.deltaTime);

		transform.position = smoothedPosition;
		transform.LookAt (player);
	}

}
