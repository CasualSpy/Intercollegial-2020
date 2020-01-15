using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VIDE_Data;

public class Book : MonoBehaviour
{
    public Dateable SelectedDateable;
    public bool CanOpen;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool Open()
    {
        if (CanOpen)
        {
            CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
            canvasGroup.alpha = 1;
            canvasGroup.blocksRaycasts = true;
            canvasGroup.interactable = true;
            return true;
        }
        else
            return false;
    }

    public void Close()
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.interactable = false;
    }

    public void Meet()
    {
        if (!VD.isActive)
            GameObject.Find("Player").GetComponent<PlayerData>().StartDialog(SelectedDateable);
        else
            Debug.Log("Player tried starting a dialogue while talking");
    }
}
