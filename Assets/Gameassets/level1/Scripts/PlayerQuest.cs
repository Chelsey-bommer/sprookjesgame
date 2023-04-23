using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerQuest : MonoBehaviour
{
    public Quest script;

    private Color completedColor;
    private Color activeColor;

    private Color currentColor;

   
    void Start()
    {
       script = GameObject.FindGameObjectWithTag("Collectible1").GetComponent<Quest>();
    }

   
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other){

        //Quest One
      if(other.gameObject.tag.Contains("Collectible1")){
         GameManager.instance.questOne = true;
         script.FinishQuest();
         Destroy(other.gameObject); 
         
      }
    }
}
