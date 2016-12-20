using UnityEngine;
using System.Collections;

public class SelectCube : MonoBehaviour {
	public GameObject selectCube, buyCube, mainCube; 

	[HideInInspector]
	public string nowCube; 

	void Start () {
		if (PlayerPrefs.GetString ("Cube_0") != "Open")
			PlayerPrefs.SetString ("Cube_0", "Open"); 
	}

	void OnTriggerEnter (Collider other) {
		GetComponent <AudioSource> ().Play();
		nowCube = other.gameObject.name;
		other.transform.localScale += new Vector3 (0.4f, 0.4f, 0.4f);
		if (PlayerPrefs.GetString (other.gameObject.name) == "Open") {
			selectCube.SetActive (true); 
			buyCube.SetActive (false);
		
		} else {
			selectCube.SetActive (false); 
			buyCube.SetActive (true);
		}
	}

	void OnTriggerExit (Collider other) {
		other.transform.localScale -= new Vector3 (0.4f,0.4f,0.4f);
	}
}
