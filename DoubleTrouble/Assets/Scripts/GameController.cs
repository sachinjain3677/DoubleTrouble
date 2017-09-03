using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GameController : MonoBehaviour {

	//public static int fallingObjectColor;
	public static int count=0;
	public int gPickedRed = 0;
	public int gPickedBlue = 0;

	public GameObject collectible1;
	public GameObject collectible2;
	public GameObject collectible3;
	public GameObject collectible4;
	public GameObject bigShotGolden;
	public GameObject bigShotBlack;
	public Vector3 spawnValues;
	public float spawnWait;
	//public float spawnWaitRapidFire;
	public float spawnWaitBonus;
	public float changePhase;
	public int objectsCollected;
	//public Text restartText;
	public Text objectsCollectedText;
	//public Text gameOverText;
	public bool gameOver;
	public GameObject gameOverText;
	public Text gameOverScore;
	public Text penalty;


	private bool restart;
	private int penaltyValue;


	void Start () {
		gameOverText.SetActive (false);
		gameOver = false;
		restart = false;
		penaltyValue = 0;
		penalty.text = "Moves: " + penaltyValue;
		objectsCollected = 0;
		objectsCollectedText.text = "ObjectsCollected: "+objectsCollected;
		//restartText.text = "";
		//gameOverText.text = "";
		StartCoroutine (spawnWaves ());
	}

	void bonus(){
		StartCoroutine (bonusSpawn ());
	}

	IEnumerator bonusSpawn(){
		if (!gameOver) {
			for (int i = 0; i < 20; i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x - 1), spawnValues.y, spawnValues.z);
				float selector = Random.Range (0.0f, 2.0f);
				Quaternion spawnRotation = Quaternion.identity;
				if (selector < 0.4f) {
					Instantiate (bigShotGolden, spawnPosition, spawnRotation);
				} else {
					Instantiate (bigShotBlack, spawnPosition, spawnRotation);
				}

				yield return new WaitForSeconds (spawnWaitBonus);
			}
		}

		yield return null;
	}


	IEnumerator spawnWaves(){

		//fallingObjectColor=0 for BlueSphered and 1 for RedSphered

		for (int i = 0;; i++) {
			if (!gameOver) {
				if (count % 8 == 0 && count!=0) {
					yield return new WaitForSeconds (changePhase);
					bonus ();
					yield return new WaitForSeconds (changePhase);
				} else {
					Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x - 1), spawnValues.y, spawnValues.z);
					float selector = Random.Range (0.0f, 4.0f);
					Quaternion spawnRotation = Quaternion.identity;
					if (selector < 1.0) {
						Instantiate (collectible1, spawnPosition, spawnRotation);
						//fallingObjectColor = 0;
					} else if (selector < 2.0) {
						Instantiate (collectible2, spawnPosition, spawnRotation);
						//fallingObjectColor = 0;
					} else if (selector < 3.0) {
						Instantiate (collectible3, spawnPosition, spawnRotation);
						//fallingObjectColor = 1;
					} else {
						Instantiate (collectible4, spawnPosition, spawnRotation);
						//fallingObjectColor = 1;
					}
					count++;
					//count++;

					yield return new WaitForSeconds (spawnWait);
				}
			}

			yield return null;
		}
	}

	public void Update () {
		if (!gameOver) {
			if (Input.GetKeyDown (KeyCode.A) || Input.GetKeyDown (KeyCode.D) || Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown (KeyCode.RightArrow)) {
				penaltyValue++;
				UpdateScore ();
			}
		}

		if (restart) {
			if (Input.GetKeyDown (KeyCode.Return)) {
				count = 0;
				SceneManager.LoadScene ("Main");
			}
		}
	}

	public void UpdateScore(){
		gameOverScore.text="Final Score: "+(objectsCollected-penaltyValue);
		objectsCollectedText.text = "Objects Collected: " + objectsCollected;
		penalty.text = "Moves: " + penaltyValue;
	}

	public void GameOver(){
		//gameOverText.text="Game Over!!";
		gameOverText.SetActive(true);
		SetRestart ();
	}

	void SetRestart(){
		//restartText.text="Press 'R' to restart";
		restart = true;
	}
}
