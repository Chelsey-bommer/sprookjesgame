using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogue3 : MonoBehaviour
{
    public GameObject DialogueBox1;
   

    public bool dialogue;


    public void Start()
    {
      DialogueBox1.SetActive(false);
      dialogue = false;

    }

 

    public void dialogue1()
    {

        if (GameManager.instance.touchDialogue == true) //aanraking boolean
        {
            DialogueBox1.SetActive(true);
            GameManager.instance.dialogue1 = true; //active conversation boolean
        } 
    }

}



