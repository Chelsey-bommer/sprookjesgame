using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool boardDialogue = false;
    public bool aQuest = false;
    public bool questOne = false;
    public bool questTwo = false;
    public bool questTwoPartOne = false;
    public bool questTwoPartTwo = false;
    public bool questTwoPartThree = false;
    public bool questTwoPartFour = false;
    public bool woodPickedup = false;
    public bool wood1Pickedup = false;
    public bool wood2Pickedup = false;
    public bool wood3Pickedup = false;
    public bool questThree = false;
    public bool questThreePartOne = false;
    public bool contact = false;
    public bool questThreePartTwo = false;
    public bool questThreePartThree = false;
    public bool questFour = false;
    public bool questFourPartOne = false;
    public bool questFourPartTwo = false;
    public bool arrowsDropped = false;

    public TMP_Text Percentage1;
    public TMP_Text Percentage2;
    public TMP_Text Percentage3;
    public TMP_Text Percentage4;
    private TriggerDialogue dialoguescript;
    public GameObject scriptObject;

    public bool dialogue1 = false;
    public bool dialogue2 = false;
    public bool dialogue3 = false;
    public bool dialogue4 = false;
    public bool dialogue5 = false;
    public bool dialogue6 = false;
    public bool dialogue7 = false;
    public bool touchDialogue = false;
    public bool touchDialogue2 = false;
    public bool touchDialogue3 = false;
    public bool touchDialogue4 = false;
    public bool touchDialogue5 = false;
    public bool touchDialogue6 = false;
    public bool touchDialogue7 = false;
    public bool touchDialogue9 = false;
    public bool touchDialogue10 = false;


    
    
    
    void Start()
    {
        instance = this;
        dialoguescript = GameObject.FindGameObjectWithTag("Dialoguetriggers").GetComponent<TriggerDialogue>();

        Percentage1.text = "0%";
        Percentage2.text = "0%";
    }

   
    void Update()
    {
        //logic for quests

        if(questOne == true){
            Percentage1.text = "100%";
        }

        ///////////////////////////////////////// Quest 2
        if(questTwoPartOne){
            Percentage2.text = "25%";
        }
        if(woodPickedup){
            questTwoPartTwo = true;
        }
        if(questTwoPartTwo){
            Percentage2.text = "50%";
        }
        if(questTwoPartThree){
            Percentage2.text = "75%";
        }
        if(questTwo){
            Percentage2.text = "100%";
        }

        if(questTwoPartOne && questTwoPartTwo && questTwoPartThree && questTwoPartFour){
            questTwo = true;
        }

        /////////////////////////////////////

        if(questThreePartOne == true){
            Percentage3.text = "33%";  
            
        }

        if(questThreePartTwo == true){
            Percentage3.text = "66%";
        }

        if(questThreePartOne && questThreePartTwo && questThreePartThree){
            questThree = true;
            Percentage3.text = "100%";
        }

        ////////////////////// 
        if(questFourPartOne == true){
            Percentage3.text = "50%";  
            
        }

        if(questFourPartTwo == true){
            Percentage3.text = "100%";
        }

        if(questFourPartOne && questFourPartTwo){
            questFour = true;
            Percentage3.text = "100%";
        }

        


        ////////////////////////////////// LEVEL 2
        ///Quest 1
        if(barrelDestroyed){
            questOnePartOne = true; 
        }
        if(questOnePartOne){
            Percentage1.text = "33%";
        }
        if(cupsPickedup ){
            questOnePartTwo = true; 
        }
        if(questOnePartTwo ){
            Percentage1.text = "66%";
        }
        if(cupsDropped && questOnePartTwo){
            questOnePartThree = true;
        }
        
        if(questOnePartOne && questOnePartTwo && questOnePartThree){
            questOne = true;
            Percentage1.text = "100%";
        }



        ///////////////////////////////////quest 2
        if(applesPickedup && grapesPickedup && questOne){
            TwoPartOne = true;
            TwoPartTwo = true; 
        }
        if(TwoPartTwo){
            Percentage2.text = "50%";
        }
        if(applesDropped){
            TwoPartThree = true; 
        }
        if(TwoPartThree){
            Percentage2.text = "75%";
        }
        if(grapesDropped){
            TwoPartFour = true; 
        }
        
        if(TwoPartOne && TwoPartTwo && TwoPartThree && TwoPartFour){
            questTwo = true;
            Percentage2.text = "100%";
        }



        ////////////////////////////////quest 3
        if(cakesPickedup && questTwo){
            questThreePartOne = true;
        }
        if(questThreePartOne){
            Percentage3.text = "50%";
        }
        if(cakesDropped && questThreePartOne){
            questThree = true; 
            Percentage3.text = "100%";
        }



        //////////////////////////////quest 4
        if(dogPickedup && questThree){
            questFourPartOne = true;
        }
        
        if(questFourPartOne == true){
            Percentage4.text = "50%";    
        }
        if(dogDropped && questFourPartOne){
            questFour = true; 
        }
        if(questFour == true){
            Percentage4.text = "100%";    
        }

        //////////////////

        // if(!colliderTouch && !collider2Touch && !mandTouch){
        //     Debug.Log("not touching");
        // }
        
    }
    

    //////// Level 2
    public bool barrelDestroyed = false;
    public bool mandTouch = false;
    public bool dogTouch = false;
    public bool colliderTouch = false;
    public bool collider2Touch = false;
    public bool cupsDropped = false;
    public bool cupsPickedup = false;
    public bool applesDropped = false;
    public bool applesPickedup = false;
    public bool grapesDropped = false;
    public bool grapesPickedup = false;
    public bool cakesDropped = false;
    public bool cakesPickedup = false;
    public bool dogDropped = false;
    public bool dogPickedup = false;
    public bool questOnePartOne = false;
    public bool questOnePartTwo = false;
    public bool questOnePartThree = false;
    public bool TwoPartOne = false;
    public bool TwoPartTwo = false;
    public bool TwoPartThree = false;
    public bool TwoPartFour = false;
    

  
}
