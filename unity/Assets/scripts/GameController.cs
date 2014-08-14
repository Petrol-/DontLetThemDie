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

	//Is called when the first touch is detected
	public void FirstTouch(){

		if (!_startTouch) {
			_startTouch =true;
			StartGame();
				}
	}
	//Disables components that have to be disabled and allow the players and counter to move and count
	 private void StartGame()
	{
		foreach(GameObject obj in toDisableAfterStart){
			obj.SetActive(false);
		}
		p1.canRun = true;
		timer.canCount = true;
		Time.timeScale = 1.0f;
		//Play the background sound (if allowed)
		audioManager.PlayBackgroundSound ();

	}
	void Update(){
		//If the players wants to leave, return to main page and stop all sounds
				if (Input.GetKey (KeyCode.Escape)) {
						audioManager.StopAllSounds();
						Application.LoadLevel ("MainPage");
			
						return;
				}
		}
		
	public void StopGame(){
		//Debug.Log ("StopGame triggered");
		//Stop all sounds when the game stops
		audioManager.StopAllSounds ();
		//Stop the timer
		timer.canCount = false;
		//Get the timer in a string, ready to be displayed
		string sTime = timer.GetTime ();
		//Activate the End Game UI
		foreach (GameObject obj in toEnableAfterEnd) {
			obj.SetActive(true);	
		}
		//Prints score in the UI
		UILabel score = GameObject.FindGameObjectWithTag ("Score").GetComponent<UILabel> ();
		UILabel bestScore = GameObject.FindGameObjectWithTag ("BestScore").GetComponent<UILabel> ();
		score.text = "Score "+sTime;
		//Update score in LeaderBoard (if allowed)
		scoreManager.UpdateScore (timer.GetTime (), timer.GetTime (0));
		bestScore.text = "Best " + scoreManager.GetBestTime ();
		//Destroy all non needed GameObjects
		foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Game")){
				Destroy(obj);

		}
		foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Obstacle")){
			Destroy(obj);
			
		}

	}

	//Called when the user puches the Retry Button
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
	//Called when the user pushes the Back button
	public void Back(){
		Application.LoadLevel ("MainPage");
		adManager.ResetRetryCounter ();
		}

	//If an ad is showing, wait for the ad to close before relaoding the level
	public void HandleInterstitialClosed(object sender, System.EventArgs args){
		Application.LoadLevel (Application.loadedLevel);
	}
}
