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
    public Quest3[] allQuests;
    private TriggerDialogue3 dialoguescript;
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
    private GameObject paw1;
    private GameObject paw2;
    private GameObject paw3;
    private GameObject paw4;
    private GameObject paw5;
    private GameObject paw6;
    private GameObject paw7;
    private GameObject paw8;


    void Start()
    {
        allQuests = FindObjectsOfType<Quest3>();  // all objects with quest script attached
        dialoguescript = scriptObject.GetComponent<TriggerDialogue3>();
        itemscript = scriptObject2.GetComponent<ItemPickup>();
        inventoryscript = scriptObject.GetComponent<InventoryManager>();
        
        currentColor = questItem.color;

        paw1 = GameObject.Find("pawprints");
        paw2 = GameObject.Find("pawprints2");
        paw3 = GameObject.Find("pawprints3");
        paw4 = GameObject.Find("pawprints4");
        paw5 = GameObject.Find("pawprints5");
        paw6 = GameObject.Find("pawprints6");
        paw7 = GameObject.Find("pawprints7");
        paw8 = GameObject.Find("pawprints8");


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
        if(gameObject.name.Equals("pawprints")){
            
            if(GameManager.instance.questOnePartOne){
                childText.color = completedColor;
            }
        }
       


    }

   public void OnTriggerEnter(Collider other){

        if(gameObject.name.Equals("pawprints")){
            GameManager.instance.touchDialogue = true;
            
            if(GameManager.instance.touchDialogue){
                dialoguescript.dialogue1();
            }
        }
        if(gameObject.name.Equals("pawprints2")){
            
        }
        if(gameObject.name.Equals("pawprints2")){
            
        }
        if(gameObject.name.Equals("pawprints2")){
            
        }
       
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
