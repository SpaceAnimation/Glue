
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public GameObject player;
	public Rigidbody energySource;
	public Rigidbody driver;
	public float x;
	public float z;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		x = Input.GetAxis ("Horizontal") * Time.deltaTime * 150.0f;
		z = Input.GetAxis ("Vertical") * Time.deltaTime * 3.0f;

		energySource.gameObject.transform.Rotate (0, x, 0);
		energySource.gameObject.transform.Translate (0, 0, z);
	}

	void FixedUpdate()
	{

	
	}
}
