using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public static class GameManager
{
    public static PlayerData player = new PlayerData();
    public static int maxMoney = 999999;
    public static int sec = 0;
    public static int hour = 0;
    public static void saveGame()
    {

    }
}
public class game_manager : MonoBehaviour
{
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private Slider loadingSlider;
    [SerializeField] private Text finishedLoadingText;
    Coroutine clockRoutine;
    public TextMeshProUGUI clock;
    private void Start()
    {
        clockRoutine = StartCoroutine(startClock());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            StopCoroutine(clockRoutine);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            clockRoutine = StartCoroutine(startClock());
        }
    }
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
    IEnumerator startClock()
    {
        while (true)
        {
            if (GameManager.hour < 12)
            {
                clock.text = string.Format("{0}:{1} am", LeadingZero(GameManager.hour), LeadingZero(GameManager.sec));
            }
            else
            {
                clock.text = string.Format("{0}:{1} pm", LeadingZero(GameManager.hour), LeadingZero(GameManager.sec));
            }

            yield return new WaitForSeconds(1.5f);
            GameManager.sec++;
            if (GameManager.sec == 60)
            {
                GameManager.hour++;
                GameManager.sec = 0;
            }
            if (GameManager.hour > 24)
            {
                GameManager.hour = 0;
            }
        }
    }

    string LeadingZero(int number)
    {
        return number.ToString().PadLeft(2, '0');
    }
}
