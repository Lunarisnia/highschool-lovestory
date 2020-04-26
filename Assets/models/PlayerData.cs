using System;
using UnityEditor;

[Serializable]
public class PlayerData
{
    public string playerName = "Player";
    // public Byte sprite;
    public float[] playerPosition = new float[3];
    public string[] itemPath = new string[10];
    public int money = 0;
    public int sec = 0;
    public int hour = 0;

    public PlayerData(Player player)
    {
        playerName = player.playerName;
        money = player.money;
        sec = player.sec;
        hour = player.hour;
        for (int i = 0; i < player.items.Length; i++)
        {
            if (player.items[i] != null)
            {
                string path = AssetDatabase.GetAssetPath(player.items[i]);
                itemPath[i] = path;
            }
            else
            {
                itemPath[i] = null;
            }

        }
        playerPosition[0] = player.playerPosition.x;
        playerPosition[1] = player.playerPosition.y;
        playerPosition[2] = player.playerPosition.z;
    }
}
