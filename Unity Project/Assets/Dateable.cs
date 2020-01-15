using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dateable : MonoBehaviour
{
    public string Name;
    public string Description;
    public List<Emotion> Emotions;
    public float Suspicion;
    [HideInInspector]
    public Dialogues dialogues;


    private void Start()
    {
        dialogues = GetComponent<Dialogues>();
        dialogues.SetTree("Initial"); 

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
}
