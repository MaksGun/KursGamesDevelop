﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

	private Text txt; 
	private bool gameStart; 
	public Text  record; 
	void Start () {
		record.text = "TOP: " + PlayerPrefs.GetInt ("Record").ToString ();
		txt = GetComponent <Text> (); 
		CubeJump.count_blocks = 0; 
	}
	

	void Update () {
		if (txt.text == "0")
			gameStart = true; 
		if (gameStart)
			txt.text = CubeJump.count_blocks.ToString (); 
		if (PlayerPrefs.GetInt ("Record") < CubeJump.count_blocks) {
			PlayerPrefs.SetInt ("Record", CubeJump.count_blocks); 
			record.text = "TOP: " + PlayerPrefs.GetInt ("Record").ToString (); 
		}
	}
}