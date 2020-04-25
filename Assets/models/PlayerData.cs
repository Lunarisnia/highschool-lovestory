using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : ScriptableObject
{
    public string playerName = "Player";
    public Item[] items = new Item[10];
    public int money = 0;
}
