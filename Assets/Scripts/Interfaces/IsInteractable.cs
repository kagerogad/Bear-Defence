using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IsInteractable {

	void Interact (Transform player);
	void Selected (Transform player);
	void DeSelected(Transform player);
}
