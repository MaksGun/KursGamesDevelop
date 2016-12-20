using UnityEngine;
using System.Collections;

public class RandColors : MonoBehaviour {

	public Color[] colors; 

	void Start () {
		GetComponent <MeshRenderer> ().material.color = colors [Random.Range (0, colors.Length)];
	}


}
