using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public ShopItem Item;

    private void Start()
    {
        GetComponentInChildren<TextMeshProUGUI>().text = $"{Item.Item} - {Item.Price}$";

        GetComponent<Button>().onClick.AddListener(ShopButton_onClick);
    }

    void ShopButton_onClick()
    {
        ShopManager.Buy(Item);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GameObject.Find("Description").GetComponent<TextMeshProUGUI>().text = Item.Description;
        GameObject.Find("ItemName").GetComponent<TextMeshProUGUI>().text = Item.Item.ToString();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GameObject.Find("Description").GetComponent<TextMeshProUGUI>().text =  "Vous trouverez ici tout ce dont vous avez de besoin.";
        GameObject.Find("ItemName").GetComponent<TextMeshProUGUI>().text = "Magasin général";
    }

}
