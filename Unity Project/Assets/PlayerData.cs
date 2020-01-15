using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using System;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    private static PlayerData instance = null;
    public Dateable TalkingTo;
    DialogueManager dialogueManager;
    public List<string> Tags;
    public enum Item
    {
        None,
        Farine,
        Sucre,
        Fleurs,
        Pelle,
        LivreLocal,
        Poison
    }

    private void Start()
    {
        Gold = 5;
        dialogueManager = GetComponent<DialogueManager>();
    }

    public List<InventorySlot> Inventory { get; set; }
    public int Gold { get; set; }

    public PlayerData()
    {
        Inventory = new List<InventorySlot>();
        Tags = new List<string>();
    }

    public bool HasTag(string tag)
    {
        return Tags.Contains(tag);
    }

    public PlayerData GetInstance()
    {
        if (instance == null)
            instance = new PlayerData();
        return instance;
    }
    
    public void AddInventoryItem(Item item)
    {
        int index = Inventory.FindIndex(x => x.Item == item);
        if(index == -1)
        {
            Inventory.Add(new InventorySlot(item));
        }
        else
        {
            InventorySlot toModify = Inventory[index];
            toModify.Count++;
            Inventory[index] = toModify;
        }
    }

    public void RemoveInventoryItem(Item item)
    {
        int index = Inventory.FindIndex(x => x.Item == item);
        if (index != -1)
        {
            if (Inventory[index].Count > 1)
            {
                InventorySlot toModify = Inventory[index];
                toModify.Count--;
                Inventory[index] = toModify;
            }
            else
            {
                Inventory.RemoveAt(index);
            }
        }
    }

    public void StartDialog(Dateable dateable)
    {
        Debug.Log("Starting dialog with " + dateable.Name);
        TalkingTo = dateable;

        dialogueManager.CurrentNPC = dateable.VIDE;
        dialogueManager.Begin();
    }

        //Regex rx = new Regex("([\\w\\d]+?):([\\w\\d]+?);");
        //MatchCollection matches = rx.Matches(trigger);
        //foreach (Match match in matches)
        //{
        //    for (int i = 1; i < match.Groups.Count; i+=2)
        //    {
        //        string triggerName = match.Groups[i].Value;
        //        string value = match.Groups[i + 1].Value;
        //        Events(triggerName, value);
        //    }
        //}

    public void Yeet(string s, int i)
    {

    }

    public void Events(string name, string value)
    {
        switch (name.ToLower())
        {
            // Change NPC sprite to display another emotion
            case "emotion":
                TalkingTo.SetEmotion(value);
                break;
            // Add to NPC suspicion value (negative value to remove)
            case "suspicion":
                float parsed = 0f;
                if (float.TryParse(value, out parsed))
                    TalkingTo.Trust += parsed;
                break;
            // Set new dialog tree
            case "tree":
                TalkingTo.GetComponent<Dialogues>().SetTree(value);
                break;
            // Add new item to inventory
            case "addInventory":
                AddInventoryItem((Item)Enum.Parse(typeof(Item), value));
                break;
            // Remove item from inventory
            case "removeInventory":
                RemoveInventoryItem((Item)Enum.Parse(typeof(Item), value));
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
            case "addTag":
                Tags.Add(value);
                break;
        }
    }

    public void NextDialog()
    {
        dialogueManager.Next();
    }

    public void ShowBook()
    {

    }
}
