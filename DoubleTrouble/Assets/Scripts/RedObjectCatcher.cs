using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedObjectCatcher : MonoBehaviour {

	//public GameObject explosionEnemySmall;
	//public GameObject explosionEnemyBig;
	//public GameObject explosionSelf;


	private GameController gameController;

	//private bool gameOver;

	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController> ();
		}
		if (gameController == null) {
			Debug.Log ("Cannot find 'GameController' script");
		}
		//gameController.gameOver = false;	
	}
	

	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if (gameController.gameOver != true) {
			if (other.tag == "RedSpheredCollectible") {
				Destroy (other.gameObject);
				gameController.objectsCollected += 3;
				//Instantiate (explosionEnemySmall, other.transform.position, other.transform.rotation);
				gameController.UpdateScore ();
			} else if (other.tag == "BlueSpheredCollectible") {
				Destroy (other.gameObject);
				Destroy (gameObject);
				//Instantiate (explosionEnemySmall, other.transform.position, other.transform.rotation);
				gameController.GameOver ();
				gameController.gameOver = true;
			} else if (other.tag == "goldenBigShot") {
				Destroy (other.gameObject);
				gameController.objectsCollected += 20;
				//Instantiate (explosionEnemyBig, other.transform.position, other.transform.rotation);
				gameController.UpdateScore ();
				gameController.gPickedRed++;
			} else if (other.tag == "blackBigShot") {
				Destroy (other.gameObject);
				//Instantiate (explosionEnemyBig, other.transform.position, other.transform.rotation);
				Destroy (gameObject);
				//Instantiate (explosionSelf, transform.position, transform.rotation);
				gameController.GameOver ();
				gameController.gameOver = true;
			}
		} else {
			if (other.tag != "PlayerBlue") {
				Destroy (other.gameObject);
			}
		}
	}
}
