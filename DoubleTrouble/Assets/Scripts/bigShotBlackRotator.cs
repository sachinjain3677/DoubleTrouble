using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigShotBlackRotator : MonoBehaviour {

	private Rigidbody rb;

	public float force;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (15, 30, 15) * Time.deltaTime * 10, Space.Self);
	}

	void FixedUpdate(){
		rb.AddForce (force * Vector3.down);
	}
}
