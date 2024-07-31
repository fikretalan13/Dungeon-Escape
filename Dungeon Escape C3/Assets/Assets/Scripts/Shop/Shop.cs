using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] GameObject shopPanel;
    public int currentSelectedItem;
    public int currentItemCost;
    Player player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.GetComponent<Player>();
            if (player != null)
            {
                UIManager.instance.OpenShop(player.diamondAmount);
            }
            shopPanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            shopPanel.SetActive(false);
        }
    }

    public void SelectItem(int item)
    {
        Debug.Log("SelectItem()" + item);

        switch (item)
        {
            case 0: //Flame sword
                UIManager.instance.UpdateShopSelection(-8);
                currentSelectedItem = 0;
                currentItemCost = 200;
                break;

            case 1: //Boots
                UIManager.instance.UpdateShopSelection(-122);
                currentSelectedItem = 1;
                currentItemCost = 400;
                break;

            case 2: //Key
                UIManager.instance.UpdateShopSelection(-228);
                currentSelectedItem = 2;
                currentItemCost = 100;
                break;
        }
    }

    public void BuyItem()
    {
        if (player.diamondAmount >= currentItemCost)
        {
            //award Item
            if (currentSelectedItem == 2)
            {
                GameManager.instance.HasKeyToCastle = true;
            }
            player.diamondAmount -= currentItemCost;
            shopPanel.SetActive(false);
        }
        else
        {
            Debug.Log("You dont have enough diamond");
            shopPanel.SetActive(false);
        }
    }
}
