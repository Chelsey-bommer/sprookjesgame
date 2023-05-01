using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogue : MonoBehaviour
{
    public GameObject DialogueBox;
    private Collider2D getCollider;

    public bool dialogue = false;
    public bool dialogue1 = false;

    public void Start()
    {
        DialogueBox.SetActive(false);
        
        
    }
 
    public void OnTriggerStay(Collider collision)
    {
        
        if(dialogue == false){
           DialogueBox.SetActive(true);
           dialogue = true;
        }
 
    }


}
