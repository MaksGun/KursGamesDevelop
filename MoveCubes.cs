using UnityEngine;
using System.Collections;

public class MoveCubes : MonoBehaviour {

	private bool moved = true; 
	private Vector3 target; 

	void Start () {
		//CubeJump.jump = false; //чтобы не уезжал при перезапуске
		target = new Vector3 (-4f, 6f, -0.2f); 
	}
	

	void Update () { //every Frame
		if (CubeJump.NextBlock) {
			if (transform.position != target)
				transform.position = Vector3.MoveTowards (transform.position, target, Time.deltaTime * 5f);
			else if (transform.position == target && !moved) {
				target = new Vector3 (transform.position.x - 2.75f, transform.position.y + 4.3f, transform.position.z);
				CubeJump.jump = false; 
				moved = true; 

			}

			if (CubeJump.jump)
				moved = false; 
		
		}
	}
}
