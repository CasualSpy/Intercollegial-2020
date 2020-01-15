using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class BookSelect : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    // Start is called before the first frame update
    public Dateable referencedDateable;
    TextMeshProUGUI textName;
    TextMeshProUGUI textDesc;
    void Start()
    {
        textName = GameObject.Find("textDateableName").GetComponent<TextMeshProUGUI>();
        textDesc = GameObject.Find("textDateableDesc").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("HOVERED!");
        textName.text = referencedDateable.Name;
        textDesc.text = referencedDateable.Description;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("THAT SOB CLICKED ME!");
    }
}
