﻿using UnityEngine;
using UnityEditor;

public class LoadSystem : MonoBehaviour
{
    private game_manager game_Manager;
    private void Awake()
    {
        game_Manager = GetComponent<game_manager>();
        game_Manager.player.playerName = API.loadedData.playerName;
        game_Manager.player.money = API.loadedData.money;
        game_Manager.moneyHud.text = API.loadedData.money.ToString();
        game_Manager.player.sec = API.loadedData.sec;
        game_Manager.player.hour = API.loadedData.hour;
        Vector3 lastPosition = new Vector3(API.loadedData.playerPosition[0], API.loadedData.playerPosition[1], API.loadedData.playerPosition[2]);
        game_Manager.player.transform.position = lastPosition;


        for (int i = 0; i < API.loadedData.itemPath.Length; i++)
        {
            if (API.loadedData.itemPath[i] != null)
            {
                Item item = AssetDatabase.LoadAssetAtPath(API.loadedData.itemPath[i], typeof(Item)) as Item;
                game_Manager.player.items[i] = item;
            }
            else
            {
                game_Manager.player.items[i] = null;
            }
        }
    }
}