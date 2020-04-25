using UnityEngine;

[CreateAssetMenu(fileName = "New item", menuName = "Item/New")]
public class Item : ScriptableObject
{

    public string id;
    public Sprite sprite;
    public string itemName = "New item";
    public string description = "description.";
    public int price = 0;
    public enum Category { Food, Flower, Book, Junk };
    public Category category = Category.Food;

    private void Awake()
    {
        System.Guid uuid = System.Guid.NewGuid();
        id = uuid.ToString();
    }
}
