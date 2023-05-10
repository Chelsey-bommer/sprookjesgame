using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogue : MonoBehaviour
{
    public GameObject DialogueBox1;
    public GameObject DialogueBox2;
    public GameObject DialogueBox3;
    public GameObject DialogueBox4;
    public GameObject DialogueBox5;
    public GameObject DialogueBox6;
    public GameObject DialogueBox7;
    public GameObject DialogueBox8;
    public GameObject DialogueBox9;




    public void Start()
    {
      
      DialogueBox1.SetActive(false);
      DialogueBox2.SetActive(false);
      DialogueBox3.SetActive(false);
      DialogueBox4.SetActive(false);
      DialogueBox5.SetActive(false);
      DialogueBox6.SetActive(false);
      DialogueBox7.SetActive(false);
      DialogueBox8.SetActive(false);
      DialogueBox9.SetActive(false);

    }

 

    public void dialogue1()
    {

        if (GameManager.instance.touchDialogue == true) //aanraking boolean
        {
            DialogueBox1.SetActive(true);
            GameManager.instance.dialogue1 = true; //active conversation boolean
        } 
    }

    public void dialogue2(){
        if (GameManager.instance.touchDialogue2 == true) //aanraking boolean
        {
            DialogueBox2.SetActive(true);
            GameManager.instance.dialogue2 = true; //active conversation boolean
        }
    }


    public void dialogue3(){
        if (GameManager.instance.touchDialogue3 == true) //aanraking boolean
        {
            DialogueBox3.SetActive(true);
            GameManager.instance.dialogue3 = true; //active conversation boolean
        }
     }

     public void dialogue4(){
         if (GameManager.instance.touchDialogue4 == true) //aanraking boolean
        {
            DialogueBox4.SetActive(true);
            GameManager.instance.dialogue4 = true; //active conversation boolean
        }
     }

      public void dialogue5(){
         if (GameManager.instance.touchDialogue5 == true) //aanraking boolean
        {
            DialogueBox5.SetActive(true);
            GameManager.instance.dialogue5 = true; //active conversation boolean
        }
     }

     public void dialogue6(){
         if (GameManager.instance.touchDialogue6 == true) //aanraking boolean
        {
            DialogueBox6.SetActive(true);
            GameManager.instance.dialogue6 = true; //active conversation boolean
        }
     }
      public void dialogue7(){
         if (GameManager.instance.touchDialogue7 == true) //aanraking boolean
        {
            DialogueBox7.SetActive(true);
            GameManager.instance.dialogue7 = true; //active conversation boolean
        }
     }

     public void dialogue8(){
        if(GameManager.instance.boardDialogue){
            
            DialogueBox8.SetActive(true);
        
        }
     }

      public void dialogue9(){
        if(GameManager.instance.touchDialogue9){
            
            DialogueBox9.SetActive(true);
        
        }
     }

}



