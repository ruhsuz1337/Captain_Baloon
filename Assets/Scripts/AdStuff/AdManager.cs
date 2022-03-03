using GoogleMobileAds.Api;
using UnityEngine;

public class AdManager : MonoBehaviour
{
    public static bool TestMode = true;

    private void Awake()
    {
        MobileAds.Initialize(initializationStatus => { });
    }
    
    
    
}