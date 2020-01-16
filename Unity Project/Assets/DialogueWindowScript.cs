using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using VIDE_Data;

public class DialogueWindowScript : MonoBehaviour, IPointerClickHandler
{
    // Start is called before the first frame update
    TextMeshProUGUI contentText;
    TextMeshProUGUI titleText;
    DialogueManager dialogueManager;
    void Awake()
    {
        contentText = transform.Find("Content").GetComponent<TextMeshProUGUI>();
        titleText = transform.Find("Title").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Start()
    {
        dialogueManager = GameObject.Find("Player").GetComponent<DialogueManager>();
    }

    public void SetText(string text)
    {
        contentText.text = text;
    }

    public void SetSpeaker(string speaker)
    {
        titleText.text = speaker;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (VD.isActive)
        {
            if (!VD.nodeData.isPlayer)
                dialogueManager.Next();
        }
    }
}
