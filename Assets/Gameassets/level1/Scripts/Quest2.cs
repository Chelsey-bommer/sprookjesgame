using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using TMPro;

public class Quest2 : MonoBehaviour
{
    public Image questItem;
    public Color completedColor;
    public Color activeColor;
    public Color currentColor;
    public TMP_Text percentage;
    public Quest[] allQuests;
    private TriggerDialogue dialoguescript;
    private ItemPickup itemscript;
    public GameObject scriptObject;
    public GameObject scriptObject2;
    public GameObject child;
    public TMP_Text childText;
    public TMP_Text childText2;
    public TMP_Text childText3;
    public TMP_Text childText4;



    void Start()
    {
        allQuests = FindObjectsOfType<Quest>();  // all objects with quest script attached
        dialoguescript = scriptObject.GetComponent<TriggerDialogue>();
        itemscript = scriptObject2.GetComponent<ItemPickup>();
        itemscript.enabled = false;
        currentColor = questItem.color;
    }

    private void OnTriggerEnter(Collider other){

        ////////// Quest 1: Grab a pair of cups
        // Task 1:


        // Task 2: 
        if(gameObject.name.Contains("Cups")){
           if(GameManager.instance.pickedUp){
             GameManager.instance.questOnePartTwo = true;
           }
        }
    }

        public void FinishQuest()
    {
        questItem.color = completedColor;
        currentColor = completedColor;
        questItem.GetComponent<Button>().interactable = false;  //set quest inactive when completed
        child.SetActive(false);
    }

    public void OnQuestClick()
    {

        foreach (Quest quest in allQuests)
        {

            quest.questItem.color = quest.currentColor;
        }
        questItem.color = activeColor;


        if (child.activeInHierarchy)
        {
            child.SetActive(false);
        }
        else
        {
            child.SetActive(true);

        }

    }
}
