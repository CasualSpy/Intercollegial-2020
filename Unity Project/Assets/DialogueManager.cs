using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using VIDE_Data;
using System;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject container_NPC;
    public GameObject container_PLAYER;
    public TextMeshProUGUI text_NPC;
    public TextMeshProUGUI[] text_Choices;
    public VIDE_Assign CurrentNPC;
    PlayerData playerData;
    // Start is called before the first frame update
    // Use this for initialization
    void Start()
    {
        playerData = GameObject.Find("Player").GetComponent<PlayerData>();
        VD.LoadDialogues();


        container_NPC.SetActive(false);
        container_PLAYER.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Return) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        //{
        //    if (!VD.isActive)
        //    {
        //        Begin();
        //    }
        //    else
        //    {
        //        Next();
        //    }
        //}
    }

    public void Next()
    {
        VD.Next();
    }

    public void Begin()
    {
        VD.OnNodeChange += UpdateUI;
        VD.OnEnd += End;
        VD.BeginDialogue(CurrentNPC);
    }

    [Serializable]
    private struct JSONCheck
    {
        public List<string> tags;
        public List<InventorySlot> items;
    }

    void UpdateUI(VD.NodeData data)
    {
        container_NPC.SetActive(false);
        container_PLAYER.SetActive(false);
        if (data.isPlayer)
        {
            container_PLAYER.SetActive(true);
            for (int i = 0; i < text_Choices.Length; i++)
            {
                if (i < data.comments.Length)
                {
                    bool available = true;

                    string extraData = data.creferences[i].extraData;

                    if (extraData != "ExtraData" && extraData != "" && extraData != null)
                    {
                        JSONCheck checks = JsonUtility.FromJson<JSONCheck>(data.creferences[i].extraData);
                        foreach (string tag in checks.tags)
                        {

                            if (!playerData.HasTag(tag))

                                available = false;
                        }

                        foreach (InventorySlot item in checks.items)
                        {

                            if (!playerData.HasEnoughItem(item.Item, item.Count))

                                available = false;

                        }                    }

                    text_Choices[i].transform.parent.gameObject.GetComponent<Button>().interactable = available;
                    text_Choices[i].transform.parent.gameObject.SetActive(true);
                    text_Choices[i].text = data.comments[i];
                }
                else
                {
                    text_Choices[i].transform.parent.gameObject.SetActive(false);
                }
            }
            text_Choices[0].transform.parent.GetComponent<UnityEngine.UI.Button>().Select();
        }
        else
        {
            container_NPC.SetActive(true);
            text_NPC.text = data.comments[data.commentIndex];
            //Play Audio if any
            //if (data.audios[data.commentIndex] != null)
            //    audioSource.clip = data.audios[data.commentIndex];
            //audioSource.Play();
        }

        foreach (var item in data.extraVars)
        {
            playerData.Events(item.Key, item.Value.ToString());
        }

        if (data.sprite != null)
            playerData.TalkingTo.SetImage(data.sprite);
    }


    void End(VD.NodeData data)
    {
        container_NPC.SetActive(false);
        container_PLAYER.SetActive(false);
        VD.OnNodeChange -= UpdateUI;
        VD.OnEnd -= End;
        VD.EndDialogue();
    }

    void OnDisable()
    {
        if (container_NPC != null)
            End(null);
    }

    public void SetPlayerChoice(int choice)
    {
        VD.nodeData.commentIndex = choice;
        if (Input.GetMouseButtonUp(0))
            VD.Next();
    }
}
