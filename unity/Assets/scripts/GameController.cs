using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public RunScript p1;
	public TimerUpdater timer;
	public GameObject[] toDisableAfterStart;
	public GameObject[] toEnableAfterEnd;
	private bool _startTouch;
	private ScoreManager scoreManager;
	 void Awake()
	{
		Time.timeScale = 0.0f;
		_startTouch = false;
		scoreManager = GetComponent<ScoreManager> ();
	}
	public void FirstTouch(){

		if (!_startTouch) {
			_startTouch =true;
			StartGame();
				}
	}

	 private void StartGame()
	{
		foreach(GameObject obj in toDisableAfterStart){
			obj.SetActive(false);
		}
		p1.canRun = true;
		timer.canCount = true;
		Time.timeScale = 1.0f;

	}

		
	public void StopGame(){
		//Debug.Log ("StopGame triggered");
		timer.canCount = false;
		string sTime = timer.GetTime ();
		foreach (GameObject obj in toEnableAfterEnd) {
			obj.SetActive(true);		
		}

		UILabel score = GameObject.FindGameObjectWithTag ("Score").GetComponent<UILabel> ();
		UILabel bestScore = GameObject.FindGameObjectWithTag ("BestScore").GetComponent<UILabel> ();
		score.text = "Score "+sTime;
		scoreManager.UpdateScore (timer.GetTime (), timer.GetTime (0));
		bestScore.text = "Best " + scoreManager.GetBestTime ();
		Destroy (GameObject.FindGameObjectWithTag ("Game"));
		Destroy (GameObject.FindGameObjectWithTag ("Obstacle"));
	}

	public void Retry(){
		Application.LoadLevel (Application.loadedLevel);
		}
	public void Back(){
		Application.LoadLevel ("MainPage");
		}
}
