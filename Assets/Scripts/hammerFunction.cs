using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hammerFunction : MonoBehaviour {

	//public static int numOfHam;
	public GameObject Hammer;
	public GameObject Hammer1;
	public GameObject Hammer2;

	public AudioSource audioCube;  

	public Color topColor  ;
	public Color downColor  ;


	public Text Score;
	public Text Hammers;

	int hammerScore = 100;
	int hitCounter = 0 ;
	float lerp = 0;

	int hammerCounter=0;

	public static float score = 0;

	private Ray ray; // The ray
	private RaycastHit hit; // What we hit
	private GameObject cubeToDestroy ;


	// Use this for initialization
	void Start () {


		Score.text = "Score : " + 0.ToString ();  
		Hammers.text = "Hammers : " + readFile.hammers.ToString();
	}
	
	// Update is called once per frame
	void Update () {

		ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Ray will be sent out from where your mouse is located    

		if (Physics.Raycast (ray, out hit, 1.0f) && Input.GetMouseButtonDown (0)) {   // On left click we send down a ray


			score = (readFile.N * readFile.N) - (hammerCounter) * 50 - Time.time;

			if (hammerScore > 0) {
				
				Score.text = "Score : " + 0.ToString ();  
				Hammers.text = "Hammers : " + readFile.hammers.ToString ();

				Hammer1.GetComponent<Renderer>().material.color = Color.Lerp (topColor, Color.black, lerp);
				Hammer2.GetComponent<Renderer>().material.color = Color.Lerp (downColor, Color.black, lerp);

				hammerScore = hammerScore - 10;
				lerp = 1- (hammerScore) * 0.01f;


			} else {



				lerp = 0;
				Hammer1.GetComponent<Renderer>().material.color = Color.Lerp (topColor, Color.black, lerp);
				Hammer2.GetComponent<Renderer>().material.color = Color.Lerp (downColor, Color.black, lerp);

				hammerCounter++;
				readFile.hammers--;
				hammerScore = 100;


				Score.text = "Score : " + 0.ToString ();  
				Hammers.text = "Hammers : " + readFile.hammers.ToString ();
				hammerScore = hammerScore - 10;

			}


			hitCounter++;

			if (hitCounter == 1) {
				cubeToDestroy = hit.collider.gameObject;
			}

			if (hitCounter >= 3) {

				if (cubeToDestroy == hit.collider.gameObject) {
					Destroy (hit.collider.gameObject);  // Destroy what we hit

					audioCube.Play ();
				}

				hitCounter = 0;
					
			}
		}
		
	}
}
