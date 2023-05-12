using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using TMPro;

public class Quest3 : MonoBehaviour
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
    // private GameObject cups;
    // private GameObject mand;
    // private GameObject apples;
    // private GameObject grapes;
    // private GameObject cake;
    // private GameObject dogfood;
    // private GameObject carpenter;
    // private GameObject farmer;
    // private GameObject bakery;

    void Start()
    {
        allQuests = FindObjectsOfType<Quest2>();  // all objects with quest script attached
        dialoguescript = scriptObject.GetComponent<TriggerDialogue2>();
        itemscript = scriptObject2.GetComponent<ItemPickup>();
        inventoryscript = scriptObject.GetComponent<InventoryManager>();
        
        currentColor = questItem.color;

        // cups = GameObject.Find("Cups");
        // mand = GameObject.Find("Mand");
        // apples = GameObject.Find("Apples");
        // grapes = GameObject.Find("Grapes");
        // cake = GameObject.Find("Cake");
        // dogfood = GameObject.Find("Dogfood");
        // carpenter = GameObject.Find("Carpenter");
        // farmer = GameObject.Find("farmerdad");
        // bakery = GameObject.Find("TentBakery");


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

       


    }

   public void OnTriggerEnter(Collider other){

       
   }

  

   

    public void Update()
    {   

        //Set Arrow direction to this object
        if(!GameManager.instance.questOnePartOne){
           // TargetArrow.target = carpenter.transform;
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
