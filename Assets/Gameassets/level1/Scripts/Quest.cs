using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Quest : MonoBehaviour
{

    public Image questItem;
    public Color completedColor;
    public Color activeColor;

   private void OnTriggerEnter(Collider other){

      // can add gamemanager logic (if bool is true, then complete quest)
      if(other.tag == "Player"){
        FinishQuest();
        Destroy(gameObject);
      }

   }
    void FinishQuest()
    {
        questItem.color = completedColor;
    }
}
