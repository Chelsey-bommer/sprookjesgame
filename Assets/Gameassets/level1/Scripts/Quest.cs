using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Quest : MonoBehaviour
{
    // Quest list color and percentage logic
    public Image questItem;
    private Color completedColor;
    private Color activeColor;
    public Color currentColor;
    private Color inactiveColor;
    private Color normalColor;
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
    
    public Image quest1;
    public Image quest2;
    public Image quest3;
    public Image quest4;


    void Start()
    {
        allQuests = FindObjectsOfType<Quest>();  // all objects with quest script attached
        dialoguescript = scriptObject.GetComponent<TriggerDialogue>();

        currentColor = questItem.color;

        findWood = GameObject.FindGameObjectWithTag("Wood");

        //SET variable colors
        ColorUtility.TryParseHtmlString("#009200", out completedColor);
        ColorUtility.TryParseHtmlString("#BDB7AB", out activeColor);
        ColorUtility.TryParseHtmlString("#dddddd", out inactiveColor);
        ColorUtility.TryParseHtmlString("#eeeeee", out normalColor);


        quest1.color = activeColor;
        quest1.GetComponent<Button>().interactable = true;
        quest2.GetComponent<Button>().interactable = false;
        quest3.GetComponent<Button>().interactable = false;
        quest4.GetComponent<Button>().interactable = false;
    }

    public void Update(){
        
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if(gameObject.name.Contains("taskboard")){
            GameManager.instance.boardDialogue = true;

            if(GameManager.instance.boardDialogue){
                dialoguescript.dialogue8();
            }
        }

        //////////// Quest 1: Talk to this guy
        if (gameObject.name.Contains("WoundedFriend"))
        {
            GameManager.instance.touchDialogue = true;
            if(GameManager.instance.questOne == false){
                dialoguescript.dialogue1();
            }
            if (GameManager.instance.dialogue1)
            {
                GameManager.instance.questOne = true;
                FinishQuest();
            }
            
        }
        

        //////////////////Quest 2:
        // Part one: Locate hole
        if (gameObject.name.Contains("Hole") && !GameManager.instance.questTwoPartOne)
        {
            GameManager.instance.questTwoPartOne = true;
            childText.color = completedColor;
            Debug.Log("Looked at hole");
        }
        //Part two: Collect wood
        if (gameObject.name.Contains("wood") && GameManager.instance.questTwoPartOne)
        {
            gameObject.SetActive(false);

            if (findWood.activeInHierarchy == false)
            { //if all the wood is collected
                GameManager.instance.questTwoPartTwo = true;
                childText2.color = completedColor;
            }

        }
        //Part three: Go to the carpenter
        if (gameObject.name.Contains("Carpenter") && GameManager.instance.questTwoPartOne && GameManager.instance.questTwoPartTwo)
        {

           GameManager.instance.touchDialogue2 = true;
           if(GameManager.instance.questTwoPartThree == false){
                dialoguescript.dialogue2();
            }

            if (GameManager.instance.dialogue2)
            {
                GameManager.instance.questTwoPartThree = true;
                childText3.color = completedColor;

            }
        }

        // SEE TRIGGERSTAY for part four
        

        /////////////////////Quest 3: Find the lost kid
        // Task one: Talk to the parents
        if (gameObject.name.Contains("Parent"))
        {   
            GameManager.instance.touchDialogue3 = true;
            if(GameManager.instance.questThreePartOne == false){
                dialoguescript.dialogue3();
            }
            if (GameManager.instance.touchDialogue3)
            {
                GameManager.instance.questThreePartOne = true;
                childText.color = completedColor;
            }
        }

        // Task two: Talk to the postguard
        if (gameObject.name.Contains("Postguard") && GameManager.instance.questThreePartOne == true)
        {
            GameManager.instance.touchDialogue4 = true;
            if(GameManager.instance.questThreePartTwo == false){
                dialoguescript.dialogue4();
            }

            if (GameManager.instance.touchDialogue4)
            {
                GameManager.instance.questThreePartTwo = true;
                childText.color = completedColor;
            }
        }
        

        //////////////////// Quest Four: Resupply the arrows
        // Part one: Talk to fletcher to get arrows
        if(gameObject.name.Contains("Fletcher")){

            GameManager.instance.touchDialogue6 = true;
            if(GameManager.instance.questFourPartOne == false){
                dialoguescript.dialogue6();
            }

            if (GameManager.instance.touchDialogue6){
                GameManager.instance.questFourPartOne = true;
                childText.color = completedColor;
            }
        }
        // Part Two:Bring arrows to the guards post
        if(gameObject.name.Contains("Guardspost")){
            GameManager.instance.touchDialogue7 = true;
            if(!GameManager.instance.questFourPartTwo && GameManager.instance.questFourPartOne){
                dialoguescript.dialogue7();
            }
            if (GameManager.instance.touchDialogue7 && GameManager.instance.arrowsDropped){
                GameManager.instance.questFourPartTwo = true;
                GameManager.instance.questFour = true;
                childText.color = completedColor;
            }
            if (GameManager.instance.questFour)
            {
                FinishQuest();
            }
        }


    }

    public void OnTriggerStay(){
        //////////////////////////////////// QUEST 2
        //Part four: Replace the wall
        if(gameObject.name.Contains("Hole") /* HOLE???? */ && GameManager.instance.questTwoPartOne
        && GameManager.instance.questTwoPartTwo && GameManager.instance.questTwoPartThree)
        {

            ////////////////// REMOVE ITEMS FROM INVENTORY?????????

            if (Input.GetKey(KeyCode.R))
            {
                spriteRenderer.sprite = newSprite;
                GameManager.instance.questTwoPartFour = true;
                childText4.color = completedColor;
            }

            if (GameManager.instance.questTwo)
            {
                FinishQuest();
            }
        }


        ///////////////////////////////////////////// QUEST THREE
        // Task three: Find the kid
        if (gameObject.name.Contains("Kid") && GameManager.instance.questThreePartOne && GameManager.instance.questThreePartTwo)
        {

            GameManager.instance.touchDialogue5 = true;
            if(GameManager.instance.questThreePartThree == false){
                dialoguescript.dialogue5();
                
            }
            if (GameManager.instance.touchDialogue5){
                GameManager.instance.questThreePartThree = true; //altijd true?
            }

            if (GameManager.instance.questThree)
            {
                FinishQuest();
            }
        }
    }

    public void FinishTask()
    {
        childText.text = "<color=green>Done</color>";
        childText.color = Color.green;

        //works!!
    }

    public void FinishQuest()
    {

        if(GameManager.instance.questOne){
            quest1.color = completedColor;
            quest1.GetComponent<Button>().interactable = false;
            quest2.GetComponent<Button>().interactable = true;
        }
        if(GameManager.instance.questTwo){
            quest2.color = completedColor;
            quest2.GetComponent<Button>().interactable = false;
            quest3.GetComponent<Button>().interactable = true;
        }
        if(GameManager.instance.questThree){
            quest3.color = completedColor;
            quest3.GetComponent<Button>().interactable = false;
            quest4.GetComponent<Button>().interactable = true;
        }
        if(GameManager.instance.questFour){
            quest4.color = completedColor;
            quest4.GetComponent<Button>().interactable = false;
        }

        child.SetActive(false);
    }


    public void OnQuestClick()
    {

        // foreach (Quest quest in allQuests)
        // {
        //     quest.questItem.color = inactiveColor;
        //     quest.questItem.GetComponent<Button>().interactable = false;
        // }
        // questItem.color = activeColor;
        // questItem.GetComponent<Button>().interactable = true;

        

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
