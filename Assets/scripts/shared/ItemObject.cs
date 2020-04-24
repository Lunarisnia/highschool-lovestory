using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Item item;
    public Inventory inventory;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.sprite = item.sprite;
    }
    private void OnTriggerStay2D(Collider2D other) {
        if (Input.GetButtonDown("Interact"))
        {
            for (int i = 0; i < inventory.items.Length; i++)
            {
                if (inventory.items[i] == null)
                {
                    inventory.items[i] = item;
                    Destroy(gameObject);
                    break;
                }
                else
                {
                    if (i == inventory.items.Length - 1)
                    {
                        Debug.Log("INVENTORY FULL");
                    }
                }
            }
        }
    }
}
