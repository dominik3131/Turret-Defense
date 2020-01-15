using EasyMobile;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager instance;
    public Button reviveButton;
    public Button restartButton;
    public Button menuButton;
    private SceneLoader sceneLoader;
    private AdManager adManager;
    public GameObject gameOverCanvas;
    public GameObject castle;
    private bool died = false;
    private void Awake()
    {
        Time.timeScale = 1;
        if ( instance != null )
        {
            return;
        }
        instance = this;
    }
    void Start()
    {
        sceneLoader = this.gameObject.GetComponent<SceneLoader>();
        adManager = this.gameObject.GetComponent<AdManager>();
        reviveButton.onClick.AddListener(ShowReviveAd);
        restartButton.onClick.AddListener(Restart);
        menuButton.onClick.AddListener(LoadMenu);
    }
    private void LoadMenu()
    {
        this.sceneLoader.LoadScene(0);
    }

    private void Restart()
    {
        this.sceneLoader.ReloadCurrentScene();
    }
    private void ShowReviveAd()
    {
        adManager.ShowRewardedAd();
    }
    public void Die()
    {
        Time.timeScale = 0;
        died = true;
        gameOverCanvas.SetActive(true);
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
        if ( died )
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
            foreach ( GameObject enemy in enemies )
            {
                GameObject.Destroy(enemy);
            }
            //TODO uncoment when Revive() is added
            //castle.GetComponent<Health>().Revive();
            died = false;
            gameOverCanvas.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
