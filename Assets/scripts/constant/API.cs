using UnityEngine;
public static class API
{
    public static string getDataPath(string playerName)
    {
        return string.Format("{0}/{1}.plr", Application.persistentDataPath, playerName);
    }
}
