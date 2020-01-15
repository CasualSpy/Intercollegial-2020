using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class BookSelect : MonoBehaviour, IPointerClickHandler
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

    public void OnPointerClick(PointerEventData eventData)
    {
        textName.text = referencedDateable.Name;
        textDesc.text = referencedDateable.Description;
        GameObject.Find("DateableBook").GetComponent<Book>().SelectedDateable = referencedDateable;
    }
}
