using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CollectDiamonds : MonoBehaviour {
	public Text diamonds; 
	public AudioClip collectDiamonds; 

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Diamond") {
			Destroy (other.gameObject);
			PlayerPrefs.SetInt ("Diamonds", PlayerPrefs.GetInt ("Diamonds") +1); 
			diamonds.text = PlayerPrefs.GetInt ("Diamonds").ToString (); 
			GetComponent <AudioSource> ().clip = collectDiamonds; 
			GetComponent <AudioSource> ().Play();
		}
	}
}
