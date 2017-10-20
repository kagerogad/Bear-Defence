using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour {

	public Slider volumeSlider;

	void Awake() {
		SetVolume ();
	}

	public void SetVolume() {
		PlayerPrefs.SetFloat ("MusicVolume", volumeSlider.value);
	}
}
