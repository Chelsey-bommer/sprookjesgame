using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogue : MonoBehaviour
{
    public GameObject DialogueBox1;
    public GameObject DialogueBox2;
    public GameObject DialogueBox3;
    public GameObject DialogueBox4;




    public void Start()
    {
      DialogueBox1.SetActive(false);
      DialogueBox2.SetActive(false);
      DialogueBox3.SetActive(false);
      DialogueBox4.SetActive(false);

    }

 

    public void cheese()
    {

        if (GameManager.instance.touchDialogue == true) //aanraking boolean
        {
            DialogueBox1.SetActive(true);
            GameManager.instance.dialogue1 = true; //active conversation boolean
        }

        if (GameManager.instance.touchDialogue2 == true) //aanraking boolean
        {
            DialogueBox2.SetActive(true);
            GameManager.instance.dialogue2 = true; //active conversation boolean
        }

        if (GameManager.instance.touchDialogue3 == true) //aanraking boolean
        {
            DialogueBox2.SetActive(true);
            GameManager.instance.dialogue3 = true; //active conversation boolean
        }

        if (GameManager.instance.touchDialogue4 == true) //aanraking boolean
        {
            DialogueBox2.SetActive(true);
            GameManager.instance.dialogue4 = true; //active conversation boolean
        }

      //   if (GameManager.instance.dialogue2 == true)
      //   {
      //       DialogueBox.SetActive(true);
      //   }

      //   if (GameManager.instance.dialogue3 == true)
      //   {
      //       DialogueBox.SetActive(true);
      //   }

    }


}
