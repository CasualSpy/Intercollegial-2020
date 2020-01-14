using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCTest : MonoBehaviour
{

    Dialogues dialogues;
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        dialogues = GetComponent<Dialogues>();
        text = GameObject.Find("DialogueText").GetComponent<Text>();
        dialogues.Reset();
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateText()
    {
        text.text = dialogues.GetCurrentDialogue();
    }

    private void OnMouseDown()
    {
        string[] choices = dialogues.GetChoices();
        if (choices.Length > 0)
        {
            dialogues.NextChoice(choices[0]);
        }
        else
        {
            dialogues.Next();
        }
        if (choices.Length > 0)
        {
            Debug.Log("CHOICES!");
            foreach (string item in choices)
            {
                Debug.Log(item);
            }
        }
        
        UpdateText();
    }
}
