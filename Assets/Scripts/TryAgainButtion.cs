using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TryAgainButtion : MonoBehaviour {

	public void TryAgain() {
		SceneManager.LoadScene (0);
	}
}
