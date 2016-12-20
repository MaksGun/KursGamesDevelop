using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShopBG : MonoBehaviour {
	public GameObject detectClicks, AllCubes, PlayText, LoseBut; 
	private bool activeLose, activePlayText; 

	void OnEnable () {
		if (PlayText.activeSelf) {
			activePlayText = true; 
			PlayText.SetActive (false);
		}
		detectClicks.GetComponent<BoxCollider> ().enabled = false; 
		AllCubes.SetActive (true); 
		if (LoseBut.activeSelf) {
			activeLose = true; 
			LoseBut.SetActive (false);
		}
	}

	void OnDisable () {
		if (activeLose)
			LoseBut.SetActive (true);
		if (activePlayText)
		PlayText.SetActive (true);
		detectClicks.GetComponent<BoxCollider> ().enabled = true; 
		AllCubes.SetActive (false); 

	}
}
