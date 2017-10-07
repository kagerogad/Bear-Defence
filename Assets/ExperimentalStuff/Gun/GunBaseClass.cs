using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBaseClass : MonoBehaviour {

	[Header("References")]
	public GameObject projectile;
	public Transform FirePosition;
	public Transform target;

	[Header("Attributes")]
	public float fireRate;
	public float coolDown;				//<---------MAYBE


}
