using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayRound : MonoBehaviour {

	public Text round;

	void Start() {
		if (PlayerPrefs.GetInt ("RoundNumber") != null) {
			round.text = PlayerPrefs.GetInt ("RoundNumber").ToString ();
		} else {
			round.text = "did not work";
		}
	}
}
