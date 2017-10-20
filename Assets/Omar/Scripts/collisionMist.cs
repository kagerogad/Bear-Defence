using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class collisionMist : MonoBehaviour {

    //private Transform mist;
    private Collider box;
	private NavMeshObstacle barrier;

    // Use this for initialization
    void Start()
    {
        //mist = transform.GetChild(0);
        box = GetComponent<Collider>();
		barrier = GetComponent<NavMeshObstacle> ();
    }
	// Update is called once per frame
	void Update () {
           // mist.position = new Vector3(0f, -200f, 0f);
        }

	void OnTriggerEnter(Collider col)
    {
		Debug.Log ("Touched barrier: " + this.name);
        //mist.position = new Vector3(0f, -200f, 0f);
    }

	void OnCollisionExit(Collision collision) {
	}

	void OnDrawGizmosSelected() {
		Gizmos.color = Color.yellow;
		Gizmos.DrawCube (transform.position, transform.localScale * 10f);
	}
}
