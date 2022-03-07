using GoogleMobileAds.Api;
using UnityEngine;

public class Banner : MonoBehaviour
{
    [SerializeField] private string AdUnitID;
    private const string TestID = "ca-app-pub-3940256099942544/6300978111";

    private BannerView bannerAd;

    private void Start()
    {
        RequestAD();
    }

    private void RequestAD()
    {
        var adUnitId = AdManager.TestMode ? TestID : AdUnitID;

        bannerAd = new BannerView(adUnitId, AdSize.MediumRectangle, AdPosition.Bottom);
        //Debug.Log(adUnitId);
        // Clean up banner ad before creating a new one.
        if (bannerAd != null)
        {
            bannerAd.Destroy();
        }

        // Create a 320x50 banner at the top of the screen.
        bannerAd = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);

        // Load a banner ad.
        bannerAd.LoadAd(new AdRequest.Builder().Build());
    }
}