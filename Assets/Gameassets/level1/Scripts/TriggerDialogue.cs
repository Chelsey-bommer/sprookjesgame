using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogue : MonoBehaviour
{
    public GameObject DialogueBox;
    private Collider2D getCollider;

    private bool dialogue = false;

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
}
