using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/**Class managing buttons and their behaviour in main menu */
public class MainMenu : MonoBehaviour
{

    public Button newGameButton;
    public Button creditsButton;
    public Button exitButton;
    public Button CreditsToMenuButton;

    /** canvas group that holds game logo that is shown at game lauch */
    public CanvasGroup logoCanvasGroup;
    /** canvas group that holds buttons allowing to move to certain category */
    public CanvasGroup mainMenuCanvasGroup;
    /** canvas group that allows to see game credits*/
    public CanvasGroup creditsCanvasGroup;

    public AdManager adManager;

    /** canvas group that hold information about currently shown canvas group*/
    private CanvasGroup activeCanvasGroup;
    /** scene loader variable allowing to load another scenes */
    private SceneLoader sceneLoader;



    /** gets Scene Loader and sets proper button actions */
    void Start()
    {
        sceneLoader = gameObject.GetComponent<SceneLoader>();
        newGameButton.onClick.AddListener(NewGame);
        exitButton.onClick.AddListener(Exit);
        creditsButton.onClick.AddListener(ShowCredits);
        CreditsToMenuButton.onClick.AddListener(ShowMenu);
    }
    /** when object is awaken deactivates all canvas in scene and starts animation of game logo and later shows menu */
    public void Awake()
    {
        logoCanvasGroup.gameObject.SetActive(false);
        mainMenuCanvasGroup.gameObject.SetActive(false);
        creditsCanvasGroup.gameObject.SetActive(false);
        StartCoroutine(Fade.FadeCanvas(logoCanvasGroup, 0f, 1f, 2f, 0f));
        StartCoroutine(Fade.FadeCanvas(logoCanvasGroup, 1f, 0f, 2f, 4f));
        StartCoroutine(Fade.FadeCanvas(mainMenuCanvasGroup, 0f, 1f, 2f, 6f));
        StartCoroutine(ShowAds(10f));
    }

    /**loads first level */
    public void NewGame()
    {
        sceneLoader.LoadScene(1);
    }
    /**exits game */
    public void Exit()
    {
        Application.Quit();
    }


    /** shows canvas with Credits */
    public void ShowCredits()
    {
        StartCoroutine(Fade.FadeCanvas(mainMenuCanvasGroup, 1f, 0f, 0.5f, 0f));
        StartCoroutine(Fade.FadeCanvas(creditsCanvasGroup, 0f, 1f, 0.5f, 0f));
        activeCanvasGroup = creditsCanvasGroup;
    }

    /** shows canvas with main menu */
    public void ShowMenu()
    {
        StartCoroutine(Fade.FadeCanvas(activeCanvasGroup, 1f, 0f, 0.5f, 0f));
        StartCoroutine(Fade.FadeCanvas(mainMenuCanvasGroup, 0f, 1f, 0.5f, 0f));
        activeCanvasGroup = mainMenuCanvasGroup;
    }
    protected IEnumerator ShowAds(float delay)
    {
        yield return new WaitForSeconds(delay);
        adManager.ShowBannerAd();
        adManager.ShowInterstitialAd();
    }

}