using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/** Loads scenes and shows loading screen while loading */
public class SceneLoader : MonoBehaviour
{
    /**canvas group holding loading screen */
    public CanvasGroup LoadingCanvasGroup;
    /**image on loading screen used as loading bar */
    public Image LoadingImage;
    /**holds level loading operation */
    private AsyncOperation async;

    /**
		deactivates LoadingCanvasGroup as there is no loading at the moment,
		sets image type as filled so it can work as progress bar and fill method to vertical,
		fill amount is set to zero as loading always starts from 0%
	*/
    public void Start()
    {
        LoadingCanvasGroup.gameObject.SetActive(false);
        LoadingImage.type = Image.Type.Filled;
        LoadingImage.fillMethod = Image.FillMethod.Horizontal;
        LoadingImage.fillAmount = 0;
    }

    /**
		activates LoadingCanvasGroup and starts coroutine of loading
		@param sceneIndex build index of scene to load
	 */
    public void LoadScene(int sceneIndex)
    {
        LoadingCanvasGroup.gameObject.SetActive(true);
        StartCoroutine(load(sceneIndex));
    }
    /**	
		loads scene that is after current scene in build
	 */
    public void LoadNextScene()
    {
        LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /**
		loads scene with build index that is equal to sceneIndex using async operation,
		also sets LoadingImage.fillAmount to progress of async operation
		@param sceneIndex build index of scene to load
	 */
    IEnumerator load(int sceneIndex)
    {

        async = SceneManager.LoadSceneAsync(sceneIndex); //creates async operation that loads scene with sceneIndex
        async.allowSceneActivation = false; //blocks switching to scene when its loaded

        while ( !async.isDone )
        { //as long as loading is not done
            LoadingImage.fillAmount = async.progress * 1.11f; //sets filling of image to async progress (multiplied by 1.11 because if async.allowSceneActivation=false, async.progress means fully loaded scene)
            if ( async.progress >= 0.9f )
            { //if scene is already loaded
                LoadingImage.fillAmount = 1; //show full image
                async.allowSceneActivation = true; //allow to switch scene
            }
            yield return null; // yield return null as long as scene isn't loaded
        }

    }
}