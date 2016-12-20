using UnityEngine;
using UnityEngine.UI; 
using System.Collections;

public class GameArrangement : MonoBehaviour {
	
	public GameObject[] cubes; 
	public GameObject Buttons, m_cube, spawn_blocks, diamonds,music; 
	public Animation cubes_anim,block; 
	public Light dirLight; 
	private bool clicked; 
	public Text playText, gameName, study, record; 

	void Update () {
		if (clicked && dirLight.intensity != 0)
			dirLight.intensity -= 0.03f;
	}
		void OnMouseDown () {
		if (!clicked) {
			StartCoroutine (delCubes ()); 
			clicked = true; //без повтора работа 
			playText.gameObject.SetActive (false); 
			study.gameObject.SetActive (true);
			record.gameObject.SetActive (true); 
			diamonds.SetActive (true);
			if (music.activeSelf) {
				for (int i = 0; i < music.transform.parent.transform.childCount; i++) 
					music.transform.parent.transform.GetChild (i).gameObject.SetActive (!music.transform.parent.transform.GetChild (i).gameObject.activeSelf);
			}
			gameName.text = "0"; 
			Buttons.GetComponent <ScrollObjects> ().speed = -10f; 
			Buttons.GetComponent <ScrollObjects> ().checkPos = -150f;
			m_cube.GetComponent <Animation> ().Play ("MainCubeGameStart");
			StartCoroutine (cubeToBlock ()); 
			m_cube.transform.localScale = new Vector3 (1f,1f,1f); 
			cubes_anim.Play (); 
		} else if (clicked &&  study.gameObject.activeSelf)
			study.gameObject.SetActive (false);
		}

	IEnumerator delCubes () {
		for (int i = 0; i < 3; i++) {
			yield return new WaitForSeconds (0.4f); 
			cubes [i].GetComponent <FallCube> ().enabled = true; 
		}
		spawn_blocks.GetComponent <SpawnBlocks>().enabled = true; 

	}

	IEnumerator cubeToBlock () {
		yield return new WaitForSeconds (m_cube.GetComponent <Animation> ().clip.length+0.4f); 
		block.Play ();


		m_cube.AddComponent <Rigidbody> (); 
	}

}
