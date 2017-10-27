using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NewGameClick : MonoBehaviour {


    /*
	// Use this for initialization
	void Start () {
		
	}
    */
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        Debug.Log("Clicked the text! Debug Me!!!!");
        SceneManager.LoadScene(0);
    }
}
