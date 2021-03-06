﻿using UnityEngine;
using System.Collections;


public class TimerUpdater : MonoBehaviour {

	public UILabel LTimerFracts, LTimerSec, LTimerMin;
	private float time;
	public bool canCount;
	private string sTime;
	// Use this for initialization
	void Start () {

		//Initialization
		LTimerFracts.text = "00";
		LTimerSec.text = "00\" ";
		LTimerMin.text = "";
		time = 0.00f;
		sTime = "";
		canCount = false;
	
	}
	
	// Update is called once per frame
	void Update () {
		//If the timer is not allowed to count, return;
		if (!canCount)
			return;

		//Add Time.deltaTime to the total
		time += Time.deltaTime;

		//Calculate Min Seconds and fractions
		int min, sec, cent;
		min = sec = cent = 0;
		min = (int)Mathf.FloorToInt (time / 60);
		sec = (int)(time / 1) % 60;
		cent = (int)Mathf.Clamp((time % 1)*100,0,99);

		//If min = 0, we don't want to display the mins
		if (min == 0) {

			//Ltimer.text= sTime = sec.ToString("00")+"\" "+cent.ToString("00");
			sTime = sec.ToString("00")+"\" "+cent.ToString("00");
			LTimerFracts.text = cent.ToString("00");
			LTimerSec.text = sec.ToString("00")+"\" ";
			return;
				}
		//Ltimer.text= sTime = min+"' "+sec.ToString("00")+"\" "+cent.ToString("00");
		//sTime will be stored in the PlayerPrefs in another script
		sTime = min+"' "+sec.ToString("00")+"\" "+cent.ToString("00");

		LTimerFracts.text = cent.ToString("00");
		LTimerSec.text = sec.ToString("00")+"\" ";
		LTimerMin.text = min + "' ";
	}

	public string GetTime(){ return sTime; }
	public float GetTime(int unused){ return time; }
}
