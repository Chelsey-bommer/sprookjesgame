using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerQuest : MonoBehaviour
{
    //All quests?
    // public Quest script;
    // public TriggerDialogue dialoguescript;

   
    void Start()
    {
      //script = GameObject.FindGameObjectWithTag("Collectible1").GetComponent<Quest>();  //get quest logic
       
       //dialoguescript = GameObject.FindGameObjectWithTag("Dialoguetriggers").GetComponent<TriggerDialogue>();
    }

   
    void Update()
    {
        
    }

    // private void OnTriggerEnter(Collider other){

    //     //Quest 1: test quest
    //   if(other.gameObject.name.Contains("Capsule")){
    //      GameManager.instance.questOne = true;
    //      script.FinishQuest();
    //      Destroy(other.gameObject); 
    //   }

    //   if(other.gameObject.name.Contains("WoundedFriend")){
    //      GameManager.instance.questTwo = true;
    //      script.FinishQuest();
    //   }
    // }

    // private void questThing(){
    //    if(dialoguescript.dialogue1){  //when dialogue is triggered
    //      GameManager.instance.Percentage2.text = "50%";
    //    }

    //    if(dialoguescript.dialogue){
    //      GameManager.instance.Percentage2.text = "100%";
    //      script.FinishQuest(); // deze line gaat fout
    //    }
    // }

    // quest 2 talk to a friend
}
