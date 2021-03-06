﻿using UnityEngine;
using System.Collections;

public delegate void SoundOnOff();

public class SoundButton : MonoBehaviour {

	private UISprite iSound;
	private bool soundEnabled;
	public event SoundOnOff soundSettingsChanged;
	void Awake(){
		iSound = GetComponent<UISprite> ();
		int sound = PlayerPrefs.GetInt ("Sound", 1);
		if (sound == 1) {
						soundEnabled = true;
						return;
				} else {
						soundEnabled = false;
				}
		ToogleSprite ();

		}
	public void IsClicked(){
		//Debug.Log ("Sound button is clicked");
		soundEnabled = !soundEnabled;
		PlayerPrefs.SetInt ("Sound", soundEnabled ? 1 : 0);
		ToogleSprite ();
		if (soundSettingsChanged != null) {
						soundSettingsChanged ();
				}
		}

	private void ToogleSprite(){

		if(soundEnabled){
			iSound.spriteName = "Sound_On";
		}
		else 
		{
			iSound.spriteName = "Sound_Off";
		}
	}
}
