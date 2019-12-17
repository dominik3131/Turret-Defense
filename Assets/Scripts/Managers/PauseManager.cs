using EasyMobile;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public Button resumeButton;
    public Button pauseButton;
    public Button restartButton;
    public Button mainMenuButton;
    public Button potionForAdButton;
    public Button firePotionButton;
    public GameObject pauseCanvas;
    private SceneLoader sceneLoader;
    private AdManager adManager;
    void Start()
    {
        sceneLoader = this.gameObject.GetComponent<SceneLoader>();
        adManager = this.gameObject.GetComponent<AdManager>();
        resumeButton.onClick.AddListener(Resume);
        pauseButton.onClick.AddListener(Pause);
        restartButton.onClick.AddListener(Restart);
        mainMenuButton.onClick.AddListener(LoadMenu);
        potionForAdButton.onClick.AddListener(ShowRewardAdForFirePotion);
    }


    public void LoadMenu()
    {
        this.sceneLoader.LoadScene(0);
    }

    public void Restart()
    {
        this.sceneLoader.ReloadCurrentScene();
    }
    public void Resume()
    {
        adManager.HideBannerAd();
        Time.timeScale = 1;
        pauseCanvas.SetActive(false);
    }
    public void Pause()
    {
        adManager.ShowBannerAd();
        adManager.ShowInterstitialAd();
        Time.timeScale = 0;
        pauseCanvas.SetActive(true);
    }
    public void ShowRewardAdForFirePotion()
    {
        adManager.ShowRewardedAd();
    }
    void OnEnable()
    {
        Advertising.RewardedAdCompleted += RewardedAdCompletedHandler;
    }

    // Unsubscribe events
    void OnDisable()
    {
        Advertising.RewardedAdCompleted -= RewardedAdCompletedHandler;
    }

    // Event handler called when a rewarded ad has completed
    void RewardedAdCompletedHandler(RewardedAdNetwork network, AdLocation location)
    {
        PlayerPrefs.SetInt("FIRE_POTIONS", PlayerPrefs.GetInt("FIRE_POTIONS", 0) + 1);
        //TODO fix indicator
        firePotionButton.GetComponent<Text>().text = PlayerPrefs.GetInt("FIRE_POTIONS", 0).ToString();
    }
}
