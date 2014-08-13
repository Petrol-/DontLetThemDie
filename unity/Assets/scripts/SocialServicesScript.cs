using UnityEngine;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using System.Collections;
using System;


/// <summary>
/// Social services script.
/// Persistent singleton that take care of connecting the player to the googgle play servives
/// and reportings scores and achievements to the social platform
/// </summary>
public class SocialServicesScript : MonoBehaviour {

	//Instance of the singleton
	private static SocialServicesScript _instance;

	//if something tries to get the singleton, checks if the singleton exists and find it if necessary
	public static SocialServicesScript instance{
		get{
			//if there is  no instance available, finds one
			if(_instance == null){
				_instance = FindObjectOfType<SocialServicesScript>();
				//Don't destroy the object when loading as it is persistent
				DontDestroyOnLoad(_instance.gameObject);
			}
			return _instance;
		}
	}

	public bool debug;
	public string packageName; //Package name of the app (Android)
	//private bool platformActivated = false; //used ?
	//private bool isLogged; //Is the user logged or not
	//private bool leaderBoardShowing , achievementsShowing; //Is one of the UI for google leaderboard or achievement ui are showing ?
	private enum EnumGoogleUI{

		LEADERBOARD,
		ACHIEVEMENTS

	}

	void Awake(){
//		leaderBoardShowing = false;
//		achievementsShowing = false;
	//	Debug.LogWarning ("SocialServicesScript instanciated");

		if(_instance == null)
		{
	//		Debug.LogWarning("SocialServiceScript _indtance == null");
			//If I am the first instance, make me the Singleton
			_instance = this; 
			DontDestroyOnLoad(this);
		}
		else
		{
	//		Debug.LogWarning("SocialServiceScript _indtance != null");
			//If a Singleton already exists and you find
			//another reference in scene, destroy it!
			if(this != _instance)
				Destroy(this.gameObject);
		}
		PlayGamesPlatform.DebugLogEnabled = debug; //Do we want debug log of the social platform ?
	//	Debug.LogWarning ("Play Service.Activate()");
		
		
		// Activate the Google Play Games platform
		PlayGamesPlatform.Activate ();
		//platformActivated=true;

		//If the users has clicked the leaderboard button and succesfully connected Once.
		//Debug.LogWarning ("Awake() SignedPlayServices : "+PlayerPrefs.GetInt("SignedPlayServices",0));
		if(PlayerPrefs.GetInt("SignedPlayServices",0) == 1){
			// recommended for debugging:

			Login();
			}
		}

	/*public bool isUserLoggedIn(){
		return isLogged;
		}
*/
	public void ShowLeaderBoard(){
//		Debug.LogWarning ("ShowLeaderBoard");
		if (PlayerPrefs.GetInt ("SignedPlayServices", 0) == 0) {
//			Debug.LogWarning("Attempt first login");
			AttemptFirstLogin();
		}
		// show leaderboard UI
		if (Login ())
		{
						//if (!leaderBoardShowing) {
								//leaderBoardShowing = true;
								Social.ShowLeaderboardUI ();
								//StartCoroutine (DontCatchTwiceTheButton (EnumGoogleUI.LEADERBOARD, 0.8f));		
						//}
				}
		}

	public void ShowAchievements(){
		if (Login ()) {
			//if(!achievementsShowing){

//			achievementsShowing =true;
			Social.ShowAchievementsUI();
//				StartCoroutine(DontCatchTwiceTheButton(EnumGoogleUI.ACHIEVEMENTS,0.5f));
			//	               }
				}
		}

	public void PostTimeToLeaderBoard(float timeInSeconds, int sceneID){

		if(Login ()){
		long time =(long) (Mathf.RoundToInt(timeInSeconds * 1000));
//		Debug.LogWarning ("Posting to " + Enum.GetName (typeof(EnumLeaderBoard), sceneID)); 
		Social.ReportScore(time,Enum.GetName(typeof(EnumLeaderBoard),sceneID),(bool success)=> {

		});
		}
	}

	private  void PostAllTimeToLeaderBoard(){
//		Debug.LogWarning ("PostAllTimeToLeaderBoard");
		float[] times = new float[4];
		for (int i = 2; i<6; i++) {
			times[i-2]=PlayerPrefs.GetFloat("BestScore"+i,0.0f);
//			Debug.LogWarning("Scene "+i+" Time "+times[i-2]);
			PostTimeToLeaderBoard(times[i-2],i);
				}

		}
	private void AttemptFirstLogin(){
//		Debug.LogWarning ("First logging attempt");
		PlayGamesPlatform.Activate ();
//		platformActivated=true;
		Social.localUser.Authenticate ((bool success) => {
			if(success){
			PlayerPrefs.SetInt("SignedPlayServices",1);
				PostAllTimeToLeaderBoard();
			}
		});

		}
	//If the player has not attempted to access the PlayServices on its own, don't log
	private bool Login(){
		//If the player has not attempted to access the PlayServices on its own, don't log
//		Debug.LogWarning ("Login... SignedPlayServices : " + PlayerPrefs.GetInt ("SignedPlayServices", 0));
		if (PlayerPrefs.GetInt ("SignedPlayServices", 0) == 0) {
//			Debug.LogWarning("Can't Login, SignedPlayServices = 0");
						return false;
				}
//		Debug.LogWarning ("User is authenticated : " + Social.localUser.authenticated);
		if (!Social.localUser.authenticated) {
						// authenticate user:
						Social.localUser.Authenticate ((bool success) => {
//								Debug.LogWarning ("Login() : " + success);
//								isLogged = success;
						});
				}
			return (Social.localUser.authenticated);

		}
	public void OpenAndroidAppPage(){
		string url = "market://details?id=" + packageName;
//		Debug.LogWarning ("Opening url " + url);
		if(!packageName.Equals(""))
			Application.OpenURL (url);
			
		}
	/*private IEnumerator DontCatchTwiceTheButton(EnumGoogleUI ui, float waitForTime){

		yield return new WaitForSeconds (waitForTime);
			
		switch (ui)
		{
			case EnumGoogleUI.ACHIEVEMENTS : achievementsShowing=false; break;
			case EnumGoogleUI.LEADERBOARD : leaderBoardShowing =false; break;
		}

	}
	*/

}
