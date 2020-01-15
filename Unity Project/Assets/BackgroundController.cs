using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<Background> Backgrounds;

    public void SetBackground(string background)
    {
        try
        {
            GetComponent<Image>().sprite = Backgrounds.Find(x => x.background == background).image;
        } catch (System.Exception e)
        {
            Debug.LogError(e);
        }
    }
}
