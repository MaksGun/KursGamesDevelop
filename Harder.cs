using UnityEngine;
using System.Collections;

public class Harder : MonoBehaviour {
	private bool hard; 
	public GameObject detectClicks; 


	void Update () {
		if (CubeJump.count_blocks > 0) {
			if (CubeJump.count_blocks % 7 == 0 && !hard) { 
				print ("Harder");
				Camera.main.GetComponent <Animation> ().Play ("Harder"); 
				detectClicks.transform.position = new Vector3 (11.2f, 6.5f, -6.5f); 
				detectClicks.transform.eulerAngles = new Vector3 (29.4f, -60f, 0f); 
				hard = true;
			} else if ((CubeJump.count_blocks % 7)-1 == 0 && hard) {
				hard = false; 
				print ("Easier");
				Camera.main.GetComponent <Animation> ().Play ("Easyer"); 
				detectClicks.transform.position = new Vector3 (-0.04f, 1.9f, -9.17f);
				detectClicks.transform.eulerAngles = new Vector3 (0f, 0f, 0f);
			}
		}
	}
}
