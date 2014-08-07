using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public RunScript p1;
	public TimerUpdater timer;
	public GameObject[] toDisableAfterStart;
	public GameObject[] toEnableAfterEnd;
	private bool _startTouch;

	public bool startTouch 
	{
		get{ return _startTouch;}
		set
		{
			_startTouch = value;
			if(_startTouch)
			StartGame ();
		}
	}

	 public void StartGame()
	{
		foreach(GameObject obj in toDisableAfterStart){
			obj.SetActive(false);
		}
		p1.canRun = true;
		timer.canCount = true;
	}
	public void StopGame(){
		timer.canCount = false;
		foreach (GameObject obj in toEnableAfterEnd) {
			obj.SetActive(true);		
		}
		}
}
