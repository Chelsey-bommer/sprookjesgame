using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogue : MonoBehaviour
{
    public GameObject DialogueBox;




    public void Start()
    {
     DialogueBox.SetActive(false);
        
    }
 
    public void OnTriggerEnter(Collider collision)
    {
        
        if(GameManager.instance.dialogue == true){
           DialogueBox.SetActive(true);
        }

        if(GameManager.instance.dialogue2 == true){
           DialogueBox.SetActive(true);
        }

        if(GameManager.instance.dialogue3 == true){
           DialogueBox.SetActive(true);
        }
 
    }


}
