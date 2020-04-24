using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class game_manager : MonoBehaviour
{
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private Slider loadingSlider;
    [SerializeField] private Text finishedLoadingText;

    public void loadLevel(int sceneIndex)
    {
        StartCoroutine(load(sceneIndex));
    }

    IEnumerator proceedNextScene(AsyncOperation operation, bool auto = false)
    {
        loadingSlider.gameObject.SetActive(false);
        finishedLoadingText.gameObject.SetActive(true);
        while (true)
        {
            if (!auto)
            {
                if (Input.anyKeyDown)
                {
                    operation.allowSceneActivation = true;
                    break;
                }
            }
            else
            {
                operation.allowSceneActivation = true;
                break;
            }
            yield return null;
        }
    }

    IEnumerator load(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Single);
        operation.allowSceneActivation = false;
        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            loadingSlider.value = progress;
            if (progress == 1)
            {
                StartCoroutine(proceedNextScene(operation));
                break;
            }
            yield return null;
        }

    }
}
