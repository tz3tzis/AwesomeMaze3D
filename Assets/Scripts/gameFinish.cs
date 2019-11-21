using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;


public class gameFinish : MonoBehaviour {

	public Text GameOver;
	public AudioSource jumpSound;
	public AudioSource winSound;

	// Update is called once per frame
	void Update () {
		
		float posY = GameObject.Find("FPSController").transform.position.y;

		if(Input.GetKey(KeyCode.X) ){
			
			Application.Quit ();	
		}

		if(Input.GetKeyDown(KeyCode.Space)){
			
			jumpSound.Play ();

		}

		if ((Input.GetKeyDown (KeyCode.E) && posY >(readFile.levels*1.9))   ) {
			
			StartCoroutine(handleWin());
		}

		if(posY < 0 ){
			
			StartCoroutine(handleLose());
		}
			

	}

	private IEnumerator handleWin(){

		GameOver.text = "YOU WIN!! "+ '\n'+ "Score : " + hammerFunction.score.ToString() ;

		winSound.Play ();
		GameObject.Find("FPSController").GetComponent<FirstPersonController> ().enabled = false;

		yield return new WaitForSeconds (10);
		Application.Quit ();

	}


	private IEnumerator handleLose(){
		
		GameOver.text = "YOU LOSE!! "+ '\n'+ "Score : " + 0.ToString() ;

		yield return new WaitForSeconds (10);
		Application.Quit ();
	}
}
