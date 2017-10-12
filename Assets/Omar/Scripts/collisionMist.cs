using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionMist : MonoBehaviour {

    private Transform mist;
    private Collider box;

    // Use this for initialization
    void Start()
    {
        mist = transform.GetChild(0);
        box = GetComponent<Collider>();
    }
	// Update is called once per frame
	void Update () {
           // mist.position = new Vector3(0f, -200f, 0f);
        }

    void OnCollisionEnter(Collision collision)
    {
        mist.position = new Vector3(0f, -200f, 0f);
        box.enabled = false;
    }
}
