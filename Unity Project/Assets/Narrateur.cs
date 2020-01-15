using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VIDE_Data;

public class Narrateur :MonoBehaviour
{

    public PlayerData playerData;

    private void Start()
    {
        playerData = GameObject.Find("Player").GetComponent<PlayerData>();
    }

    public void MeetBoulangerCheck()
    {
        //TODO link with tag check
        //if (playerData.HasTag("FirstNightDone"))
        if (true)
        {
            VD.SetNode(1);
            
        } else
        {
            VD.BeginDialogue(GameObject.Find("Boulanger").GetComponent<Dateable>().VIDE);
        }
    }
}
