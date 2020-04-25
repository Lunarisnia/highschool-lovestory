using System.Collections;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    private bool isInventoryOpen = false;
    public TextMeshProUGUI moneyHud;

    public int addMoney(int valueAdded)
    {
        int lastMoney = GameManager.player.money;
        GameManager.player.money += valueAdded;
        if (GameManager.player.money > GameManager.maxMoney)
        {
            GameManager.player.money = GameManager.maxMoney;
        }
        StartCoroutine(increaseMoney(lastMoney, GameManager.player.money));
        return GameManager.player.money;
    }

    IEnumerator increaseMoney(int lastMoney, int newMoney)
    {
        int currentMoney = lastMoney;
        int range = newMoney - lastMoney;
        int valueLeft = range % 222;
        int multiplier = Mathf.RoundToInt((range - valueLeft) / 222);
        if (valueLeft > 0)
        {
            currentMoney += valueLeft;
            moneyHud.text = currentMoney.ToString();
        }
        for (int i = 1; i <= multiplier; i++)
        {
            currentMoney += 222;
            moneyHud.text = currentMoney.ToString();
            yield return null;
        }
    }

    public void openInventory()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            if (!isInventoryOpen)
            {
                isInventoryOpen = !isInventoryOpen;
                Debug.Log("OPEN");
                foreach (var item in GameManager.player.items)
                {
                    Debug.Log(item);
                }
            }

        }
    }
}
