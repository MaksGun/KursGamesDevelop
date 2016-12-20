using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountsDiamonds : MonoBehaviour {

	private Text txt; 

	void Start () {
		txt = GetComponent <Text> ();
		txt.text = PlayerPrefs.GetInt ("Diamonds").ToString (); 
	}

}
