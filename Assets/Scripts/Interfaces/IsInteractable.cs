using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IsInteractable {

	void Interact ();
	void Selected (Transform player);
	void DeSelected(Transform player);
}
