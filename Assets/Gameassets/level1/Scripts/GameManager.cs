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
    public bool questThreePartTwo = false;
    public bool questThreePartThree = false;

    public TMP_Text Percentage1;
    public TMP_Text Percentage2;
    public TMP_Text Percentage3;
    public TriggerDialogue dialoguescript;

    
    
    
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

        // Quest 2
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

        if(questThreePartOne == true){
            Percentage3.text = "33%";
        }

        if(questThreePartTwo == true){
            Percentage3.text = "66%";
        }

        if(questThreePartOne && questThreePartTwo && questThreePartThree){
            questThree = true;
        }
    }
}
