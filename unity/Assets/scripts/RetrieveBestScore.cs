using UnityEngine;
using System.Collections;

public class RetrieveBestScore : MonoBehaviour {

	public string key;

	void Awake(){
		UILabel score = GetComponent<UILabel> ();
		score.text = "(Best "+PlayerPrefs.GetString (key, "0\" 00")+")";
		}
}
