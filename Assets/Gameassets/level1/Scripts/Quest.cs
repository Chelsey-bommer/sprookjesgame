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
    //public TriggerDialogue dialoguescript;

    private TriggerDialogue dialoguescript;

    public GameObject child;

    public TMP_Text childText;
    public TMP_Text childText2;
    private bool activeQuest = false;

    private GameObject findWood;
    void Start()
    {
        allQuests = FindObjectsOfType<Quest>();  // all objects with quest script attached
        dialoguescript = GetComponent<TriggerDialogue>();
        currentColor = questItem.color;
        //child = transform.Find("list").gameObject;

        findWood = GameObject.FindGameObjectWithTag("Wood");
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
        //////////// Quest 2: Talk to this guy
        if (other.gameObject.name.Contains("Player"))
        {
            if (dialoguescript.dialogue)
            {
                GameManager.instance.questTwo = true;
                FinishQuest();
            }
        }

       //////////////////Quest 3:
      // Part one: Locate hole
      if(gameObject.name.Contains("Hole")){
          GameManager.instance.questThreePartOne = true;
          childText.color = Color.magenta;
          Debug.Log("Looked at hole");
       }
      //Part two: Collect wood
        if(gameObject.name.Contains("wood") && GameManager.instance.questThreePartOne) {
            gameObject.SetActive(false);

            if(findWood.activeInHierarchy == false){ //if all the wood is collected
                GameManager.instance.questThreePartTwo = true;
                childText.color = Color.magenta;
            }
        }
      



    }

    public void FinishTask(){
      childText.text = "<color=green>Done</color>";
      childText.color = Color.green;

      //works!!
    }

    public void FinishQuest()
    {
        //FinishTask();
        questItem.color = completedColor;
        currentColor = completedColor;
        questItem.GetComponent<Button>().interactable = false;  //set quest inactive when completed
        child.SetActive(false); 
    }

    public void OnQuestClick()
    {
       
        foreach (Quest quest in allQuests)
        {

            quest.questItem.color = quest.currentColor;
        }
        questItem.color = activeColor;


        if (child.activeInHierarchy)
        {
            child.SetActive(false);
        } 
        else
        {
            child.SetActive(true);
        } 
        
    }


}
