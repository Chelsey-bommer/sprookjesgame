using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Quest : MonoBehaviour
{
    // Quest list color and percentage logic
    public Image questItem;
    public QuestArrow TargetArrow;
    private Color completedColor;
    private Color activeColor;
    public Color currentColor;
    private Color inactiveColor;
    private Color normalColor;
    public TMP_Text percentage;
    public Quest[] allQuests;

    private TriggerDialogue dialoguescript;
    private InventoryManager inventoryscript;
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

    private GameObject woundedfriend;
    private GameObject fence;
    private GameObject wood;
    private GameObject carpenter;
    private GameObject parent;
    private GameObject guard;
    private GameObject leftguard;
    private GameObject kid;
    private GameObject fletcher;
    

    void Start()
    {
        allQuests = FindObjectsOfType<Quest>();  // all objects with quest script attached
        dialoguescript = scriptObject.GetComponent<TriggerDialogue>();
        inventoryscript = scriptObject.GetComponent<InventoryManager>();
       
        woundedfriend = GameObject.Find("WoundedFriend");
        fence = GameObject.Find("Hole");
        wood = GameObject.Find("wood3");
        carpenter = GameObject.Find("Carpenter");
        parent = GameObject.Find("Parent");
        guard = GameObject.Find("Guardspost");
        leftguard = GameObject.Find("leftguard");
        kid = GameObject.Find("kid");
        fletcher = GameObject.Find("Fletcher");

//        currentColor = questItem.color;

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

    private void Update(){

        if (GameManager.instance.questThreePartTwo){
            childText2.color = completedColor;
        }

        //Set Arrow direction to this object
        if(!GameManager.instance.questOne){
            TargetArrow.target = woundedfriend.transform;
        }
        if(!GameManager.instance.questTwoPartOne && GameManager.instance.questOne){
            TargetArrow.target = fence.transform;
        }
        if(!GameManager.instance.questTwoPartTwo && GameManager.instance.questTwoPartOne && GameManager.instance.questOne){
            TargetArrow.target = wood.transform;
        }
        if(!GameManager.instance.questTwoPartThree && GameManager.instance.questTwoPartOne && GameManager.instance.questTwoPartTwo
        && GameManager.instance.questOne){
            TargetArrow.target = carpenter.transform;
        }
        if(!GameManager.instance.questTwoPartFour && GameManager.instance.questTwoPartThree && GameManager.instance.questTwoPartOne && GameManager.instance.questTwoPartTwo
        && GameManager.instance.questOne){
            TargetArrow.target = fence.transform;
        }

        if(!GameManager.instance.questThreePartOne && GameManager.instance.questOne && GameManager.instance.questTwo){
            TargetArrow.target = parent.transform;
        }
        if(!GameManager.instance.questThreePartTwo && GameManager.instance.questThreePartOne && GameManager.instance.questOne && GameManager.instance.questTwo){
            TargetArrow.target = leftguard.transform;
        }
        if(!GameManager.instance.questThreePartThree && GameManager.instance.questThreePartTwo && GameManager.instance.questThreePartOne && GameManager.instance.questOne && GameManager.instance.questTwo){
            TargetArrow.target = kid.transform;
        }

        if(!GameManager.instance.questFourPartOne && GameManager.instance.questOne && GameManager.instance.questTwo && GameManager.instance.questThree){
            TargetArrow.target = fletcher.transform;
        }
         if(!GameManager.instance.questFourPartTwo && GameManager.instance.questFourPartOne && GameManager.instance.questOne && GameManager.instance.questTwo && GameManager.instance.questThree){
            TargetArrow.target = guard.transform;
        }
        //TargetArrow.target = randomitem.transform;
        
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
        if (gameObject.name.Contains("Hole") && !GameManager.instance.questTwoPartOne && GameManager.instance.questOne)
        {
            GameManager.instance.questTwoPartOne = true;
            childText.color = completedColor;
            Debug.Log("Looked at hole");
        }
        //Part two: Collect wood
        if(gameObject.name.Contains("colliderobject") && GameManager.instance.questTwoPartOne)
        {
            GameManager.instance.touchDialogue10 = true;
            if(GameManager.instance.touchDialogue10){
                dialoguescript.dialogue10();
            }
            if (GameManager.instance.questTwoPartTwo){ 
            //if all the wood is collected
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
                inventoryscript.clearInv();
                GameManager.instance.questTwoPartThree = true;
                childText3.color = completedColor;

            }
        }

        // SEE TRIGGERSTAY for part four
        if(gameObject.name.Contains("Hole") && GameManager.instance.questTwoPartOne
        && GameManager.instance.questTwoPartTwo && GameManager.instance.questTwoPartThree){
            
            GameManager.instance.touchDialogue9 = true;

            if(GameManager.instance.touchDialogue9){
                dialoguescript.dialogue9();
            }
        }
        

        /////////////////////Quest 3: Find the lost kid
        // Task one: Talk to the parents
        if (gameObject.name.Contains("Parent") && GameManager.instance.questTwo)
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
        if (gameObject.name.Contains("leftguard") && GameManager.instance.questThreePartOne)
        {
            GameManager.instance.touchDialogue4 = true;
            if(GameManager.instance.questThreePartTwo == false){
                dialoguescript.dialogue4();
            }

            if (GameManager.instance.touchDialogue4)
            {
                GameManager.instance.questThreePartTwo = true;
               
            }
            if(GameManager.instance.questThreePartTwo){
                childText2.color = completedColor;
            }
        }
        

        //////////////////// Quest Four: Resupply the arrows
        // Part one: Talk to fletcher to get arrows
        if(gameObject.name.Contains("Fletcher") && GameManager.instance.questThree){

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
        if(gameObject.name.Contains("Guardspost") && GameManager.instance.questFourPartOne){
            GameManager.instance.touchDialogue7 = true;
            if(!GameManager.instance.questFourPartTwo && GameManager.instance.questFourPartOne){
                dialoguescript.dialogue7();
            }
            if (GameManager.instance.touchDialogue7 && GameManager.instance.arrowsDropped){
                GameManager.instance.questFourPartTwo = true;
                GameManager.instance.questFour = true;
                childText2.color = completedColor;
            }
            
            if (GameManager.instance.questFour)
            {
                FinishQuest();
            }
        }


    }

    public void OnTriggerStay(){

        if (gameObject.name.Contains("Carpenter") && GameManager.instance.questTwoPartOne && GameManager.instance.questTwoPartTwo)
        {
            if (GameManager.instance.dialogue2)
            {
                inventoryscript.clearInv();
            }
        }

        if(gameObject.name.Contains("colliderobject") && GameManager.instance.questTwoPartOne){
            if(GameManager.instance.questTwoPartTwo){ 
            //if all the wood is collected
             childText2.color = completedColor; 
          }
        }
         

        //////////////////////////////////// QUEST 2
        //Part four: Replace the wall
        if(gameObject.name.Contains("Hole") && GameManager.instance.questTwoPartOne
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
