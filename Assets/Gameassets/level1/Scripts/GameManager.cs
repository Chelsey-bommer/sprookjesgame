using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool questOne = false;

    public TMP_Text percentage1;
    
    
    void Start()
    {
        instance = this;

        percentage1.text = "100%";
        
    }

    
    void Update()
    {
        //logic for quests
    }
}
