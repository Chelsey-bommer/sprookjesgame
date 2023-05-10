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
    public Quest2[] allQuests;
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
        allQuests = FindObjectsOfType<Quest2>();  // all objects with quest script attached
        dialoguescript = scriptObject.GetComponent<TriggerDialogue>();
        itemscript = scriptObject2.GetComponent<ItemPickup>();
        //itemscript.enabled = false;
        currentColor = questItem.color;
    }

    public void OnTriggerStay(Collider other)
    {

        ////////// Quest 1: Grab a pair of cups
        // Task 1: move barrel -- zie inventory item controller
        if(gameObject.name.Contains("Barrel")){
            if(Input.GetMouseButtonDown(0)){
                Destroy(gameObject);
                GameManager.instance.barrelDestroyed = true;
            }
        }
        // Task 2: grab cups -- //zie gamemanager r.115
        // Task 3: put cups in basket -- zie inventory item controller
        if(gameObject.name.Contains("Mand")){
            GameManager.instance.mandTouch = true;

            if(GameManager.instance.questOne){
                FinishQuest();
            }
        }

       if(gameObject.name.Contains("Dog")){
            GameManager.instance.dogTouch = true;

            if(GameManager.instance.questTwo){
                FinishQuest();
            }
        }

        if(gameObject.name.Equals("colliderobject")){
            GameManager.instance.colliderTouch = true;

            if(GameManager.instance.questThree){
                FinishQuest();
            }
        }

        

        if(gameObject.name.Equals("colliderobject2")){
            GameManager.instance.collider2Touch = true;

            if(GameManager.instance.questFour){
                FinishQuest();
            }
        } 

        //part 2
        

        if (gameObject.name.Contains("path1"))
        {
            //quest something voltooid
        }
        if (gameObject.name.Contains("path2"))
        {
            //quest something voltooid
        }


    }

    public void Update()
    {

        
        // if (GameManager.instance.questTwo){
        //     FinishQuest();
        // }
        // if (GameManager.instance.questThree){
        //     FinishQuest();
        // }
        // if (GameManager.instance.questFour){
        //     FinishQuest();
        // }
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

        foreach (Quest2 quest in allQuests)
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
