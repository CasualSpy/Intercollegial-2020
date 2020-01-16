using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VIDE_Data;
using TMPro;
using UnityEngine.UI;

public class InventoryPanel : MonoBehaviour
{
    Button inventoryButton;
    TextMeshProUGUI buttonText;
    void Start()
    {
        inventoryButton = GameObject.Find("InventoryButton").GetComponent<Button>();
        buttonText = GameObject.Find("InventoryButton").GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Open()
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.interactable = true;
        GameObject.Find("List").GetComponent<TextMeshProUGUI>().text = GameObject.Find("Player").GetComponent<PlayerData>().GetInventoryString();
        inventoryButton.onClick.RemoveAllListeners();
        inventoryButton.onClick.AddListener(Close);
        buttonText.text = "Fermer";
    }

    public void Close()
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0f;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.interactable = false;
        inventoryButton.onClick.RemoveAllListeners();
        inventoryButton.onClick.AddListener(Open);
        buttonText.text = "Inventaire";
    }

}
