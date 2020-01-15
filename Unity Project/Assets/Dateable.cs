using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dateable : MonoBehaviour
{
    public string Name;
    public string Description;
    public List<Emotion> Emotions;
    public float Trust;
    [HideInInspector]
    public Dialogues dialogues;
    public VIDE_Assign VIDE;

    private void Start()
    {
        //dialogues = GetComponent<Dialogues>();
        //dialogues.SetTree("Initial");
        VIDE = GetComponent<VIDE_Assign>();
        
    }

    public void SetEmotion(string emotion)
    {
        try
        {
            GetComponent<Image>().sprite = Emotions.Find(x => x.emotion == emotion).image;
        } catch (System.Exception e)
        {
            Debug.LogError(e);
        }
    }

    public void SetImage(Sprite sprite)
    {
        GetComponent<Image>().sprite = sprite;
    }
}
