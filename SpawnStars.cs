/*using UnityEngine;
using System.Collections;

public class SpawnStars : MonoBehaviour {
		public GameObject star; 
		void Start () {
		StartCoroutine (spawn ());
		}

		IEnumerable spawn ()
	{
			while (true) {
				Vector3 pos = Camera.main.ScreenToWorldPoint (new Vector3 (Random.Range (0, Screen.width), Random.Range (0, Screen.height),Camera.main.farClipPlane /2 ));
				Instantiate (star, pos, Quaternion.identity); //Вращение 0 при создании
				yield return new WaitForSeconds (1f); //задержка создания
			}
		}

	}

*/