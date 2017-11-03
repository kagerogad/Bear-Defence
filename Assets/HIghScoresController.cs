using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HIghScoresController : MonoBehaviour {

	int roundNumber;
	void Start () {
		
		roundNumber = PlayerPrefs.GetInt ("RoundNumber", 0);
	}
}
