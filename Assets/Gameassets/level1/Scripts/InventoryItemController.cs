using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemController : MonoBehaviour
{
    Item item;
    public Button RemoveButton;
    public GameObject myPrefabList;
    public GameObject myPrefabArrows;
    public GameObject myPrefabCups;
    public GameObject myPrefabLadder;

    

    private Transform playerPos;
    private float dropOffset = 1f;
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    public void RemoveItem()
    {
        InventoryManager.Instance.Remove(item);
        if(item.name == "ToDoList"){
            Instantiate(myPrefabList, playerPos.position + playerPos.forward * dropOffset, Quaternion.identity);
        }
        if(item.name == "Arrows"){
            Instantiate(myPrefabArrows, playerPos.position + playerPos.forward * dropOffset, Quaternion.identity);
            // change position
            GameManager.instance.arrowsDropped = true;
        }


        if(item.name == "Ladder"){
            Instantiate(myPrefabLadder, new Vector3(346, -105, 700), Quaternion.identity);
            // change position
            
        }

        if(item.name == "Cups"){
            Instantiate(myPrefabCups, new Vector3(335, -105, 700), Quaternion.identity);
            // change position
            
        }
        Destroy(gameObject);

        
        //Instantiate(myPrefab, playerPos.position + playerPos.forward * dropOffset, Quaternion.identity);
    }

    public void AddItem(Item newItem){
        item = newItem;
    }
}
