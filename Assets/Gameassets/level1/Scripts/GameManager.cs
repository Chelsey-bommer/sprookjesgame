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

    public TMP_Text Percentage1;
    public TMP_Text Percentage2;
    public TriggerDialogue dialoguescript;

    
    
    
    void Start()
    {
        instance = this;
        dialoguescript = GameObject.FindGameObjectWithTag("Dialoguetriggers").GetComponent<TriggerDialogue>();

        Percentage1.text = "1%";
        Percentage2.text = "1%";
        
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

        
    }
}
