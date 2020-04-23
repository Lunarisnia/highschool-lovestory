using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class select_random_skit : MonoBehaviour
{
    private Text text;
    private void Awake()
    {
        text = GetComponent<Text>();
        readSkitsJson();
    }

    void readSkitsJson()
    {
        string json = File.ReadAllText("Assets/resources/skits.json");
        Skits skits = JsonUtility.FromJson<Skits>("{ \"skits\" : " + json + "}");

        int randomIndex = Random.Range(0, skits.skits.Length);
        text.text = skits.skits[randomIndex].skit;
    }
}
