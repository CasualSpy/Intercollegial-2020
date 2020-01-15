using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct InventorySlot
{
    public PlayerData.Item Item;
    public int Count;

    public InventorySlot(PlayerData.Item item)
    {
        Item = item;
        Count = 1;
    }
}
