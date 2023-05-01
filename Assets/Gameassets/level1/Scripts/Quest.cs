using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Quest : MonoBehaviour
{
    // Quest list color and percentage logic
    public Image questItem;

    public Color completedColor;
    public Color activeColor;

    public Color currentColor;

    public TMP_Text percentage;

    public Quest[] allQuests;

    private TriggerDialogue dialoguescript;
    public GameObject scriptObject;

    public GameObject child;
    public TMP_Text childText;
    public TMP_Text childText2;
    public TMP_Text childText3;
    public TMP_Text childText4;

    private GameObject findWood;

    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;

            
    void Start()
    {
        allQuests = FindObjectsOfType<Quest>();  // all objects with quest script attached
        //dialoguescript = gameObject.GetComponent<TriggerDialogue>();
        //dialoguescript = GameObject.Find("WoundedFriend").GetComponent<TriggerDialogue>();
        dialoguescript = scriptObject.GetComponent<TriggerDialogue>();
        
        currentColor = questItem.color;
        //child = transform.Find("list").gameObject;

        findWood = GameObject.FindGameObjectWithTag("Wood");
    }

    private void OnTriggerStay(Collider other)
    {

        //////////// Quest 1: Talk to this guy
        if (other.gameObject.name.Contains("Player"))
        {
            if (gameObject.name.Contains("WoundedFriend")){

                if (dialoguescript.dialogue){
                GameManager.instance.questOne = true;
                FinishQuest(); 
                }
            }
            
        }

       //////////////////Quest 2:
      // Part one: Locate hole
      
      if(gameObject.name.Contains("Hole")){
          GameManager.instance.questTwoPartOne = true;
          childText.color = Color.magenta;
          Debug.Log("Looked at hole");
       }
      //Part two: Collect wood
        if(gameObject.name.Contains("wood") && GameManager.instance.questTwoPartOne) {
            gameObject.SetActive(false);

            if(findWood.activeInHierarchy == false){ //if all the wood is collected
                GameManager.instance.questTwoPartTwo = true;
                childText2.color = Color.magenta;
                
            }
            
        }
        //Part three: Go to the carpenter
        dialoguescript.dialogue = true;
        if(gameObject.name.Contains("Carpenter") && GameManager.instance.questTwoPartOne && GameManager.instance.questTwoPartTwo){
            dialoguescript.dialogue = false;

            if (!dialoguescript.dialogue){
                GameManager.instance.questTwoPartThree = true;
                childText3.color = Color.magenta;
    
            }
        }
        //Part four: Replace the wall
        if(gameObject.name.Contains("Fence") && GameManager.instance.questTwoPartOne 
        && GameManager.instance.questTwoPartTwo && GameManager.instance.questTwoPartThree){

            
            if (Input.GetKey(KeyCode.R))
            {
                spriteRenderer.sprite = newSprite; 
                GameManager.instance.questTwoPartFour = true;
                childText4.color = Color.magenta;
            }

            if(GameManager.instance.questTwo){
                FinishQuest(); 
            }
        }

        ///////////////Quest 3: Find the lost kid
        // Task one: Talk to the parents
        if(gameObject.name.Contains("Parent")){
            
            if (dialoguescript.dialogue){
                GameManager.instance.questThreePartOne = true;
                childText.color = Color.magenta;
            }
        }
            
        // Task two: Talk to the postguard
        dialoguescript.dialogue = true;
        if(gameObject.name.Contains("Postguard") && GameManager.instance.questThreePartOne == true){
            dialoguescript.dialogue = false;

            if (!dialoguescript.dialogue){
                GameManager.instance.questThreePartTwo = true;
                childText.color = Color.magenta;
            }
        }
        // Task three: Find the kid
        dialoguescript.dialogue = true;
        if(gameObject.name.Contains("Kid") && GameManager.instance.questThreePartOne && GameManager.instance.questThreePartTwo){
            dialoguescript.dialogue = false;

            if (dialoguescript.dialogue){
                GameManager.instance.questThreePartThree = true;
                
            }
            if(GameManager.instance.questThree){
                FinishQuest(); 
            }
        }


    }

    public void FinishTask(){
      childText.text = "<color=green>Done</color>";
      childText.color = Color.green;

      //works!!
    }

    public void FinishQuest()
    {
        //FinishTask();
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
