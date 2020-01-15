using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ShopItem
{

    public PlayerData.Item Item;
    public int Price;
    public string Description;

    public ShopItem(PlayerData.Item item, int price, string description = "Default description")
    {
        Item = item;
        Price = price;
        Description = description;
    }
}
