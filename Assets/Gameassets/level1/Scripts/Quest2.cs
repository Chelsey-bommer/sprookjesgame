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
    private GameObject mand;
    private GameObject apples;
    private GameObject grapes;
    private GameObject cake;
    private GameObject dogfood;

    void Start()
    {
        allQuests = FindObjectsOfType<Quest2>();  // all objects with quest script attached
        dialoguescript = scriptObject.GetComponent<TriggerDialogue2>();
        itemscript = scriptObject2.GetComponent<ItemPickup>();
        inventoryscript = scriptObject.GetComponent<InventoryManager>();
        
        currentColor = questItem.color;

        cups = GameObject.Find("Cups");
        mand = GameObject.Find("Mand");
        apples = GameObject.Find("Apples");
        grapes = GameObject.Find("Grapes");
        cake = GameObject.Find("Cake");
        dogfood = GameObject.Find("Dogfood");


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

        ////////// Quest 1: Grab a pair of cups
        if(gameObject.name.Contains("TentCarpenter")){
            if(GameManager.instance.questOnePartOne){
             childText.color = completedColor;
            }
            if(GameManager.instance.questOnePartTwo){
             childText2.color = completedColor;
            }
            if(GameManager.instance.questOne){
                FinishQuest();
            }
        }
       
        
        if(gameObject.name.Contains("TentFarmer")){
            if(GameManager.instance.TwoPartOne){
             childText.color = completedColor;
            }
            if(GameManager.instance.questTwo){
                FinishQuest();
            }
            
        }
    //     // Task 2: grab cups -- //zie gamemanager r.135
    //     // Task 3: put cups in basket -- zie inventory item controller
    //     if(gameObject.name.Contains("Mand") && GameManager.instance.questOnePartTwo){
    //         GameManager.instance.mandTouch = true;

    //         if(GameManager.instance.mandTouch){
    //             inventoryscript.clearInv();/// not working
    //         }

    //         if(GameManager.instance.questOne){
    //             FinishQuest();
    //         }
    //     }
    //      if(gameObject.name.Equals("empty1") && GameManager.instance.TwoPartTwo && !GameManager.instance.questThree && !GameManager.instance.questTwo){
    //         GameManager.instance.mandTouch2 = true;
    //         GameManager.instance.touchDialogue2 = true;

    //         if(GameManager.instance.touchDialogue2){
    //             dialoguescript.dialogue2();
    //         }
    
            
    //         if(GameManager.instance.questTwo){
    //             FinishQuest();
    //         }
            
    //     }

    //    if(gameObject.name.Contains("Dog")){
    //         GameManager.instance.dogTouch = true;

    //         if(GameManager.instance.questTwo){
    //             FinishQuest();
    //         }
    //     }

    //     if(gameObject.name.Equals("colliderobject")){
    //         GameManager.instance.colliderTouch = true;

    //         if(GameManager.instance.questThree){
    //             FinishQuest();
    //         }
    //     }

    //     if(gameObject.name.Equals("colliderobject2")){
    //         GameManager.instance.collider2Touch = true;

    //         if(GameManager.instance.questFour){
    //             FinishQuest();
    //         }
    //     } 

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

   public void OnTriggerEnter(Collider other){

        if(gameObject.name.Equals("Carpenter")){
            GameManager.instance.touchDialogue = true;

            if(GameManager.instance.touchDialogue){
                dialoguescript.dialogue1();
            }
        }

        if(gameObject.name.Equals("farmerdad")){
            GameManager.instance.touchDialogue2 = true;

            if(GameManager.instance.touchDialogue2){
                dialoguescript.dialogue2();
            }
        }
    
    //  if(gameObject.name.Contains("Mand") && GameManager.instance.questOnePartTwo && !GameManager.instance.questTwo){
    //         GameManager.instance.mandTouch = true;
    //         GameManager.instance.touchDialogue = true;
    
    //         if(GameManager.instance.mandTouch){
    //             inventoryscript.clearInv(); //not working correctly
    //         }
    //         if(GameManager.instance.touchDialogue && !GameManager.instance.questOnePartThree){
    //             dialoguescript.dialogue1();
    //         }
    //     }

    //     if(gameObject.name.Equals("empty1") && GameManager.instance.TwoPartTwo && !GameManager.instance.questThree && GameManager.instance.questTwo){
    //         GameManager.instance.mandTouch2 = true;
    //         GameManager.instance.touchDialogue2 = true;
    
    //         if(GameManager.instance.mandTouch2){
    //             inventoryscript.clearInv(); //not working correctly
    //         }
            
            
    //     }
   }

   public void OnTriggerExit(Collider other){
        // if(gameObject.name.Contains("TentCarpenter")){
        //     if(GameManager.instance.questOnePartOne){
        //      childText.color = completedColor;
        //     }
        //     if(GameManager.instance.questOnePartTwo){
        //      childText2.color = completedColor;
        //     }
        // }
   }

   

    public void Update()
    {   

        //Set Arrow direction to this object
        if(!GameManager.instance.questOnePartOne && !GameManager.instance.questOnePartTwo){
            TargetArrow.target = cups.transform;
        }
        if(!GameManager.instance.questOnePartThree && GameManager.instance.questOnePartOne && GameManager.instance.questOnePartTwo){
            TargetArrow.target = mand.transform;
        }

        if(!GameManager.instance.TwoPartOne && GameManager.instance.questOne){
            TargetArrow.target = apples.transform;
        }
        if(!GameManager.instance.TwoPartTwo && GameManager.instance.TwoPartOne && GameManager.instance.questOne){
            TargetArrow.target = grapes.transform;
        }
        if(!GameManager.instance.TwoPartThree && !GameManager.instance.TwoPartFour && GameManager.instance.TwoPartTwo && GameManager.instance.TwoPartOne){
            TargetArrow.target = mand.transform;
        }

        if(!GameManager.instance.questThree && GameManager.instance.questTwo && GameManager.instance.questOne){
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
