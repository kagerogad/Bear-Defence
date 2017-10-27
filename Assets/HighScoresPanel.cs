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

	private int newestRoundNumber;
	private string newestName;

	private int[] roundNumbers;
	private string[] names;

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

	void Awake() {
		/*PlayerPrefs.SetInt ("firstPlaceRoundNumber", 0);
		PlayerPrefs.SetInt ("secondPlaceRoundNumber", 0);
		PlayerPrefs.SetInt ("thirdPlaceRoundNumber", 0);
		PlayerPrefs.SetInt ("fourthPlaceRoundNumber", 0);
		PlayerPrefs.SetInt ("fifthPlaceRoundNumber", 0);
		PlayerPrefs.SetInt ("newestRoundNumber", 0);*/

		Debug.Log (" MainMenu boi!! " + PlayerPrefs.GetString ("newestName") + " newestroundNumber: " + PlayerPrefs.GetInt("newestRoundNumber"));
		roundNumbers = new int[5];
		names = new string[5];

		newestName = PlayerPrefs.GetString ("newestName", "");
		newestRoundNumber = PlayerPrefs.GetInt ("newestRoundNumber", 0);

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

		roundNumbers [0] = firstPlaceRoundNumber;
		roundNumbers [1] = secondPlaceRoundNumber;
		roundNumbers [2] = thirdPlaceRoundNumber;
		roundNumbers [3] = fourthPlaceRoundNumber;
		roundNumbers [4] = fifthPlaceRoundNumber;

		names [0] = firstPlaceName;
		names [1] = secondPlaceName;
		names [2] = thirdPlaceName;
		names [3] = fourthPlaceName;
		names [4] = fifthPlaceName;

		Debug.Log (firstPlaceName);
		DisplayHighScores ();

	}

	public void UpdatePlace() {
		int place = 5;
		bool wasPlaceChanged = false;
		for (int i = 0; i < 5; i++) {
			if (newestRoundNumber > roundNumbers[i]) {
				wasPlaceChanged = true;
				place = i;
				break;
			}
		}
		if (wasPlaceChanged) {
			for (int i = 4; i >= place; i--) {
				if (i == place) {
					roundNumbers [i] = newestRoundNumber;
					names [i] = newestName;
				} else {
					roundNumbers [i] = roundNumbers [i - 1];
					names [i] = names [i - 1];
				}
			}
		}

		PlayerPrefs.SetString ("firstPlaceName", names[0]);
		PlayerPrefs.SetString ("secondPlaceName", names[1]);
		PlayerPrefs.SetString ("thirdPlaceName", names[2]);
		PlayerPrefs.SetString ("fourthPlaceName", names[3]);
		PlayerPrefs.SetString ("fifthPlaceName", names[4]);

		PlayerPrefs.SetInt("firstPlaceRoundNumber", roundNumbers[0]);
		PlayerPrefs.SetInt ("secondPlaceRoundNumber", roundNumbers[1]);
		PlayerPrefs.SetInt ("thirdPlaceRoundNumber", roundNumbers[2]);
		PlayerPrefs.SetInt ("fourthPlaceRoundNumber", roundNumbers[3]);
		PlayerPrefs.SetInt ("fifthPlaceRoundNumber", roundNumbers[4]);
	}

	public void DisplayHighScores() {
		UpdatePlace ();
		if (roundNumbers [0] > 0) {
			firstPlace.enabled = true;
			firstPlace.text = names[0];
		} else {
			firstPlace.enabled = false;
		}
			
		if (roundNumbers [1] > 0) {
			secondPlace.enabled = true;
			secondPlace.text = names[1];
		} else {
			secondPlace.enabled = false;
		}
			
		if (roundNumbers [2] > 0) {
			thirdPlace.enabled = true;
			thirdPlace.text = names[2];
		} else {
			thirdPlace.enabled = false;
		}
			
		if (roundNumbers [3] > 0) {
			fourthPlace.enabled = true;
			fourthPlace.text = names[3];
		} else {
			fourthPlace.enabled = false;
		}
			
		if (roundNumbers [4] > 0) {
			fifthPlace.enabled = true;
			fifthPlace.text = names[4];
		} else {
			fifthPlace.enabled = false;
		}
	}



}
