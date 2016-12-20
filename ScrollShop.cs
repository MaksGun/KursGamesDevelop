using UnityEngine;
using System.Collections;

public class ScrollShop : MonoBehaviour {

	public GameObject cubes; 
	private Vector3 screenPoint, offset; 
	private float _lockedYPos; 

	void Update () {
		if (cubes.transform.position.x>0)
			cubes.transform.position = Vector3.MoveTowards (cubes.transform.position, new Vector3(1f,cubes.transform.position.y, cubes.transform.position.z), Time.deltaTime * 10f);
		else if(cubes.transform.position.x <-13f)
			cubes.transform.position = Vector3.MoveTowards (cubes.transform.position, new Vector3(-11.2f,cubes.transform.position.y, cubes.transform.position.z), Time.deltaTime * 10f);
	}

	void OnMouseDown () { //передвижение в магазине
		_lockedYPos = 0.6f; 
		offset = cubes.transform.position - Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
		Cursor.visible = false; 
	} 

	void OnMouseDrag () {
		Vector3 curScreenPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z); 
		Vector3 curPosition = Camera.main.ScreenToWorldPoint (curScreenPoint) + offset; //мышка + где кубики 
		curPosition.y = +_lockedYPos; 
		cubes.transform.position = curPosition; //двигаем мышка+до перетаскивания 
	}

	void OnMouseUp () {
		Cursor.visible = true; 
	}
}

