using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Quest : MonoBehaviour
{
    // Quest list color and percentage logic
    public Image questItem;
    public Color completedColor;
    public Color activeColor;

    public Color currentColor;

    public TMP_Text percentage;

    public Quest[] allQuests;

    private void Start(){
        allQuests = FindObjectsOfType<Quest>();  // all objects with quest script attached
        currentColor = questItem.color;
    }

    public void FinishQuest()
    {
        questItem.color = completedColor;
        currentColor = completedColor;
        questItem.GetComponent<Button>().interactable = false;  //set quest inactive when completed
    }

    public void OnQuestClick(){

        foreach(Quest quest in allQuests){
            quest.questItem.color = quest.currentColor;
        }
        questItem.color = activeColor;
    }
}
