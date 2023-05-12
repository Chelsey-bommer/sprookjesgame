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
    public bool woodPickedup = false;
    public bool wood1Pickedup = false;
    public bool wood2Pickedup = false;
    public bool wood3Pickedup = false;
    public bool questThree = false;
    public bool questThreePartOne = false;
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

        if (questOne == true)
        {
            Percentage1.text = "100%";
        }

        ///////////////////////////////////////// Quest 2
        if (questTwoPartOne)
        {
            Percentage2.text = "25%";
        }
        if (woodPickedup)
        {
            questTwoPartTwo = true;
        }
        if (questTwoPartTwo)
        {
            Percentage2.text = "50%";
        }
        if (questTwoPartThree)
        {
            Percentage2.text = "75%";
        }
        if (questTwo)
        {
            Percentage2.text = "100%";
        }

        if (questTwoPartOne && questTwoPartTwo && questTwoPartThree && questTwoPartFour)
        {
            questTwo = true;
        }

        /////////////////////////////////////

        if (questThreePartOne)
        {
            Percentage3.text = "33%";
        }
        else if (questThreePartTwo)
        {
            Percentage3.text = "66%";
        }
        else if (questThreePartThree)
        {
            Percentage3.text = "100%";
        }

        if (questThreePartOne && questThreePartTwo && questThreePartThree)
        {
            questThree = true;
            Percentage3.text = "100%";
        }

        ////////////////////// 
        if (questFourPartOne == true)
        {
            Percentage4.text = "50%";

        }

        if (questFourPartTwo == true)
        {
            Percentage4.text = "100%";
        }

        if (questFourPartOne && questFourPartTwo)
        {
            questFour = true;
            Percentage4.text = "100%";
        }




        ////////////////////////////////// LEVEL 2
        ///Quest 1
        if (dialogue1)
        {
            questOnePartOne = true;
        }
        if (questOnePartOne)
        {
            Percentage1.text = "50%";
        }
        if (cupsPickedup)
        {
            questOnePartTwo = true;
        }
        if (questOnePartOne && questOnePartTwo)
        {
            questOne = true;
            Percentage1.text = "100%";
        }



        ///////////////////////////////////quest 2
        if (dialogue2 && questOne)
        {
            TwoPartOne = true;
        }
        if (TwoPartOne)
        {
            Percentage2.text = "50%";
        }
        if (applesPickedup && grapesPickedup){
            TwoPartTwo = true;
        }
        if (TwoPartOne && TwoPartTwo)
        {
            questTwo = true;
            Percentage2.text = "100%";
        }



        ////////////////////////////////quest 3
        if (dialogue3 && questTwo)
        {
            questThreePartOne = true;
        }
        if (questThreePartOne)
        {
            Percentage3.text = "50%";
        }
        if (cakesPickedup && winePickedup && questThreePartOne)
        {
            questThreePartTwo = true;
        }
        if(questThreePartOne && questThreePartTwo){
            questThree = true;
            Percentage3.text = "100%";
        }



        //////////////////////////////quest 4
        if (dialogue4 && questThree)
        {
            questFourPartOne = true;
        }

        if (questFourPartOne == true)
        {
            Percentage4.text = "50%";
        }
        if (dogPickedup && questFourPartOne)
        {
            questFour = true;
        }
        if (questFour == true)
        {
            Percentage4.text = "100%";
        }


        /////////////////////////////////////////////////////////////LEVEL 3
        //

        if(dialogue1){
            questOnePartOne = true;
        }


    }


    //////// Level 2 bools
    
    public bool dogTouch = false;
    public bool cupsPickedup = false;
    public bool applesPickedup = false;
    public bool grapesPickedup = false;
    public bool cakesPickedup = false;
    public bool winePickedup = false;
    public bool dogPickedup = false;
    public bool questOnePartOne = false;
    public bool questOnePartTwo = false;
    public bool questOnePartThree = false;
    public bool TwoPartOne = false;
    public bool TwoPartTwo = false;
    public bool TwoPartThree = false;
    public bool TwoPartFour = false;




}
