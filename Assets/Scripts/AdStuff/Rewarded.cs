using System;
using System.Collections;
using GoogleMobileAds.Api;
using UnityEngine;
using UnityEngine.Events;

public class Rewarded : MonoBehaviour
{
    [SerializeField] private string AdUnitID;
    private const string TestID = "ca-app-pub-3940256099942544/5224354917";

    [Header("Events")] 
    [SerializeField] private UnityEvent<Reward> OnRewardGain;
    
    private RewardBasedVideoAd rewardBasedVideo;
    
    void Start()
    {
        // Get singleton reward based video ad reference.
        rewardBasedVideo = RewardBasedVideoAd.Instance;

        // RewardBasedVideoAd is a singleton, so handlers should only be registered once.
        rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
        rewardBasedVideo.OnAdClosed += HandleRewardBasedVideoClosed;

        RequestAD();

        
    }

    private void RequestAD()
    {
        var adUnitId = AdManager.TestMode ? TestID : AdUnitID;
        
        rewardBasedVideo.LoadAd(new AdRequest.Builder().Build(), adUnitId);
    }

    private IEnumerator ShowRewardBasedVideo()
    {
        yield return new WaitUntil(() => rewardBasedVideo.IsLoaded());
        {
            rewardBasedVideo.Show();
        }
    }

    #region RewardBasedVideo callback handlers

    private void HandleRewardBasedVideoClosed(object sender, EventArgs args)
    {
        RequestAD();
    }

    private void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
        OnRewardGain.Invoke(args);
        RequestAD();
    }

    public void ShowAd()
    {
        StartCoroutine(ShowRewardBasedVideo());
    }

    #endregion
}
