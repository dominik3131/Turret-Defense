using EasyMobile;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdManager : MonoBehaviour
{
    void Awake()
    {
        if ( !RuntimeManager.IsInitialized() )
            RuntimeManager.Init();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ShowBannerAd()
    {
        Advertising.ShowBannerAd(BannerAdPosition.Bottom);
    }
    public void ShowInterstitialAd()
    {
        bool isReady = Advertising.IsInterstitialAdReady();

        // Show it if it's ready
        if ( isReady )
        {
            Advertising.ShowInterstitialAd();
        }
    }
}
