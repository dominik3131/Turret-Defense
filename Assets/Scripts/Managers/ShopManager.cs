using EasyMobile;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public Button beersButton;
    public Button firePotionsButton;
    public Button freezePotionButton;
    public GameObject[] beerIndicators;
    public GameObject[] firePotionIndicators;
    public GameObject[] freezePotionIndicators;
    public AdManager adManager;

    // Start is called before the first frame update
    void Start()
    {
        UpdateIndicators();
        beersButton.onClick.AddListener(BuyNoAds);
        firePotionsButton.onClick.AddListener(BuyFirePotions);
        freezePotionButton.onClick.AddListener(BuyFreezePotions);
        //TODO remove later
        PlayerPrefs.SetInt("BEERS", 200);
    }

    private void BuyNoAds()
    {
        adManager.ShowRewardedAd();
    }

    private void BuyFirePotions()
    {
        int beers = PlayerPrefs.GetInt("BEERS", 0);
        if ( beers >= 40 )
        {
            PlayerPrefs.SetInt("FIRE_POTIONS", PlayerPrefs.GetInt("FIRE_POTIONS", 0) + 4);
            PlayerPrefs.SetInt("BEERS", beers - 40);
        }
        UpdateIndicators();
    }
    private void BuyFreezePotions()
    {
        int beers = PlayerPrefs.GetInt("BEERS", 0);
        if ( beers >= 40 )
        {
            PlayerPrefs.SetInt("FREEZE_POTIONS", PlayerPrefs.GetInt("FREEZE_POTIONS", 0) + 3);
            PlayerPrefs.SetInt("BEERS", beers - 40);
        }
        UpdateIndicators();
    }
    private void UpdateIndicators()
    {
        foreach ( GameObject gameObject in beerIndicators )
        {
            Text text = gameObject.GetComponent<Text>();
            text.text = PlayerPrefs.GetInt("BEERS", 0).ToString();
        }
        foreach ( GameObject gameObject in freezePotionIndicators )
        {
            Text text = gameObject.GetComponent<Text>();
            text.text = PlayerPrefs.GetInt("FREEZE_POTIONS", 0).ToString();
        }
        foreach ( GameObject gameObject in firePotionIndicators )
        {
            Text text = gameObject.GetComponent<Text>();
            text.text = PlayerPrefs.GetInt("FIRE_POTIONS", 0).ToString();
        }
    }
    void RewardedAdCompletedHandler(RewardedAdNetwork network, AdLocation location)
    {
        int beers = PlayerPrefs.GetInt("BEERS");
        PlayerPrefs.SetInt("BEERS", beers + 15);
        UpdateIndicators();
    }
}
