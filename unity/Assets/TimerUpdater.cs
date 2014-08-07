using UnityEngine;
using System.Collections;


public class TimerUpdater : MonoBehaviour {

	private UILabel Ltimer;
	private float time;
	public bool canCount;
	// Use this for initialization
	void Start () {

		Ltimer = GetComponent<UILabel> ();
		Ltimer.text = "0\"00";
		time = 0.00f;
		canCount = false;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!canCount)
						return;

		time += Time.deltaTime;

		int min, sec, cent;
		min = sec = cent = 0;
		min = (int)Mathf.FloorToInt (time / 60);
		sec = (int)(time / 1) % 60;
		cent = (int)Mathf.Clamp((time % 1)*100,0,99);

		if (min == 0) {
			Ltimer.text= sec.ToString("00")+"\" "+cent.ToString("00");
			return;
				}
		Ltimer.text= min+"' "+sec.ToString("00")+"\" "+cent.ToString("00");
		
	}
}
