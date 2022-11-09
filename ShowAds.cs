using UnityEngine;
using UnityEngine.Advertisements;

public class ShowAds : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{
    private string _androidGameId = "4865333";
    private string _iosGameId = "4865332";
    private bool _isTestMode = true;
    private string _gameId;
    private string _androidAdUnitId = "Interstitial_Android";
    private string _iOsAdUnitId = "Interstitial_iOS";
    string _adUnitId;

    private static int _countLoses = 0;

    private void Awake()
    {
        InitializeAds();
        _countLoses++;

        if (_countLoses % 3 == 0)
            Advertisement.Load(_adUnitId, this);
    }

    void InitializeAds()
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            _gameId = _iosGameId;
            _adUnitId = _iOsAdUnitId;
        }
        else
        {
            _gameId = _androidGameId;
            _adUnitId = _androidAdUnitId;
        }

        Advertisement.Initialize(_gameId, _isTestMode, this);
    }

    public void OnInitializationComplete()
    {

    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }

    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        Advertisement.Show(adUnitId, this);
    }

    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit: {adUnitId} - {error.ToString()} - {message}");
        
    }

    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");       
    }

    public void OnUnityAdsShowStart(string adUnitId) { }
    public void OnUnityAdsShowClick(string adUnitId) { }
    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState) { }
}
