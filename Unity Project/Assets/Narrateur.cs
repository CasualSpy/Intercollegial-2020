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
        playerData.TalkingTo = null;
        dialogueManager.CurrentNPC = VIDE;
        dialogueManager.Begin();
        VD.SetNode(1);
        //VD.isActive
    }

    public void GastonLogic()
    {
        Dateable gaston = GameObject.Find("Gaston").GetComponent<Dateable>();

        if (playerData.HasTag("GastonDead"))
        {
            GoSellStuff();
        }
        else
        {
            VD.EndDialogue();
            playerData.StartDialog(gaston);
        }
    }

    public void GoSellStuff()
    {
        VD.EndDialogue();
        dialogueManager.CurrentNPC = VIDE;
        playerData.TalkingTo = null;
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

    public void GastonTrustSplit()
    {
        Dateable gaston = GameObject.Find("Gaston").GetComponent<Dateable>();
        Debug.Log("Gaston trust:" + gaston.Trust);
        if (gaston.Trust >= 4)
        {
            
            //Can suggest meeting
            VD.SetNode(25);
        }
        else { VD.SetNode(18); }
    }

    public void GoHome()
    {
        VD.EndDialogue();
        dialogueManager.CurrentNPC = VIDE;
        playerData.TalkingTo = null;
        dialogueManager.Begin();
    }

    public void FrancoisLogic()
    {
        Dateable francois = GameObject.Find("Francois").GetComponent<Dateable>();
        if (playerData.HasTag("FrancoisDead"))
        {
            VD.SetNode(29);
        } else
        {
            VD.EndDialogue();
            //playerData.TalkingTo = francois;
            playerData.StartDialog(francois);
        }
    }

    public void ArmanCanYeet()
    {
        if (playerData.HasTag("canYeet"))
            playerData.Tags.Remove("canYeet");
        if (playerData.HasTag("isDrunk") && playerData.TalkingTo.Trust <= 1)
        {
            playerData.Tags.Add("canYeet");
        }
    }

    public void End()
    {
        VD.EndDialogue();
        playerData.ShowWinScreen();
    }
}
