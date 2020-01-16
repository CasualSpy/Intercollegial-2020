using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VIDE_Data;

public class Narrateur : MonoBehaviour
{

    public PlayerData playerData;
    public VIDE_Assign VIDE;
    DialogueManager dialogueManager;

    private void Start()
    {
        playerData = GameObject.Find("Player").GetComponent<PlayerData>();
        dialogueManager = GameObject.Find("Player").GetComponent<DialogueManager>();
        VIDE = GetComponent<VIDE_Assign>();
    }

    public void MeetBoulangerCheck()
    {
        if (playerData.HasTag("MetBoulanger"))
        {
            VD.SetNode(1);

        }
        else
        {
            VD.EndDialogue();
            playerData.StartDialog(GameObject.Find("Boulanger").GetComponent<Dateable>());
        }
    }

    public void GoCentralPlace()
    {
        VD.EndDialogue();
        dialogueManager.CurrentNPC = VIDE;
        dialogueManager.Begin();
        VD.SetNode(1);
    }

    public void GastonLogic()
    {
        Dateable gaston = GameObject.Find("Boulanger").GetComponent<Dateable>();

        VD.EndDialogue();
        dialogueManager.CurrentNPC = gaston.VIDE;
        dialogueManager.Begin();
    }

    public void GoSellStuff()
    {
        VD.EndDialogue();
        dialogueManager.CurrentNPC = VIDE;
        VD.SetNode(23);
        dialogueManager.Begin();
    }
}
