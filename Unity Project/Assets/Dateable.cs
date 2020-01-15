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

    private void Start()
    {
        GetComponent<Dialogues>().SetTree("Initial"); 
    }

    public void SetEmotion(string emotion)
    {
        GetComponent<Image>().sprite = Emotions.Find(x => x.emotion == emotion).image;
    }
}
