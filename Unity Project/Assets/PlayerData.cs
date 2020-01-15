using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    private static PlayerData instance = null;
    public enum Item
    {
    }

    public List<Item> Inventory { get; set; }
    public int Gold { get; set; }

    private PlayerData()
    {
        Inventory = new List<Item>();
    }

    public PlayerData GetInstance()
    {
        if (instance == null)
            instance = new PlayerData();
        return instance;
    }
}
