using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	public Vector3 velocity;
	public float smoothSpeed = 0.125f;
	public Vector3 offset;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		Vector3 desieredPos = target.position + offset;
		Vector3 smoothPos = Vector3.Lerp(transform.position, desieredPos, smoothSpeed);
		transform.position = smoothPos;

		transform.LookAt (target);
	}
}
