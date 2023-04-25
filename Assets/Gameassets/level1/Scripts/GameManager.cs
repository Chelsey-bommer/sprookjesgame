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
    public bool questTwo1 = false;

    public bool questThree = false;

    public bool questThreePartOne = false;

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

        //Quest 2
        if(questTwo == true){
            Percentage2.text = "100%";
        }

        if(questTwo1 == true){
            Percentage2.text = "50%";
        }

        if(questThreePartOne){
            Percentage3.text = "20%";
        }
        // if( questThreePartOne && ){
        //     questThree = true;
        // }
    }
}
