using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RSBCrotation : MonoBehaviour {

	private Rigidbody rb;
	public float force;

	void Start(){
		rb = GetComponent<Rigidbody> ();
	}
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (45,45,45) * Time.deltaTime*5,Space.Self);
	}

	void FixedUpdate(){
		rb.AddForce (force * Vector3.up);
	}

}
