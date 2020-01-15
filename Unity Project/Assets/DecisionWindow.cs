using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class DecisionWindow : MonoBehaviour
{
    // Start is called before the first frame update

    TextMeshProUGUI textChoice1;
    TextMeshProUGUI textChoice2;
    TextMeshProUGUI textChoice3;

    CanvasGroup canvasGroup;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();

        textChoice1 = transform.Find("Choice1").GetComponentInChildren<TextMeshProUGUI>();
        textChoice2 = transform.Find("Choice2").GetComponentInChildren<TextMeshProUGUI>();
        textChoice3 = transform.Find("Choice3").GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Choice1()
    {
        ReturnChoice(textChoice1.text);
    }

    public void Choice2()
    {
        ReturnChoice(textChoice2.text);
    }

    public void Choice3()
    {
        ReturnChoice(textChoice3.text);
    }

    public void PromptUser(string choice1, string choice2, string choice3)
    {
        canvasGroup.interactable = true;
        canvasGroup.alpha = 1;


        textChoice1.text = choice1;
        textChoice2.text = choice2;
        textChoice3.text = choice3;
    }

    void ReturnChoice(string choice)
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        Debug.Log("You chose:" + choice);
        //TODO send choice to player script
    }
}
