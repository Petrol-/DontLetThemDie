using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {


	private int sceneIndex;
	private string floatKey;
	private string stringKey;

	void Awake(){
		GetIndexByName ();
		floatKey = "BestScore" + sceneIndex.ToString ();
		stringKey = "SBestScore" + sceneIndex.ToString ();
		}
	
	public void UpdateScore(string sTime,float time){
		if (sceneIndex == -1)
						return;

		if(time>PlayerPrefs.GetFloat(floatKey,0.0f)){
			PlayerPrefs.SetFloat(floatKey,time);
			PlayerPrefs.SetString(stringKey,sTime);
		}

	}

	private void GetIndexByName(){
		switch (Application.loadedLevelName) {
		case "Level2Char" : sceneIndex = 2;break;
		case "Level3Char" : sceneIndex = 3;break;
		case "Level4Char" : sceneIndex = 4;break;
		case "Level5Char" : sceneIndex = 5;break;
		default : sceneIndex = -1 ;break;
				}
		}
	public string GetBestTime(){
		return PlayerPrefs.GetString (stringKey, "0\" 00");
	}
}
