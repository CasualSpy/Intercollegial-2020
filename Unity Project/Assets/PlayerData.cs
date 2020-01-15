﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using System;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    private static PlayerData instance = null;
    private bool InDialog = false;
    private Dateable TalkingTo;
    public enum Item
    {
    }

    private void Start()
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

    public void StartDialog(Dateable dateable)
    {
        Debug.Log("Starting dialog with " + dateable.Name);
        TalkingTo = dateable;

        //TODO actually start the dialogue
    }

    void HandleTriggers(string trigger)
    {
        Regex rx = new Regex("([\\w\\d]+):([\\w\\d]+);");
        MatchCollection matches = rx.Matches(trigger);
        foreach (Match match in matches)
        {
            for (int i = 1; i < match.Groups.Count; i+=2)
            {
                string triggerName = match.Groups[i].Value;
                string value = match.Groups[i + 1].Value;

                switch(triggerName)
                {
                    // Change NPC sprite to display another emotion
                    case "emotion":
                        TalkingTo.SetEmotion(value);
                        break;
                    // Add to NPC suspicion value (negative value to remove)
                    case "suspicion":
                        float parsed = 0f;
                        if (float.TryParse(value, out parsed))
                            TalkingTo.Suspicion += parsed;
                        break;
                    // Set new dialog tree
                    case "tree":
                        TalkingTo.GetComponent<Dialogues>().SetTree(value);
                        break;
                    // Add new item to inventory
                    case "addInventory":
                        Inventory.Add((Item)Enum.Parse(typeof(Item), value));
                        break;
                    // Remove item from inventory
                    case "removeInventory":
                        Inventory.Remove((Item)Enum.Parse(typeof(Item), value));
                        break;
                    // Add to player's gold (negative value to remove
                    case "gold":
                        int parsedGold = 0;
                        if (int.TryParse(value, out parsedGold))
                            Gold += parsedGold;
                        break;
                    // Change background sprite
                    case "background":
                        GameObject.Find("Background").GetComponent<BackgroundController>().SetBackground(value);
                        break;
                    // Change speaker name during dialog
                    case "speaker":
                        GameObject.Find("TextBox").GetComponent<DialogueWindowScript>().SetSpeaker(value);
                        break;
                }
            }
        }
    }
}
