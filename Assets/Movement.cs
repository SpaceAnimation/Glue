
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public GameObject player;
	public Rigidbody energySource;
	public Rigidbody driver;
	public Vector3 velocity;
	public float MAXSPEED;
	public float x;
	public Vector3 z;

	// Use this for initialization
	void Start () {
		velocity = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		x = Input.GetAxis ("Horizontal") * Time.deltaTime * 150.0f;
		z.z = Input.GetAxis ("Vertical") * Time.deltaTime;//* 3.0f;
		if(z.z < MAXSPEED)
			velocity += z;
		
		energySource.gameObject.transform.Rotate (0, x, 0);
		energySource.gameObject.transform.Translate (velocity);
	}

	void FixedUpdate()
	{

	
	}
}
