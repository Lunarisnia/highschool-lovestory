using System.Collections;
using System.Collections.Generic;
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
        if (Input.GetButtonDown("Interact"))
        {
            for (int i = 0; i < GameManager.player.items.Length; i++)
            {
                if (GameManager.player.items[i] == null)
                {
                    GameManager.player.items[i] = item;
                    Destroy(gameObject);
                    break;
                }
                else
                {
                    if (i == GameManager.player.items.Length - 1)
                    {
                        Debug.Log("INVENTORY FULL");
                    }
                }
            }
        }
    }
}
