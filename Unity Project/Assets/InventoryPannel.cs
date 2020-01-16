using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VIDE_Data;
using TMPro;

public class InventoryPannel : MonoBehaviour
{
    public bool CanOpen;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool Open()
    {
        if (CanOpen)
        {
            CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
            canvasGroup.alpha = 1;
            canvasGroup.blocksRaycasts = true;
            canvasGroup.interactable = true;
            GameObject.Find("List").GetComponent<TextMeshProUGUI>().text = GameObject.Find("Player").GetComponent<PlayerData>().GetInventoryString();
            return true;
        }
        else
            return false;
    }

    public void Close()
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.interactable = false;
    }

}
