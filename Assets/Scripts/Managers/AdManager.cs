using EasyMobile;
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
        Advertising.LoadInterstitialAd();
        Advertising.LoadRewardedAd();
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
        if ( Advertising.IsInterstitialAdReady() )
        {
            Advertising.ShowInterstitialAd();
        }
    }
    public void ShowRewardedAd()
    {
        if ( Advertising.IsRewardedAdReady() )
        {
            Advertising.ShowRewardedAd();
        }
    }
    public void HideBannerAd()
    {
        Advertising.HideBannerAd();

    }

}
