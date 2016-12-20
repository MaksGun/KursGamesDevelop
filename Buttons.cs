using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement; 
public class Buttons : MonoBehaviour {

	public GameObject shopBG; 
	public float bigger = 17f, lower = 15f; 
	public Sprite music_on, music_off;

	void Start () {
		if (gameObject.name == "Settings") {
			if (PlayerPrefs.GetString ("Music") == "off") {
				transform.GetChild(0).gameObject.GetComponent <SpriteRenderer> ().sprite = music_off; 
				Camera.main.GetComponent <AudioListener> ().enabled = false; 
			}
		}
	}
	void OnMouseDown ()
	{
		
		transform.localScale = new Vector3  (bigger, bigger, bigger );
	}
	void OnMouseUp ()
	{
		transform.localScale = new Vector3 (lower, lower, lower) ;
	}

	void OnMouseUpAsButton () {
		GetComponent <AudioSource> ().Play(); 
		switch (gameObject.name) {
		case "Restart": 
			SceneManager.LoadScene ("Main"); 
			break;

		case "Info": 
			Application.OpenURL ("https://vk.com/maks_gun");
			break;

		case "Music":
			if (PlayerPrefs.GetString ("Music") == "off") { //вкл 
				GetComponent <SpriteRenderer> ().sprite = music_on; 
				PlayerPrefs.SetString ("Music", "on");
				//Camera.main.GetComponent <AudioListener> ().enabled = true;
				AudioListener.volume = 0.7F;
			} else {//выкл
				GetComponent <SpriteRenderer> ().sprite = music_off; 
				PlayerPrefs.SetString ("Music", "off");
				//Camera.main.GetComponent <AudioListener> ().enabled = false;
				AudioListener.volume = 0;
			}
			break; 

		case "Settings":

			for (int i = 0; i < transform.childCount; i++) 
				transform.GetChild (i).gameObject.SetActive (!transform.GetChild (i).gameObject.activeSelf);
			break;
		case "Shop":
			shopBG.SetActive (!shopBG.activeSelf); 
			break;
		case "Close":
			shopBG.SetActive (false); 
			break;
		}
	}
}
