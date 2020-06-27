using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IUnityAdsListener
{
    readonly string adIdAndroid = "3679789";
    readonly bool testMode = false;
    readonly string rewarderVideoPlacemet = "rewardedVideo";

    public GameObject CountDownCanvas;
    public GameManager gameManager;

    private void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(adIdAndroid, testMode);
    }

    public void WatchRewardVideo()
    {
        FindObjectOfType<AudioManager>().isOn = false;
        Advertisement.Show(rewarderVideoPlacemet);
    }

    public void OnUnityAdsDidError(string message)
    {
        
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if(showResult == ShowResult.Finished)
        {
            gameManager.IncreaseHealth(2);
            FindObjectOfType<AudioManager>().isOn = true;
            GameObject.FindGameObjectWithTag("GameOverCanvas").GetComponent<Canvas>().enabled = false;
            CountDownCanvas.SetActive(true);
        }
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        
    }

    public void OnUnityAdsReady(string placementId)
    {
		
    }

}
