using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCounter : MonoBehaviour
{
    TMPro.TextMeshProUGUI textBox;
    PlayerData playerData;

    void Start()
    {
        textBox = GetComponent<TMPro.TextMeshProUGUI>();
        playerData = GameObject.Find("Player").GetComponent<PlayerData>();
    }

    // Update is called once per frame
    void Update()
    {
        textBox.text = $"Argent: {playerData.Gold}$";
    }
}
