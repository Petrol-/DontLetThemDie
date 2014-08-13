using UnityEngine;
using System.Collections;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class AdManager : MonoBehaviour {

	private InterstitialAd _interstitial;
	private int retryCounter;
	public int retryBeforeAd;
	public InterstitialAd interstitial {
				get { return _interstitial;}
		}

	// Use this for initialization
	void Start () {
		retryCounter = PlayerPrefs.GetInt ("RetryCounter", 0);
		//if(WillShowAnAd())
		RequestInterstitial ();
	}

	private void RequestInterstitial()
	{
		#if UNITY_EDITOR
		string adUnitId = "unused";
		#elif UNITY_ANDROID
		string adUnitId = "ca-app-pub-9974782569800379/5059842048";
		#elif UNITY_IPHONE
		string adUnitId = "INSERT_IOS_INTERSTITIAL_AD_UNIT_ID_HERE";
		#else
		string adUnitId = "unexpected_platform";
		#endif
		
		// Create an interstitial.
		_interstitial = new InterstitialAd(adUnitId);
		// Register for ad events.
		_interstitial.AdClosed += HandleInterstitialClosed;
		_interstitial.AdLeftApplication += HandleInterstitialLeftApplication;
		// Load an interstitial ad.
		_interstitial.LoadAd(createAdRequest());
	}


	// Returns an ad request with custom ad targeting.
	private AdRequest createAdRequest()
	{
		return new AdRequest.Builder()
				.Build();
		//Uncomment this between AdRequest.Builer() and .Build() for debugging
		//.AddTestDevice(AdRequest.TestDeviceSimulator)
		//	.AddTestDevice("1E720D8B275AE0C548FEBB1EC217038D")
	}

	public void ShowInterstitial()
	{
		//Debug.LogWarning ("Ad is loaded: "+_interstitial.IsLoaded());
		if (_interstitial.IsLoaded())
		{
			_interstitial.Show();
			PlayerPrefs.SetInt("RetryCounter",0);
		}
		else
		{
		//	print("Interstitial is not ready yet.");
		}
	}
	public void IncrementRetryCounter(){
		PlayerPrefs.SetInt ("RetryCounter", PlayerPrefs.GetInt ("RetryCounter", 0) + 1);
		retryCounter++;
		}
	public void ResetRetryCounter(){
		PlayerPrefs.SetInt ("RetryCounter", 0);
		retryCounter = 0;

		}
	public bool WillShowAnAd(){
		//Debug.LogWarning ("WillShowAnAD: " + (retryCounter >= retryBeforeAd));
		if (retryCounter >= retryBeforeAd) {
			ResetRetryCounter();
						return true;
				}
		return false;
		}
	public void HandleInterstitialLoaded(object sender, System.EventArgs args)
	{
		//print("HandleInterstitialLoaded event received.");
	}
	
	public void HandleInterstitialFailedToLoad(object sender, AdFailedToLoadEventArgs args)
	{
		//print("HandleInterstitialFailedToLoad event received with message: " + args.Message);
	}
	
	public void HandleInterstitialOpened(object sender, System.EventArgs args)
	{
		//print("HandleInterstitialOpened event received");
	}
	
	void HandleInterstitialClosing(object sender, System.EventArgs args)
	{
		//print("HandleInterstitialClosing event received");
	}
	
	public void HandleInterstitialClosed(object sender, System.EventArgs args)
	{
		_interstitial.Destroy ();
		//print("HandleInterstitialClosed event received");
	}
	
	public void HandleInterstitialLeftApplication(object sender, System.EventArgs args)
	{

		_interstitial.Destroy ();
		//print("HandleInterstitialLeftApplication event received");
	}

}
