using UnityEngine;
using System.Collections;

public class MaintToBlock : MonoBehaviour {

	private bool firstOne; 
	public AudioClip dropCube; 


	void OnCollisionEnter (Collision other) {
		if (other.gameObject.tag == "Cube" && firstOne) {
			other.gameObject.GetComponent <MeshRenderer> ().material.color = GetComponent <MeshRenderer> ().material.color; 
			GetComponent <AudioSource> ().clip = dropCube;
			GetComponent <AudioSource> ().Play();
		}
		if (!firstOne)
			firstOne = true; 
	}
}