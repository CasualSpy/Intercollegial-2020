using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BackButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Color color;
    void Start()
    {
        color = GetComponent<Image>().color;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Image>().color = new Color(82, 0, 0);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Image>().color = color;
    }
}
