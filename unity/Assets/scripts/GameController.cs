using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public RunScript p1;
	public TimerUpdater timer;
	public GameObject[] toDisableAfterStart;
	public GameObject[] toEnableAfterEnd;
	private bool _startTouch;
	private ScoreManager scoreManager;
	private AdManager adManager;
	private AudioManager audioManager;
	 void Awake()
	{
		Application.targetFrameRate = 60;
		Time.timeScale = 0.0f;
		_startTouch = false;
		scoreManager = GetComponent<ScoreManager> ();
		adManager = GetComponent<AdManager> ();
		audioManager = AudioManager.instance;
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
		audioManager.PlayBackgroundSound ();

	}
	void Update(){

				if (Input.GetKey (KeyCode.Escape)) {
						audioManager.StopAllSounds();
						Application.LoadLevel ("MainPage");
			
						return;
				}
		}
		
	public void StopGame(){
		//Debug.Log ("StopGame triggered");
		audioManager.StopAllSounds ();
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
		foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Game")){
				Destroy(obj);

		}
		foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Obstacle")){
			Destroy(obj);
			
		}

	}

	public void Retry(){
		//Add one to Retry Counter so adManager can now when to fire an ad.
		adManager.IncrementRetryCounter ();
		//If adManager can  fire an ad, Register to the event and show the ad
		if (adManager.WillShowAnAd ()) {

						adManager.interstitial.AdClosed += HandleInterstitialClosed;
						adManager.ShowInterstitial ();
						return;
			//Else reload the level as expected
				} else {
						Application.LoadLevel (Application.loadedLevel);
				}
		}
	public void Back(){
		Application.LoadLevel ("MainPage");
		adManager.ResetRetryCounter ();
		}

	public void HandleInterstitialClosed(object sender, System.EventArgs args){
		Application.LoadLevel (Application.loadedLevel);
	}
}
