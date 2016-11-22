using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;

public class AdMobManager : MonoBehaviour {
	public string interestialID;
	public string smallBanerID;
	InterstitialAd interstitial;
	// Use this for initialization
	void Start () {
		// Create a 320x50 banner at the top of the screen.
		BannerView bannerView = new BannerView(smallBanerID, AdSize.Banner, AdPosition.Bottom);
		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder().Build();
		// Load the banner with the request.
		bannerView.LoadAd(request);

		// Initialize an InterstitialAd.
		interstitial = new InterstitialAd(interestialID);
		// Create an empty ad request.
		AdRequest requestIner = new AdRequest.Builder().Build();
		// Load the interstitial with the request.
		interstitial.LoadAd(requestIner);
	}
	
	// Update is called once per frame
	void Update () {

	}
	public void GameOver()
	{
		if (interstitial.IsLoaded()) {
			interstitial.Show();
		}
	}
}
