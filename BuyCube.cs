using UnityEngine;
using System.Collections;

public class BuyCube : MonoBehaviour {
	
	public GameObject whichCube, selectBtn, mainCube; 


	void OnMouseDown () {
		if (PlayerPrefs.GetInt ("Diamonds") >= 50) { //buy
			PlayerPrefs.SetString (whichCube.GetComponent <SelectCube> ().nowCube, "Open");
			PlayerPrefs.SetString ("Now Cube", whichCube.GetComponent <SelectCube> ().nowCube);
			PlayerPrefs.SetInt ("Diamonds", PlayerPrefs.GetInt ("Diamonds") - 50);
			mainCube.GetComponent <MeshRenderer> ().material = GameObject.Find (whichCube.GetComponent <SelectCube> ().nowCube).GetComponent <MeshRenderer> ().material; 
			selectBtn.SetActive (true); 
			gameObject.SetActive (false); 
			GetComponentInParent <AudioSource> ().Play();
		} 
	}

}
