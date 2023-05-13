using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using TMPro;

public class Quest2 : MonoBehaviour
{
    public Image questItem;
    public QuestArrow TargetArrow;
    private Color completedColor;
    private Color activeColor;
    public Color currentColor;
    private Color inactiveColor;
    private Color normalColor;
    public TMP_Text percentage;
    public Quest2[] allQuests;
    private TriggerDialogue2 dialoguescript;
    private InventoryManager inventoryscript;
    private ItemPickup itemscript;
    public GameObject scriptObject;
    public GameObject scriptObject2;
    public GameObject child;
    public TMP_Text childText;
    public TMP_Text childText2;
    public TMP_Text childText3;
    public TMP_Text childText4;
    public Image quest1;
    public Image quest2;
    public Image quest3;
    public Image quest4;
    private GameObject cups;
    private GameObject cups2;
    private GameObject mand;
    private GameObject apples;
    private GameObject grapes;
    private GameObject cake;
    private GameObject wine;
    private GameObject dogfood;
    private GameObject carpenter;
    private GameObject farmer;
    private GameObject bakery;

    void Start()
    {
        allQuests = FindObjectsOfType<Quest2>();  // all objects with quest script attached
        dialoguescript = scriptObject.GetComponent<TriggerDialogue2>();
        itemscript = scriptObject2.GetComponent<ItemPickup>();
        inventoryscript = scriptObject.GetComponent<InventoryManager>();
        
        currentColor = questItem.color;

        cups = GameObject.Find("Cups");
        cups2 = GameObject.Find("Cups2");
        mand = GameObject.Find("Mand");
        apples = GameObject.Find("Apples");
        grapes = GameObject.Find("Grapes");
        cake = GameObject.Find("Cake");
        wine = GameObject.Find("Wine");
        dogfood = GameObject.Find("Dogfood");
        carpenter = GameObject.Find("Carpenter");
        farmer = GameObject.Find("farmerdad");
        bakery = GameObject.Find("TentBakery");


        //SET variable colors
        ColorUtility.TryParseHtmlString("#009200", out completedColor);
        ColorUtility.TryParseHtmlString("#BDB7AB", out activeColor);
        ColorUtility.TryParseHtmlString("#dddddd", out inactiveColor);
        ColorUtility.TryParseHtmlString("#eeeeee", out normalColor);

      
        quest1.GetComponent<Button>().interactable = true;
        quest2.GetComponent<Button>().interactable = false;
        quest3.GetComponent<Button>().interactable = false;
        quest4.GetComponent<Button>().interactable = false;
    }  // inventoryscript.clearInv();

    public void OnTriggerStay(Collider other)
    {

        ////////// Quest 1: Talk to the carpenter and grab cups
        if(gameObject.name.Contains("TentCarpenter")){
            if(GameManager.instance.questOnePartOne){
             childText.color = completedColor;
             cups.AddComponent<BoxCollider>();
             cups2.AddComponent<BoxCollider>();
            }
            if(GameManager.instance.questOnePartTwo){
             childText2.color = completedColor;
            }
            if(GameManager.instance.questOne){
                FinishQuest();
            }
        }
       
        ////////// Quest 2: Talk to the farmer and grab fruit
        if(gameObject.name.Contains("TentFarmer") && GameManager.instance.questOne){
            if(GameManager.instance.TwoPartOne){
             childText.color = completedColor;
              apples.AddComponent<BoxCollider>();
              grapes.AddComponent<BoxCollider>();
            }
            if(GameManager.instance.questTwo){
                FinishQuest();
            }
            
        }

        ////////// Quest 3: Get cake and wine from bakery
        if(gameObject.name.Contains("TentBakery")&& GameManager.instance.questOne && GameManager.instance.questTwo){
        
            if(GameManager.instance.questThreePartOne){
             childText.color = completedColor;
             cake.AddComponent<BoxCollider>();
             wine.AddComponent<BoxCollider>();
            }
            if(GameManager.instance.questThree){
                FinishQuest();
            }
            
        }

       if(gameObject.name.Contains("Dog") && GameManager.instance.questOne && GameManager.instance.questTwo && GameManager.instance.questThree ){
            if(GameManager.instance.questFourPartOne){
             childText.color = completedColor;
             dogfood.AddComponent<BoxCollider>();
            }
            if(GameManager.instance.questFour){
                FinishQuest();
            }
        }



    }

   public void OnTriggerEnter(Collider other){

        if(gameObject.name.Equals("Carpenter")){
            GameManager.instance.touchDialogue = true;

            if(GameManager.instance.touchDialogue){
                dialoguescript.dialogue1();
            }
        }

        if(gameObject.name.Equals("farmerdad") && GameManager.instance.questOne){
            GameManager.instance.touchDialogue2 = true;

            if(GameManager.instance.touchDialogue2){
                dialoguescript.dialogue2();
            }
        }

        if(gameObject.name.Contains("TentBakery") && GameManager.instance.questOne && GameManager.instance.questTwo){
            GameManager.instance.touchDialogue3 = true;

            if(GameManager.instance.touchDialogue3){
                dialoguescript.dialogue3();
            }
        }    
    
     if(gameObject.name.Contains("Dog") && GameManager.instance.questOne && GameManager.instance.questTwo && GameManager.instance.questThree){
            GameManager.instance.touchDialogue4 = true;
    
            if(GameManager.instance.touchDialogue4){
                dialoguescript.dialogue4();
            }
        }
   }

  public void OnTriggerExit(){
     ////////// Quest 1: Talk to the carpenter and grab cups
        if(gameObject.name.Contains("TentCarpenter")){
            
            
            if(GameManager.instance.questOne){
                FinishQuest();
            }
        }

        if(gameObject.name.Contains("TentFarmer") && GameManager.instance.questOne){
            if(GameManager.instance.questTwo){
                FinishQuest();
            }  
        }
        if(gameObject.name.Contains("TentBakery") && GameManager.instance.questOne  && GameManager.instance.questTwo){
            if(GameManager.instance.questThree){
                FinishQuest();
            }  
        }
  }

   

    public void Update()
    {   

        //Set Arrow direction to this object
        if(!GameManager.instance.questOnePartOne){
            TargetArrow.target = carpenter.transform;
        }
        if(!GameManager.instance.questOnePartTwo && GameManager.instance.questOnePartOne){
            TargetArrow.target = cups.transform;;
        }

        if(!GameManager.instance.TwoPartOne && GameManager.instance.questOne){
            TargetArrow.target = farmer.transform;
        }
        if(!GameManager.instance.TwoPartTwo && GameManager.instance.TwoPartOne && GameManager.instance.questOne){
            TargetArrow.target = grapes.transform;
        }

        if(!GameManager.instance.questThreePartOne && GameManager.instance.questTwo && GameManager.instance.questOne){
            TargetArrow.target = bakery.transform;
        }
        if(!GameManager.instance.questThreePartTwo && GameManager.instance.questThreePartOne && GameManager.instance.questTwo && GameManager.instance.questOne){
            TargetArrow.target = cake.transform;
        }

        if(!GameManager.instance.questFour && GameManager.instance.questThree && GameManager.instance.questTwo && GameManager.instance.questOne){
            TargetArrow.target = dogfood.transform;
        }


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
