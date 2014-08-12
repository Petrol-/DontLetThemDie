using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class AudioManager : MonoBehaviour {

	private static AudioManager _instance;
	private SoundButton soundButton;
	private bool soundEnabled;
	public bool loopBackgroundSound;
	public AudioSource audioBackground;
	public AudioSource audioJump;

	public static AudioManager instance{
		get{
			if(_instance == null){
				_instance=FindObjectOfType<AudioManager>();
				DontDestroyOnLoad(_instance);
					}
			return _instance;
				}
	}

	void Awake(){

		if (_instance == null) {
			_instance = this;
			DontDestroyOnLoad(this);
				}
		//check if a SoundButton is present
		soundButton = FindObjectOfType<SoundButton> ();
		//if yes, register to its event
		if (soundButton != null) {
						soundButton.soundSettingsChanged += new SoundOnOff (HandlerAudioOnOff);

				}
	}
	// Use this for initialization
	void Start () {
		soundEnabled = PlayerPrefs.GetInt ("Sound", 0) == 1 ? true : false;
		audioBackground.loop = loopBackgroundSound;
	}

	public void PlayBackgroundSound()
	{	Debug.LogWarning("PlayBackgroundSound, soundEnabled: "+soundEnabled);
		if(soundEnabled)
		audioBackground.Play ();
	}

	public void StopBackgroundSound(){
		audioBackground.Stop ();
		}
	public void PlayJumpSound(){
		if(soundEnabled)
		audioJump.Play ();
	}
	public void StopJumpSound(){
		audioJump.Stop ();
		}
	public void StopAllSounds(){
		StopBackgroundSound ();
		StopJumpSound ();
		}
	private void HandlerAudioOnOff(){

		_instance.soundEnabled = ((PlayerPrefs.GetInt ("Sound", 0) == 1) ? true : false);
		Debug.LogWarning("HandlerAudioOnOff, soundEnabled: "+_instance.soundEnabled);

				if (_instance.soundEnabled)
						StopAllSounds ();
		}

}
