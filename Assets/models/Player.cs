using UnityEngine;

public class Player : MonoBehaviour
{
    public static string playerName = "THEPLAYER";
    public static Item[] items = new Item[10];
    public static int money = 0;
    public static int sec = 0;
    public static int hour = 0;
    public static Vector3 playerPosition;

    private void Update()
    {
        playerPosition = transform.position;
    }
}
