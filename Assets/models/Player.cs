using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public string playerName = "Player";
    public Sprite sprite;
    public Item[] items = new Item[10];
    public int money = 0;
    public int sec = 0;
    public int hour = 0;
    public Vector3 playerPosition;

    private void Update()
    {
        playerPosition = transform.position;
    }
}
