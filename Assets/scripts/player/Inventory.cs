using System.Collections;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    private bool isInventoryOpen = false;
    public TextMeshProUGUI moneyHud;
    private Player player;

    private void Start() {
        player = GetComponent<Player>();
    }

    public int addMoney(int valueAdded)
    {
        int lastMoney = player.money;
        player.money += valueAdded;
        if (player.money > GameManager.maxMoney)
        {
            player.money = GameManager.maxMoney;
        }
        StartCoroutine(increaseMoney(lastMoney, player.money));
        return player.money;
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
                foreach (var item in player.items)
                {
                    Debug.Log(item);
                }
            }

        }
    }
}
