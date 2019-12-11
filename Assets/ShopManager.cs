using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public Button fiftyBeersButton;
    public Button oneHundredBeersButton;
    public Button noAdsButton;
    public Button firePotionsButton;
    public Button freezePotionButton;
    public GameObject[] beerIndicators;
    public GameObject[] firePotionIndicators;
    public GameObject[] freezePotionIndicators;

    // Start is called before the first frame update
    void Start()
    {
        UpdateIndicators();
        fiftyBeersButton.onClick.AddListener(BuyFiftyBeers);
        oneHundredBeersButton.onClick.AddListener(BuyOneHundredBeers);
        noAdsButton.onClick.AddListener(BuyNoAds);
        firePotionsButton.onClick.AddListener(BuyFirePotions);
        freezePotionButton.onClick.AddListener(BuyFreezePotions);
        //TODO remove later
        PlayerPrefs.SetInt("BEERS", 200);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void BuyNoAds()
    {
        UpdateIndicators();
    }
    private void BuyFiftyBeers()
    {
        UpdateIndicators();
    }
    private void BuyOneHundredBeers()
    {
        UpdateIndicators();
    }
    private void BuyFirePotions()
    {
        int beers = PlayerPrefs.GetInt("BEERS");
        if ( beers >= 40 )
        {
            PlayerPrefs.SetInt("FIRE_POTIONS", PlayerPrefs.GetInt("FIRE_POTIONS") + 4);
            PlayerPrefs.SetInt("BEERS", beers - 40);
        }
        UpdateIndicators();
    }
    private void BuyFreezePotions()
    {
        int beers = PlayerPrefs.GetInt("BEERS");
        if ( beers >= 40 )
        {
            PlayerPrefs.SetInt("FREEZE_POTIONS", PlayerPrefs.GetInt("FREEZE_POTIONS") + 3);
            PlayerPrefs.SetInt("BEERS", beers - 40);
        }
        UpdateIndicators();
    }
    private void UpdateIndicators()
    {
        foreach ( GameObject gameObject in beerIndicators )
        {
            Text text = gameObject.GetComponent<Text>();
            text.text = PlayerPrefs.GetInt("BEERS").ToString();
        }
        foreach ( GameObject gameObject in freezePotionIndicators )
        {
            Text text = gameObject.GetComponent<Text>();
            text.text = PlayerPrefs.GetInt("FREEZE_POTIONS").ToString();
        }
        foreach ( GameObject gameObject in firePotionIndicators )
        {
            Text text = gameObject.GetComponent<Text>();
            text.text = PlayerPrefs.GetInt("FIRE_POTIONS").ToString();
        }
    }


}
