using UnityEngine;
using System.Collections;

public class SelectMainCube : MonoBehaviour {

	public GameObject whichCube, mainCube; 


	void OnMouseDown () {
		if (mainCube !=null)
		mainCube.GetComponent <MeshRenderer> ().material = GameObject.Find (whichCube.GetComponent <SelectCube> ().nowCube).GetComponent <MeshRenderer> ().material; 
		PlayerPrefs.SetString ("Now Cube", whichCube.GetComponent <SelectCube> ().nowCube);
	}
}
