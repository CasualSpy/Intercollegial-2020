using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponentsInChildren<Image>()[1].enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponentsInChildren<Image>()[1].enabled = false;
    }
}
