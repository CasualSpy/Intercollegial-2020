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
        if (VD.isActive)
        VD.EndDialogue();
        dialogueManager.CurrentNPC = VIDE;
        dialogueManager.Begin();
        VD.SetNode(1);
        //VD.isActive
    }

    public void GastonLogic()
    {
        Dateable gaston = GameObject.Find("Gaston").GetComponent<Dateable>();

        VD.EndDialogue();
        playerData.StartDialog(gaston);
    }

    public void GoSellStuff()
    {
        VD.EndDialogue();
        dialogueManager.CurrentNPC = VIDE;
        dialogueManager.Begin();
        VD.SetNode(23);
    }

    public void OpenShop()
    {
        VD.EndDialogue();
        dialogueManager.container_PLAYER.SetActive(false);
        GameObject.Find("Shop").GetComponent<ShopManager>().Show();
    }

    public void ShopClosed()
    {
        GameObject.Find("Shop").GetComponent<ShopManager>().Hide();
        GoCentralPlace();
    }
}
