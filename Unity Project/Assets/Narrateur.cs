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
        VD.SetNode(1);
        dialogueManager.Begin();
    }
}
