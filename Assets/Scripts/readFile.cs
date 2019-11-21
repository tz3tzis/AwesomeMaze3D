using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System;
using UnityStandardAssets.Characters.FirstPerson;


public class readFile : MonoBehaviour {

	public GameObject player;

	public static int levels;
	public static int N;
	public static int hammers;

	public static int randomPosition = 0;


	void Start(){
		readTxt ();
	}


	void readTxt(){

		int levelCounter = 1;
		string line;
		int positionCounter = 0;

		List<string> array = new List<string> ();

		string[] cutStr = new string[]{ "L=", "N=", "K=", "LEVEL", "E", "R", "G", "B", "T1", "T2", "T3", "W" };


		ArrayList playerPosition = new ArrayList ();

		int i = 0;  // z coordinate
		int j = -1;  // y coordinate
		int k = 0;  // x coordinate

		using (StreamReader file = new System.IO.StreamReader ("maze.txt.txt")) {

			while ((line = file.ReadLine ()) != null) {


				foreach (string word in line.Split(' ')) {

					//avoid unwanted characters and trim unwanted values
					if (word.StartsWith (cutStr [0])) {

						array.Add (word.Remove (0, 2));

					} else if (word.StartsWith (cutStr [1])) {

						array.Add (word.Remove (0, 2));
				
					} else if (word.StartsWith (cutStr [2])) {

						array.Add (word.Remove (0, 2));
			
					} else if (word.StartsWith (cutStr [3])) {

						array.Add ("L" + levelCounter.ToString ());

						levelCounter++; 


						j++; i = 0; k = -1;

					} else if (word.StartsWith (cutStr [4])) {

						array.Add (word);
			
						//ADD TO ARRAYLIST BLANK CUBES
						if(j == 2){ 
							playerPosition.Add (new Vector3(k,2,i));
							positionCounter++;
						}

						i++;

					} else if (word.StartsWith (cutStr [5])) {

						array.Add (word);
						GameObject cube5 = (GameObject)  Instantiate (Resources.Load("cubeRed"), new Vector3 (k*2f, j*2f, i * 2f), Quaternion.identity);
						i++;

					} else if (word.StartsWith (cutStr [6])) {

						array.Add (word);
						GameObject cube6 = (GameObject)  Instantiate (Resources.Load("cubeGreen"), new Vector3 (k*2f, j*2f, i * 2f), Quaternion.identity);
						i++;

					} else if (word.StartsWith (cutStr [7])) {

						array.Add (word);
						GameObject cube7 = (GameObject)  Instantiate (Resources.Load("cubeBlue"), new Vector3 (k*2f, j*2f, i * 2f), Quaternion.identity);
						i++;

					} else if (word.StartsWith (cutStr [8])) {

						array.Add (word);
						GameObject cube8 = (GameObject)  Instantiate (Resources.Load("cubeT1"), new Vector3 (k*2f, j*2f, i * 2f), Quaternion.identity);
						i++;

					} else if (word.StartsWith (cutStr [9])) {

						array.Add (word);
						GameObject cube9 = (GameObject)  Instantiate (Resources.Load("cubeT2"), new Vector3 (k*2f, j*2f, i * 2f), Quaternion.identity);
						i++;

					} else if (word.StartsWith (cutStr [10])) {

						array.Add (word);
						GameObject cube10 = (GameObject)  Instantiate (Resources.Load("cubeT3"), new Vector3 (k*2f, j*2f, i * 2f), Quaternion.identity);
						i++;

					} else if (word.StartsWith (cutStr [11])) {

						array.Add (word);
						GameObject cube11 = (GameObject)  Instantiate (Resources.Load("cubeBlack"), new Vector3 (k*2f, j*2f, i * 2f), Quaternion.identity);


						i++;
					}

				}

				i = 0; k++;

			}
		} 

		levels = Int32.Parse (array [0]);
		N = Int32.Parse (array [1]);
		hammers = Int32.Parse (array [2]);


		/////////////////////////////////////////gemisma me leuka koutia gia ta oria tou maze///////////////////////////////////////////////
		for(int p = 0; p<N; p++){
			for(int q = 0; q<levels; q++ ){
				GameObject Bounders = (GameObject)Instantiate (Resources.Load ("Bounders"), new Vector3 (2f * (-1), 2f * q, 2f * p), Quaternion.identity);

			}
		}

		for(int p = 0; p<N ;p++){
			for(int q = 0; q<levels; q++ ){
				GameObject Bounders = (GameObject)  Instantiate (Resources.Load("Bounders"), new Vector3 (2f*p, 2f*q,  2f*(-1)), Quaternion.identity);
			}
		}

		for(int p = 0; p<N; p++){
			for(int q = 0; q<levels; q++ ){
				GameObject Bounders = (GameObject)  Instantiate (Resources.Load("Bounders"), new Vector3 (2f*p, 2f*q,  2f*N), Quaternion.identity);
			}
		}

		for(int p = 0; p<N; p++){
			for(int q = 0; q<levels; q++ ){
				GameObject Bounders = (GameObject)  Instantiate (Resources.Load("Bounders"), new Vector3 (2f*N, 2f*q,  2f*p), Quaternion.identity);
			}
		}





		//put player at random position
		randomPosition = UnityEngine.Random.Range(0,positionCounter);
		player = GameObject.Find ("FPSController");
		Vector3 positionPl = (Vector3) playerPosition[randomPosition];
		player.transform.position  = positionPl;




	}
}  




