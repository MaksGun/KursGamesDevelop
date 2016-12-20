using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Textfade : MonoBehaviour {
	private Text txt; 
	private Outline oline; 

	void Start ()
	{
		txt = GetComponent <Text> (); 
		oline = GetComponent <Outline> ();
	}

	void Update ()
	{
		txt.color = new Color (txt.color.r, txt.color.g, txt.color.b, Mathf.PingPong (Time.time, 1.0f)); 
		oline.effectColor = new Color (oline.effectColor.r, oline.effectColor.g, oline.effectColor.b,txt.color.a - 0.3f) ; 
	}
}
