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

    public static int addMoney(Player player, int amount)
    {
        int lastMoney = player.money;
        player.money += amount;
        if (player.money > GameManager.maxMoney)
        {
            player.money = GameManager.maxMoney;
        }
        return lastMoney;
    }

    public static void saveGame(Player player)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream stream = new FileStream(API.getDataPath(player.playerName), FileMode.OpenOrCreate);
        PlayerData playerData = new PlayerData(player);
        binaryFormatter.Serialize(stream, playerData);
        stream.Close();
    }

    public static PlayerData loadSave(string playerName)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        if (File.Exists(API.getDataPath(playerName)))
        {
            FileStream stream = new FileStream(API.getDataPath(playerName), FileMode.Open);

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
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private Slider loadingSlider;
    [SerializeField] private Text finishedLoadingText;
    [SerializeField] private Player player;
    public TextMeshProUGUI moneyHud;
    public void loadLevel(int sceneIndex)
    {
        StartCoroutine(load(sceneIndex));
    }

    public void saveGame()
    {
        GameManager.saveGame(player);
    }

    public void loadGame()
    {
        PlayerData data = GameManager.loadSave(player.playerName);
        Transform playerTf = player.GetComponent<Transform>();
        player.money = data.money;
        moneyHud.text = player.money.ToString();
        player.sec = data.sec;
        player.hour = data.hour;
        playerTf.position = new Vector3(data.playerPosition[0], data.playerPosition[1], data.playerPosition[2]);
    }

    public void addMoney(int amount)
    {
        int lastMoney = GameManager.addMoney(player, amount);
        StartCoroutine(increaseMoney(lastMoney, player.money));
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
