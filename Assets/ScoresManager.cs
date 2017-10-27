using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoresManager : MonoBehaviour {
	public Text tex;
	string name;
	int roundNumber;

	public void UpdateName() {
		name = tex.text;
		roundNumber = GameManager.instance.roundNumber;
		PlayerPrefs.SetString ("newestName", name);
		PlayerPrefs.SetInt ("newestRoundNumber", roundNumber);
		Debug.Log ("Name was Updated: " + name);
	}
}
