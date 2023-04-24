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
    public TriggerDialogue dialoguescript;

    private void Start()
    {
        allQuests = FindObjectsOfType<Quest>();  // all objects with quest script attached
        dialoguescript = GameObject.FindGameObjectWithTag("Dialoguetriggers").GetComponent<TriggerDialogue>();
        currentColor = questItem.color;
    }

    private void OnTriggerEnter(Collider other)
    {

        //Quest 1: test quest
        if (other.gameObject.name.Contains("Player"))
        {

            if (gameObject.name.Contains("Capsule"))
            {
                GameManager.instance.questOne = true;
                FinishQuest();
                Destroy(gameObject);
            }

        }

        if (other.gameObject.name.Contains("Player"))
        {
            if (dialoguescript.dialogue)
            {
                GameManager.instance.questTwo = true;
                FinishQuest();
            }

        }
    }

    public void FinishQuest()
    {
        questItem.color = completedColor;
        currentColor = completedColor;
        questItem.GetComponent<Button>().interactable = false;  //set quest inactive when completed
    }

    public void OnQuestClick()
    {

        foreach (Quest quest in allQuests)
        {
            quest.questItem.color = quest.currentColor;
        }
        questItem.color = activeColor;
    }
}
