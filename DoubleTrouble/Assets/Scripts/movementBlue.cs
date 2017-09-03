using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementBlue : MonoBehaviour {

	public float speed;
	public float xMin, xMax;
	public float tilt;
	public KeyCode control;


	private Rigidbody rb;
	private GameController gameController;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController> ();
		}
		if (gameController == null) {
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	// Update is called once per frame
	void Update () {
		float moveHorizontal;
		if (gameController.gPickedBlue % 2 == 0) {
			moveHorizontal = Input.GetAxis ("HorizontalBlue");
		} else {
			moveHorizontal = -Input.GetAxis ("HorizontalBlue");
		}
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, 0.0f);
		rb.velocity = movement * speed;
		rb.position = new Vector3 (Mathf.Clamp (rb.position.x, xMin, xMax), -3.0f, 0.0f);
		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -tilt);	
	}
}
