using UnityEngine;
public static class API
{
    public static PlayerData loadedData;
    public static string resourcesPath = "/Resources/";
    public static string getDataPath(string playerName)
    {
        return string.Format("{0}/{1}.plr", Application.persistentDataPath, playerName);
    }

}
