using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerQuest : MonoBehaviour
{
    
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other){

        //Quest One
      if(other.gameObject.tag.Contains("Collectible1")){
         GameManager.instance.questOne = true;
         Destroy(other.gameObject); 
      }
    }
}
