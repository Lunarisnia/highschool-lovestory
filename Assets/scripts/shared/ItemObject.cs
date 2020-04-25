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
        Player player = other.GetComponent<Player>();

        if (Input.GetButtonDown("Interact"))
        {
            for (int i = 0; i < player.items.Length; i++)
            {
                if (player.items[i] == null)
                {
                    player.items[i] = item;
                    Destroy(gameObject);
                    break;
                }
                else
                {
                    if (i == player.items.Length - 1)
                    {
                        Debug.Log("INVENTORY FULL");
                    }
                }
            }
        }
    }
}
