using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour {

	public Slider volumeSlider;

	void Awake() {
		SetVolume ();
		Time.timeScale = 1;
	}

	public void UpdateVolume() {
		PlayerPrefs.SetFloat ("MusicVolume", volumeSlider.value);
	}

	public void SetVolume() {
		volumeSlider.value = PlayerPrefs.GetFloat ("MusicVolume", .5f);
	}
}
