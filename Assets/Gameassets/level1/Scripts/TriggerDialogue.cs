using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogue : MonoBehaviour
{
    public GameObject DialogueBox;
    private Collider2D getCollider;

    public bool dialogue = false;
    public bool dialogue1 = false;

    private void Start()
    {
        DialogueBox.SetActive(false);
        
        
    }
 
    private void OnTriggerEnter(Collider collision)
    {
        
        
        if(dialogue == false){
           DialogueBox.SetActive(true);
           dialogue = true;
        }
 
    }

    // void OnTriggerExit(Collider other){
    //     dialogue = true;
    // }
}
