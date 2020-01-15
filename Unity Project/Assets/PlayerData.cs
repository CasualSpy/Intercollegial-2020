using System.Collections;
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
    private bool WaitForInput = false;
    public enum Item
    {
        None,
        Farine,
        Sucre,
        Fleurs,
        Pelle,
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

        TalkingTo.dialogues.Reset();
        ReadCurrentDialog();
    }

    void HandleTriggers(string trigger)
    {
        Regex rx = new Regex("([\\w\\d]+?):([\\w\\d]+?);");
        MatchCollection matches = rx.Matches(trigger);
        foreach (Match match in matches)
        {
            for (int i = 1; i < match.Groups.Count; i+=2)
            {
                string triggerName = match.Groups[i].Value;
                string value = match.Groups[i + 1].Value;

                switch(triggerName.ToLower())
                {
                    // Change NPC sprite to display another emotion
                    case "emotion":
                        TalkingTo.SetEmotion(value);
                        break;
                    // Add to NPC suspicion value (negative value to remove)
                    case "suspicion":
                        float parsed = 0f;
                        if (float.TryParse(value, out parsed))
                            TalkingTo.Trust -= parsed;
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

    public void NextDialog()
    {
        TalkingTo.dialogues.Next();
        ReadCurrentDialog();
    }

    void ReadCurrentDialog()
    {
        string dialog = TalkingTo.dialogues.GetCurrentDialogue();
        GameObject.Find("TextBox").GetComponent<DialogueWindowScript>().SetText(dialog);
        if (TalkingTo.dialogues.HasTrigger())
            HandleTriggers(TalkingTo.dialogues.GetTrigger());

        string[] choices = TalkingTo.dialogues.GetChoices();

        if (choices.Length > 0)
        {
            //Decisions!
            GameObject.Find("ChoiceBox").GetComponent<DecisionWindow>().PromptUser(choices[0], choices[1], choices[2]);
            WaitForInput = true;
        }
    }

    public void RecieveChoice(string choice)
    {
        WaitForInput = false;
        TalkingTo.dialogues.NextChoice(choice);
        ReadCurrentDialog();
    }
}
