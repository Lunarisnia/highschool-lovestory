using System;
using UnityEditor;

[Serializable]
public class PlayerData
{
    public string playerName = "Player";
    public float[] playerPosition = new float[3];
    public string[] itemPath = new string[10];
    public int money = 0;
    public int sec = 0;
    public int hour = 0;

    public PlayerData()
    {
        playerName = Player.playerName;
        money = Player.money;
        sec = Player.sec;
        hour = Player.hour;
        for (int i = 0; i < Player.items.Length; i++)
        {
            if (Player.items[i] != null)
            {
                string path = AssetDatabase.GetAssetPath(Player.items[i]);
                itemPath[i] = path;
            }
            else
            {
                itemPath[i] = null;
            }

        }
        playerPosition[0] = Player.playerPosition.x;
        playerPosition[1] = Player.playerPosition.y;
        playerPosition[2] = Player.playerPosition.z;
    }
}
