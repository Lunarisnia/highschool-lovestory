using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Item[] items = new Item[10];

    private bool isInventoryOpen = false;

    private void Update()
    {
        openInventory();

    }

    private void openInventory()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            if (!isInventoryOpen)
            {
                isInventoryOpen = !isInventoryOpen;
                Debug.Log("OPEN");
                foreach (var item in items)
                {
                    Debug.Log(item);
                }
            }

        }
    }
}
