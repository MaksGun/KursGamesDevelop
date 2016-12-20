using UnityEngine;
using System.Collections;

    public class CubeJump : MonoBehaviour {
	public static bool jump, NextBlock; 
	public GameObject mainCube, buttons, loseButtons ; 
	private bool animate, lose, addLose;
	private float Scr_Speed =  0.5f, startTime,yPosCube ; 
	public static int count_blocks; 

	void Awake () {
		jump = false; 
		NextBlock = false; 
	}
	void Start () {
		StartCoroutine (CanJump()); 
	}

	void FixedUpdate () {   //кубик сжимае и разжимаем 
		if (animate && mainCube.transform.localScale.y > 0.4)
			PressCube (-Scr_Speed);
		else if (!animate && mainCube !=null) {
			if (mainCube.transform.localScale.y < 1f)
				PressCube (Scr_Speed * 3f);
			else if (mainCube.transform.localScale.y != 1f)
				mainCube.transform.localScale = new Vector3 (1f, 1f, 1f);
			
		}
		if (mainCube != null) {
			if (mainCube.transform.position.y < -5) {
				Destroy (mainCube, 0.5f);
				//print ("Losee");
				lose = true; 
			}
		}

		if (lose && !addLose)
			PlayerLose (); 
	} 

	void PlayerLose () {
		addLose = true; 
		buttons.GetComponent <ScrollObjects> ().speed = 10f; 
		buttons.GetComponent <ScrollObjects> ().checkPos = 0; 
		if (!loseButtons.activeSelf)
			loseButtons.SetActive (true); 
		loseButtons.GetComponent <ScrollObjects> ().checkPos = 0; 
		loseButtons.GetComponent <AudioSource> ().Play();
	}

	void OnMouseDown () {
		
		if (NextBlock && mainCube.GetComponent <Rigidbody> ()) {
			animate = true; 
			startTime = Time.time; 
			yPosCube = mainCube.transform.localPosition.y; 
		}
	}

	void OnMouseUp() {
		
		if (NextBlock && mainCube.GetComponent <Rigidbody> ()) {
			animate = false; 

			//Jump
			jump = true; 
			float force, diff;
			diff = Time.time - startTime; 
			if (diff < 3f)
				force = 190 * diff; 
			else 
				force = 280f; 
			if (force < 60)
				force = 60; 
			
			mainCube.GetComponent<Rigidbody> ().AddRelativeForce (mainCube.transform.up * force); 
			mainCube.GetComponent<Rigidbody> ().AddRelativeForce (mainCube.transform.right * -force); 

			StartCoroutine (checkCube ()); 
			NextBlock = false; 
		}
	}

	void PressCube (float force) {
		mainCube.transform.localPosition += new Vector3 (0f, force * Time.deltaTime, 0f); 
		mainCube.transform.localScale += new Vector3 (0f, force * Time.deltaTime, 0f); 
	}

	IEnumerator checkCube () {
		yield return new WaitForSeconds (1.5f); 
		if (yPosCube == mainCube.transform.localPosition.y) {
			//print ("Lose");
			lose = true; 
		}
		else {
			while (!mainCube.GetComponent <Rigidbody> ().IsSleeping ()) {
				yield return new WaitForSeconds (0.05f);
				if (mainCube == null) 
					break; 
			}
			if (!lose) {
				NextBlock = true; 
				count_blocks++; 
				//print ("Next");

				mainCube.transform.localPosition = new Vector3 (-1f, mainCube.transform.localPosition.y, mainCube.transform.localPosition.z); 
				mainCube.transform.eulerAngles = new Vector3 (0f, mainCube.transform.eulerAngles.y, 0f); 
			}
		}
	}

	IEnumerator  CanJump () {
		while (!mainCube.GetComponent <Rigidbody> ()) 
			yield return new WaitForSeconds (0.05f);
		yield return new WaitForSeconds (1f); 
		NextBlock = true; 
	     }
}
