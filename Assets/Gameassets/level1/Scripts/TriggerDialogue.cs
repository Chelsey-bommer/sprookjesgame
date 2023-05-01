using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogue : MonoBehaviour
{
    public GameObject DialogueBox;
    private Collider getCollider;

    public bool dialogue = false;
    public bool dialogue1 = false;

    public void Start()
    {
        DialogueBox.SetActive(false);
       // dialogue = true;
        
    }
 
    public void dialogueThing()
    {
        
        if(dialogue == true){
           DialogueBox.SetActive(true);
           
        } 
    }


}
