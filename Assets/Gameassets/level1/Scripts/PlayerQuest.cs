using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerQuest : MonoBehaviour
{
    //All quests?
    public Quest script;

   
    void Start()
    {
       script = GameObject.FindGameObjectWithTag("Collectible1").GetComponent<Quest>();  //get quest logic
    }

   
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other){

        //Quest 1: test quest
      if(other.gameObject.tag.Contains("Collectible1")){
         GameManager.instance.questOne = true;
         script.FinishQuest();
         Destroy(other.gameObject); 
      }
    }

    // quest 2 talk to a friend
}
