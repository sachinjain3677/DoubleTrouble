using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour {

	public Button play;
	public Button info;
	public Button exit;
	public Button rArrow;
	//public Button lArrowControls;
	public Button lArrowiMenu2;
	public Button controls;
	public Button infoControlsMenu;
	public Button cross1;
	public Button cross2;
	public Button cross3;
	public Button cross4;
	public Button yes;
	public Button no;
	//public AudioClip soundFile;
	//public GameObject source;

	public GameObject infoMenu1;
	public GameObject infoMenu2;
	public GameObject controlsMenu;
	public GameObject exitMenu;

	// Use this for initialization
	void Start () {
		infoMenu1.SetActive (false);
		infoMenu2.SetActive (false);
		controlsMenu.SetActive (false);
		exitMenu.SetActive (false);

		//source.SetActive (false);
		cross1 = cross1.GetComponent<Button> ();
		cross2 = cross2.GetComponent<Button> ();
		cross3 = cross3.GetComponent<Button> ();
		cross4 = cross4.GetComponent<Button> ();
		yes = yes.GetComponent<Button> ();
		no = no.GetComponent<Button> ();
		play = play.GetComponent<Button> ();
		info = info.GetComponent<Button> ();
		exit = exit.GetComponent<Button> ();
		rArrow = rArrow.GetComponent<Button> ();
		//lArrowControls = lArrowControls.GetComponent<Button> ();
		lArrowiMenu2 = lArrowiMenu2.GetComponent<Button> ();
		controls = controls.GetComponent<Button> ();
		infoControlsMenu = infoControlsMenu.GetComponent<Button> ();
	}

	public void pressPlay(){
		SceneManager.LoadScene (1);
	}

	public void pressInfo(){
		infoMenu1.SetActive (true);
		play.enabled = false;
		info.enabled = false;
		exit.enabled = false;
		//source.SetActive (true);
	}

	public void pressRArrowiMenu1(){
		infoMenu1.SetActive (false);
		infoMenu2.SetActive (true);
		
	}

	public void pressLArrowiMenu2(){
		infoMenu2.SetActive (false);
		infoMenu1.SetActive (true);
		
	}

	public void pressControls(){
		controlsMenu.SetActive (true);
		infoMenu2.SetActive (false);
		
	}

	public void pressInfoControlsMenu(){
		controlsMenu.SetActive (false);
		infoMenu2.SetActive (true);
		
	}

	public void pressCross1(){
		infoMenu1.SetActive (false);
		play.enabled = true;
		info.enabled = true;
		exit.enabled = true;
		
	}

	public void pressCross2(){
		infoMenu2.SetActive (false);
		play.enabled = true;
		info.enabled = true;
		exit.enabled = true;
		
	}


	public void pressCross3(){
		controlsMenu.SetActive (false);
		play.enabled = true;
		info.enabled = true;
		exit.enabled = true;
		
	}





	public void pressExit(){
		exitMenu.SetActive (true);
		play.enabled = false;
		info.enabled = false;
		exit.enabled = false;
		
	}

	public void pressYes(){
		Application.Quit();
	}

	public void pressNo(){
		exitMenu.SetActive (false);
		play.enabled = true;
		info.enabled = true;
		exit.enabled = true;
		
	}

	public void pressCross4(){
		exitMenu.SetActive (false);
		play.enabled = true;
		info.enabled = true;
		exit.enabled = true;
		
	}
}
