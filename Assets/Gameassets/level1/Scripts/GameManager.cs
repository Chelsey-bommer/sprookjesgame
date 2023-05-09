using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool questOne = false;
    public bool questTwo = false;
    public bool questTwoPartOne = false;
    public bool questTwoPartTwo = false;
    public bool questTwoPartThree = false;
    public bool questTwoPartFour = false;
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

        ///////////////////
        if(questFourPartOne == true){
            Percentage4.text = "50%";    
        }
        if(questFour == true){
            Percentage4.text = "100%";    
        }


        //////// Level 2

        if(cupsDropped){
            questOnePartTwo = true; 
        }
        if(ladderDropped){
            questOnePartOne = true; 
        }
        if(questOnePartOne){
            Percentage1.text = "50%";
        }
        if(questOnePartOne && questOnePartTwo){
            questOne = true;
            Percentage1.text = "100%";
        }

        //quest 2
        if(applesDropped){
            TwoPartOne = true; 
        }
        if(grapesDropped){
            TwoPartTwo = true; 
        }
        if(TwoPartOne){
            Percentage2.text = "50%";
        }
        if(TwoPartOne && TwoPartTwo){
            questTwo = true;
            Percentage1.text = "100%";
        }
        //////////quest 3
        // if(cakesPickedup){
        //     questThreePartOne = true;
        // }
        if(cakesDropped){
            questThree = true; 
        }
        //quest 4
        if(dogDropped){
            questFour = true; 
        }
    }


    //////// Level 2

    public bool ladderDropped = false;
    public bool cupsDropped = false;
    public bool applesDropped = false;
    public bool grapesDropped = false;
    public bool cakesDropped = false;
    public bool dogDropped = false;
    public bool questOnePartOne = false;
    public bool questOnePartTwo = false;
    
    public bool TwoPartOne = false;
    public bool TwoPartTwo = false;
    

  
}
