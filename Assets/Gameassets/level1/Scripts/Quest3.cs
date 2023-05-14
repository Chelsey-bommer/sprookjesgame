using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using TMPro;
using UnityEngine.SceneManagement;


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
    public TMP_Text childText5;
    public TMP_Text childText6;
    public TMP_Text childText7;
    public TMP_Text childText8;
    public Image quest1;
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
    }  

    public void OnTriggerStay(Collider other)
    {
        if(gameObject.name.Equals("pawprints")){
            
            if(GameManager.instance.questOnePartOne){
                childText.color = completedColor;
            }
        }
        if(gameObject.name.Equals("pawprints2")){
            
            if(GameManager.instance.questOnePartTwo){
                childText2.color = completedColor;
            }
        }
        if(gameObject.name.Equals("pawprints3")){
            
            if(GameManager.instance.questOnePartThree){
                childText3.color = completedColor;
            }
        }
        if(gameObject.name.Equals("pawprints4")){
            
            if(GameManager.instance.questOnePartFour){
                childText4.color = completedColor;
            }
        }
        if(gameObject.name.Equals("pawprints5")){
            
            if(GameManager.instance.questOnePartFive){
                childText5.color = completedColor;
            }
        }
        if(gameObject.name.Equals("pawprints6")){
            
            if(GameManager.instance.questOnePartSix){
                childText6.color = completedColor;
            }
        }
        if(gameObject.name.Equals("pawprints7")){
            
            if(GameManager.instance.questOnePartSeven){
                childText7.color = completedColor;
            }
        }
        if(gameObject.name.Equals("pawprints8")){
            
            if(GameManager.instance.questOnePartEight){
                childText7.color = completedColor;
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
            GameManager.instance.pawTouch1 = true;
        }
        if(gameObject.name.Equals("pawprints3")){
            GameManager.instance.pawTouch2 = true;
        }
        if(gameObject.name.Equals("pawprints4")){
            GameManager.instance.pawTouch3 = true;
        }
        if(gameObject.name.Equals("pawprints5")){
            GameManager.instance.pawTouch4 = true;
        }
        if(gameObject.name.Equals("pawprints6")){
            GameManager.instance.pawTouch5 = true;
        }
        if(gameObject.name.Equals("pawprints7")){
            GameManager.instance.pawTouch6 = true;
        }
        if(gameObject.name.Equals("pawprints8")){
            GameManager.instance.pawTouch7 = true;
        }
       
   }

  

    public void Update()
    {   

        //Set Arrow direction to this object
        if(!GameManager.instance.questOnePartOne){
           TargetArrow.target = paw1.transform;
        }
        if(!GameManager.instance.questOnePartTwo && GameManager.instance.questOnePartOne){
           TargetArrow.target = paw2.transform;
        }
        if(!GameManager.instance.questOnePartThree && GameManager.instance.questOnePartTwo && GameManager.instance.questOnePartOne){
           TargetArrow.target = paw3.transform;
        }
        if(!GameManager.instance.questOnePartFour && GameManager.instance.questOnePartThree && GameManager.instance.questOnePartTwo && GameManager.instance.questOnePartOne){
           TargetArrow.target = paw4.transform;
        }
        if(!GameManager.instance.questOnePartFive && GameManager.instance.questOnePartFour && GameManager.instance.questOnePartThree && GameManager.instance.questOnePartTwo && GameManager.instance.questOnePartOne){
           TargetArrow.target = paw5.transform;
        }
        if(!GameManager.instance.questOnePartSix && GameManager.instance.questOnePartFive && GameManager.instance.questOnePartFour && GameManager.instance.questOnePartThree && GameManager.instance.questOnePartTwo && GameManager.instance.questOnePartOne){
           TargetArrow.target = paw6.transform;
        }
        if(!GameManager.instance.questOnePartSeven && GameManager.instance.questOnePartSix && GameManager.instance.questOnePartFive && GameManager.instance.questOnePartFour && GameManager.instance.questOnePartThree && GameManager.instance.questOnePartTwo && GameManager.instance.questOnePartOne){
           TargetArrow.target = paw7.transform;
        }
        if(!GameManager.instance.questOnePartEight && GameManager.instance.questOnePartSeven && GameManager.instance.questOnePartSix && GameManager.instance.questOnePartFive && GameManager.instance.questOnePartFour && GameManager.instance.questOnePartThree && GameManager.instance.questOnePartTwo && GameManager.instance.questOnePartOne){
           TargetArrow.target = paw8.transform;
        }

        if(GameManager.instance.questOne){
            Invoke("CompleteLevel", 1f);
        }
    }

    private void CompleteLevel(){
        if(GameManager.instance.questOne){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    

   public void FinishQuest()
    {

        if(GameManager.instance.questOne){
            quest1.color = completedColor;
            quest1.GetComponent<Button>().interactable = false;
            
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
