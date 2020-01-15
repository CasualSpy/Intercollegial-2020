using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueWindowScript : MonoBehaviour
{
    // Start is called before the first frame update
    TextMeshProUGUI contentText;
    TextMeshProUGUI titleText;
    void Awake()
    {
        contentText = transform.Find("Content").GetComponent<TextMeshProUGUI>();
        titleText = transform.Find("Title").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetText(string text)
    {
        contentText.text = text;
    }

    public void SetSpeaker(string speaker)
    {
        titleText.text = speaker;
    }
}
