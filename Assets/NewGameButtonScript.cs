using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameButtonScript : MonoBehaviour {

public void NewGame()
    {
		Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
