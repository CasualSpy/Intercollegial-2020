using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    public Dateable SelectedDateable;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Meet()
    {
        GameObject.Find("Player").GetComponent<PlayerData>().StartDialog(SelectedDateable);
    }
}
