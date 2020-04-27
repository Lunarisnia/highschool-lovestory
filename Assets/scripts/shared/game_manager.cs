using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class GameManager
{
    public static int maxMoney = 999999;

    public static int addMoney(Player Player, int amount)
    {
        int lastMoney = Player.money;
        Player.money += amount;
        if (Player.money > GameManager.maxMoney)
        {
            Player.money = GameManager.maxMoney;
        }
        return lastMoney;
    }

    public static void saveGame()
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream stream = new FileStream(API.getDataPath(Player.playerName), FileMode.OpenOrCreate);
        PlayerData playerData = new PlayerData();
        binaryFormatter.Serialize(stream, playerData);
        stream.Close();
    }

    public static PlayerData loadSave(string path)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        if (File.Exists(path))
        {
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = binaryFormatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.Log("Save file not found.");
            return null;
        }
    }
}

public class game_manager : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider loadingSlider;
    public Text finishedLoadingText;
    public Player Player;
    public TextMeshProUGUI moneyHud;
    public CursorSet cursors;

    private void Awake() {
        setCursorNorm();
    }
    
    public void setCursorNorm()
    {
        Cursor.SetCursor(cursors.normalCursor, Vector2.zero, CursorMode.ForceSoftware);
    }

    public void setCursorSelecting()
    {
        Cursor.SetCursor(cursors.selectingCursor, Vector2.zero, CursorMode.ForceSoftware);
    }

    public void loadLevel(int sceneIndex)
    {
        StartCoroutine(load(sceneIndex));
    }

    public void saveGame()
    {
        GameManager.saveGame();
    }

    public void loadGame(string path)
    {
        PlayerData data = GameManager.loadSave(path);
        Transform playerTf = Player.GetComponent<Transform>();
        Player.money = data.money;
        moneyHud.text = Player.money.ToString();
        Player.sec = data.sec;
        Player.hour = data.hour;
        playerTf.position = new Vector3(data.playerPosition[0], data.playerPosition[1], data.playerPosition[2]);
    }

    public void addMoney(int amount)
    {
        int lastMoney = GameManager.addMoney(Player, amount);
        StartCoroutine(increaseMoney(lastMoney, Player.money));
    }

    IEnumerator increaseMoney(int lastMoney, int newMoney)
    {
        int currentMoney = lastMoney;
        int range = newMoney - lastMoney;
        int valueLeft = range % 222;
        int multiplier = Mathf.RoundToInt((range - valueLeft) / 222);
        if (valueLeft > 0)
        {
            currentMoney += valueLeft;
            moneyHud.text = currentMoney.ToString();
        }
        for (int i = 1; i <= multiplier; i++)
        {
            currentMoney += 222;
            moneyHud.text = currentMoney.ToString();
            yield return null;
        }
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
