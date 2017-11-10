using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionMenu : MonoBehaviour {

	void Update() {
		if (Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.Escape)) {
			gameObject.SetActive (true);
		}
	}

	public void ResumeGame() {
		GameManager.instance.MenuSelect ();
	}

	public void BackToMain() {
		if (Time.timeScale == 0) {
			Time.timeScale = 1;
		}
		SceneManager.LoadScene (1);
	}

	public void RestartGame() {
		if (Time.timeScale == 0f) {
			Time.timeScale = 1f;
		}
		SceneManager.LoadScene (0);
	}

	public void OpenSettings() {

	}

}
