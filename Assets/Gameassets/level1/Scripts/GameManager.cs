using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool questOne = false;

    public TMP_Text Percentage1;
    public TMP_Text Percentage2;
    
    
    void Start()
    {
        instance = this;

        Percentage1.text = "1%";
        Percentage2.text = "1%";
        
    }

    
    void Update()
    {
        //logic for quests

        if(questOne == true){
            Percentage1.text = "100%";
        }
    }
}
