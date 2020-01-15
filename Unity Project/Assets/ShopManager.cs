using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public void Buy(ShopItem item)
    {
        if (item.Item == PlayerData.Item.None)
            return;

        PlayerData player = GameObject.Find("Player").GetComponent<PlayerData>();
        if (player.Gold >= item.Price)
        {
            player.Gold -= item.Price;
            player.Inventory.Add(item.Item);
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
