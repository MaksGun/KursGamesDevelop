using UnityEngine;
using System.Collections;

public class ScrollObjects : MonoBehaviour {
	
		public float speed = 5f, checkPos = 0f; 
		private RectTransform Rec; 

		void Start ()
		{
			Rec = GetComponent <RectTransform> (); 	
		}

		void Update ()
		{
			if (Rec.offsetMin.y != checkPos)
			{
				Rec.offsetMin += new Vector2 (Rec.offsetMin.x, speed);
				Rec.offsetMax += new Vector2 (Rec.offsetMax.x, speed); 
			}

		}

	}
