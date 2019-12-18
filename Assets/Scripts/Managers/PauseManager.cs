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
    private bool paused = false;
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


    private void LoadMenu()
    {
        this.sceneLoader.LoadScene(0);
    }

    private void Restart()
    {
        this.sceneLoader.ReloadCurrentScene();
    }
    private void Resume()
    {
        paused = false;
        adManager.HideBannerAd();
        Time.timeScale = 1;
        pauseCanvas.SetActive(false);
    }
    private void Pause()
    {
        paused = true;
        adManager.ShowBannerAd();
        adManager.ShowInterstitialAd();
        Time.timeScale = 0;
        pauseCanvas.SetActive(true);
    }
    private void ShowRewardAdForFirePotion()
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
        if ( paused )
        {
            int firePotions = PlayerPrefs.GetInt("FIRE_POTIONS", 0) + 1;
            PlayerPrefs.SetInt("FIRE_POTIONS", firePotions);
            //TODO fix indicator
            Text text = firePotionButton.GetComponentInChildren<Text>();
            text.text = firePotions.ToString();
        }
    }
}
