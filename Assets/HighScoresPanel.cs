using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoresPanel : MonoBehaviour {

	public Text firstPlace;
	public Text secondPlace;
	public Text thirdPlace;
	public Text fourthPlace;
	public Text fifthPlace;

	private int firstPlaceRoundNumber;
	private string firstPlaceName;

	private int secondPlaceRoundNumber;
	private string secondPlaceName;

	private int thirdPlaceRoundNumber;
	private string thirdPlaceName;

	private int fourthPlaceRoundNumber;
	private string fourthPlaceName;

	private int fifthPlaceRoundNumber;
	private string fifthPlaceName;

	void start() {
		firstPlaceName = PlayerPrefs.GetString ("firstPlaceName", "...");
		secondPlaceName = PlayerPrefs.GetString ("secondPlaceName", "...");
		thirdPlaceName = PlayerPrefs.GetString ("thirdPlaceName", "...");
		fourthPlaceName = PlayerPrefs.GetString ("fourthPlaceName", "...");
		fifthPlaceName = PlayerPrefs.GetString ("fifthPlaceName", "...");

		firstPlaceRoundNumber = PlayerPrefs.GetInt("firstPlaceRoundNumber", 0);
		secondPlaceRoundNumber = PlayerPrefs.GetInt ("secondPlaceRoundNumber", 0);
		thirdPlaceRoundNumber = PlayerPrefs.GetInt ("thirdPlaceRoundNumber", 0);
		fourthPlaceRoundNumber = PlayerPrefs.GetInt ("fourthPlaceRoundNumber", 0);
		fifthPlaceRoundNumber = PlayerPrefs.GetInt ("fifthPlaceRoundNumber", 0);

		Debug.Log (firstPlaceName);
	}

	public void DisplayHighScores() {
		if (firstPlaceRoundNumber > 0) {
			firstPlace.enabled = true;
			firstPlace.text = firstPlaceName;
		} else {
			firstPlace.enabled = false;
		}

		if (secondPlaceRoundNumber > 0) {
			secondPlace.enabled = true;
			secondPlace.text = secondPlaceName;
		} else {
			secondPlace.enabled = false;
		}

		if (thirdPlaceRoundNumber > 0) {
			thirdPlace.enabled = true;
			thirdPlace.text = thirdPlaceName;
		} else {
			thirdPlace.enabled = false;
		}

		if (fourthPlaceRoundNumber > 0) {
			fourthPlace.enabled = true;
			fourthPlace.text = fourthPlaceName;
		} else {
			fourthPlace.enabled = false;
		}

		if (fifthPlaceRoundNumber > 0) {
			fifthPlace.enabled = true;
			fifthPlace.text = fifthPlaceName;
		} else {
			fifthPlace.enabled = false;
		}
	}



}
