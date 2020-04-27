using UnityEngine;

public class ItemObject : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Item item;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.sprite = item.sprite;
    }

    private void OnTriggerStay2D(Collider2D other) {
        // Player player = other.GetComponent<Player>();

        if (Input.GetButtonDown("Interact"))
        {
            for (int i = 0; i < Player.items.Length; i++)
            {
                if (Player.items[i] == null)
                {
                    Player.items[i] = item;
                    Destroy(gameObject);
                    break;
                }
                else
                {
                    if (i == Player.items.Length - 1)
                    {
                        Debug.Log("INVENTORY FULL");
                    }
                }
            }
        }
    }
}
