using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public static void Buy(ShopItem item)
    {
        if (item.Item == PlayerData.Item.None)
            return;

        PlayerData player = GameObject.Find("Player").GetComponent<PlayerData>();
        if (player.Gold >= item.Price)
        {
            player.Gold -= item.Price;
            player.AddInventoryItem(item.Item);
            GameObject.Find("Description").GetComponent<TextMeshProUGUI>().text = $"Vous achetez 1 {item.Item.ToString()}";
        }
        else
        {
            GameObject.Find("Description").GetComponent<TextMeshProUGUI>().text = $"Il vous manque {item.Price - player.Gold}$";
        }
    }

    public void Show()
    {
        CanvasGroup shop = GameObject.Find("Shop").GetComponent<CanvasGroup>();
        shop.alpha = 1;
        shop.blocksRaycasts = true;
    }

    public void Hide()
    {
        CanvasGroup shop = GameObject.Find("Shop").GetComponent<CanvasGroup>();
        shop.alpha = 0;
        shop.blocksRaycasts = false;
    }
}
