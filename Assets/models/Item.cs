using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New item", menuName = "Item/New")]
public class Item : ScriptableObject
{
    public Sprite sprite;
    public string itemName = "New item";
    public string description = "description.";
    public int price = 0;
    public enum Category { Food, Flower, Book, Junk };
        public Category category = Category.Food;
}
