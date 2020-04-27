using UnityEngine;
using UnityEditor;

public class LoadSystem : MonoBehaviour
{
    private game_manager game_Manager;
    public GameObject player;
    private void Awake()
    {
        if (API.loadedData != null)
        {
            game_Manager = GetComponent<game_manager>();


            Player.playerName = API.loadedData.playerName;
            Player.money = API.loadedData.money;
            game_Manager.moneyHud.text = API.loadedData.money.ToString();

            Player.sec = API.loadedData.sec;
            Player.hour = API.loadedData.hour;


            Vector3 lastPosition = new Vector3(API.loadedData.playerPosition[0], API.loadedData.playerPosition[1], API.loadedData.playerPosition[2]);
            player.transform.position = lastPosition;


            for (int i = 0; i < API.loadedData.itemPath.Length; i++)
            {
                if (API.loadedData.itemPath[i] != null)
                {
                    Item item = AssetDatabase.LoadAssetAtPath(API.loadedData.itemPath[i], typeof(Item)) as Item;
                    Player.items[i] = item;
                }
                else
                {
                    Player.items[i] = null;
                }
            }
        }

    }
}
