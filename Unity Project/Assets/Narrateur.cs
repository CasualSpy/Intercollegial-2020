using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VIDE_Data;

public class Narrateur : MonoBehaviour
{

    public PlayerData playerData;
    public VIDE_Assign VIDE;


    private void Start()
    {
        playerData = GameObject.Find("Player").GetComponent<PlayerData>();
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
}
