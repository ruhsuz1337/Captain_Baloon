using System.Collections;
using GoogleMobileAds.Api;
using UnityEngine;

public class Interstitial : MonoBehaviour
{
    [SerializeField] private string AdUnitID;
    private const string TestID = "ca-app-pub-3940256099942544/8691691433";

    private InterstitialAd interstitial;

    private void Start()
    {
        RequestAD();

        //StartCoroutine(ShowInterstitial());
    }

    private void RequestAD()
    {
        var adUnitId = AdManager.TestMode ? TestID : AdUnitID;

        // Clean up interstitial ad before creating a new one.
        interstitial?.Destroy();

        // Create an interstitial.
        interstitial = new InterstitialAd(adUnitId);

        // Load an interstitial ad.
        interstitial.LoadAd(new AdRequest.Builder().Build());
    }

    public IEnumerator ShowInterstitial()
    {
        yield return new WaitUntil(() => interstitial.IsLoaded());
        {
            interstitial.Show();
        }
    }

    public void showads()
    {
        StartCoroutine(ShowInterstitial());
        Debug.Log("meow");
    }
}