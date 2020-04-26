using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections.Generic;
using System;
using System.Collections;

public class LoadGameSelection : MonoBehaviour
{
    public GameObject contents;
    public GameObject button;
    public game_manager gameManager;
    void Start()
    {
        RectTransform contentsRect = GetComponent<RectTransform>();
        FileInfo[] files = getAllSaveFiles();
        for (int i = 0; i < files.Length; i++)
        {
            GameObject newButton = Instantiate(button) as GameObject;
            newButton.transform.SetParent(contents.transform, false);
            newButton.name = i.ToString();

            Button bt = newButton.GetComponent<Button>();
            Text btText = bt.GetComponentInChildren<Text>();
            btText.text = files[i].Name.Split('.')[0];
            bt.onClick.AddListener(delegate
            {
                API.loadedData = GameManager.loadSave(files[int.Parse(newButton.name)].FullName);
                gameManager.loadLevel(1);
                this.gameObject.SetActive(false);
            });
        }
    }

    FileInfo[] getAllSaveFiles()
    {
        DirectoryInfo info = new DirectoryInfo(Application.persistentDataPath);
        FileInfo[] files = info.GetFiles("*.plr");

        return files;
    }
}
