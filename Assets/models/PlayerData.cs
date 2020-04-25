using System;

[Serializable]
public class PlayerData
{
    public string playerName = "Player";
    public float[] playerPosition = new float[3];
    public string[] itemId = new string[10];
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
            itemId[i] = player.items[i] != null ? player.items[i].id : null;
        }

        playerPosition[0] = player.playerPosition.x;
        playerPosition[1] = player.playerPosition.y;
        playerPosition[2] = player.playerPosition.z;
    }
}
