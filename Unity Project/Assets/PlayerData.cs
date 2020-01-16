using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using System;
using UnityEngine.UI;
using VIDE_Data;

public class PlayerData : MonoBehaviour
{
    public Dateable TalkingTo;
    DialogueManager dialogueManager;
    public List<string> Tags;
    public enum Item
    {
        None,
        Farine,
        Sucre,
        Fleurs_toxiques,
        Pelle,
        LivreLocal,
        Poison,
        Patisserie,
        Patisserie_Empoisonnee,
        Pain
    }

    public void StartGame()
    {
        CanvasGroup canvasGroup = GameObject.Find("MainMenu").GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0f;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;

        dialogueManager.CurrentNPC = GameObject.Find("Narrateur").GetComponent<Narrateur>().VIDE;
        dialogueManager.Begin();
    }

    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ShowWinScreen()
    {
        CanvasGroup winscreen = GameObject.Find("WinScreen").GetComponent<CanvasGroup>();
        winscreen.alpha = 1;
        winscreen.interactable = true;
        winscreen.blocksRaycasts = true;
    }

    public void RollCredits()
    {
        CanvasGroup mainMenu = GameObject.Find("MainMenu").GetComponent<CanvasGroup>();
        mainMenu.alpha = 0f;
        mainMenu.interactable = false;
        mainMenu.blocksRaycasts = false;
        CanvasGroup creditsMenu = GameObject.Find("CreditsMenu").GetComponent<CanvasGroup>();
        creditsMenu.alpha = 1f;
        creditsMenu.interactable = true;
        creditsMenu.blocksRaycasts = true;
    }
    public void Back()
    {
        CanvasGroup creditsMenu = GameObject.Find("CreditsMenu").GetComponent<CanvasGroup>();
        creditsMenu.alpha = 0f;
        creditsMenu.interactable = false;
        creditsMenu.blocksRaycasts = false;
        CanvasGroup mainMenu = GameObject.Find("MainMenu").GetComponent<CanvasGroup>();
        mainMenu.alpha = 1f;
        mainMenu.interactable = true;
        mainMenu.blocksRaycasts = true;
    }

    public string GetInventoryString()
    {
        string ret = "";
        foreach (InventorySlot slot in Inventory)
        {
            ret += $"{slot.Item.ToString().Replace('_', ' ')} x {slot.Count}{Environment.NewLine}";
        }
        return ret;
    }

    
    private void Start()
    {
        Gold = 5;
        dialogueManager = GetComponent<DialogueManager>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Return) && !VD.nodeData.isPlayer)
        {
            dialogueManager.Next();
        }
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

    public bool HasEnoughItem(Item item, int qty)
    {
        return Inventory.Find(x => x.Item == item).Count >= qty;
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

        Debug.Log("Added to inv:" + item.ToString());
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
        Debug.Log("Removed from inv:" + item.ToString());
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
        //TODO KILL MAIRE
    }

    public void Events(string name, string value)
    {
        switch (name.ToLower().Trim())
        {
            // Change NPC sprite to display another emotion
            case "emotion":
                TalkingTo.SetEmotion(value);
                break;
            // Add to NPC suspicion value (negative value to remove)
            case "trust":
                float parsed = 0f;
                if (float.TryParse(value, out parsed))
                {
                    TalkingTo.Trust += parsed;
                    if (TalkingTo.Trust < 0)
                        TalkingTo.Trust = 0;
                }
                break;
            // Set new dialog tree
            case "tree":
                TalkingTo.GetComponent<Dialogues>().SetTree(value);
                break;
            // Add new item to inventory
            case "addinventory":
                AddInventoryItem((Item)Enum.Parse(typeof(Item), value));
                break;
            // Remove item from inventory
            case "removeinventory":
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
            case "addtag":
                Tags.Add(value);
                break;
            case "removeTag":
                Tags.Remove(value);
                break;
        }
    }

    //FOREVER ALONE
    public void NextDialog()
    {
        dialogueManager.Next();
    }

    public void ShowBook()
    {

    }
}
