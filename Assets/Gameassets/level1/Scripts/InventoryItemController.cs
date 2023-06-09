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
    public GameObject myPrefabApples;
    public GameObject myPrefabGrapes;
    public GameObject myPrefabCakes;
    public GameObject myPrefabDog;
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
        // if(item.name == "ToDoList"){
        //     Instantiate(myPrefabList, playerPos.position + playerPos.forward * dropOffset, Quaternion.identity);
        // }
        if(item.name == "Arrows"){
            Instantiate(myPrefabArrows, playerPos.position + playerPos.forward * dropOffset, Quaternion.identity);
            // change position
            GameManager.instance.arrowsDropped = true;
        }

        // if(item.name == "Cups" &&  GameManager.instance.mandTouch){
        //     Instantiate(myPrefabCups, new Vector3(335, -105, 700), Quaternion.identity);
        //     GameManager.instance.cupsDropped = true;
        // }

        // if(item.name == "Apples" && GameManager.instance.dogTouch){
        //     Instantiate(myPrefabApples, new Vector3(355, -105, 700), Quaternion.identity);
        //     GameManager.instance.applesDropped = true;
        // }
        // if(item.name == "Grapes" && GameManager.instance.dogTouch){
        //     Instantiate(myPrefabApples, new Vector3(365, -105, 700), Quaternion.identity);
        //     GameManager.instance.grapesDropped = true;
        // }
        // if(item.name == "Cake" && GameManager.instance.colliderTouch){
        //     Instantiate(myPrefabCakes, new Vector3(335, -105, 700), Quaternion.identity);
        //     GameManager.instance.cakesDropped = true;
        // }
        // if(item.name == "Dogfood"){
        //     Instantiate(myPrefabDog, new Vector3(335, -105, 700), Quaternion.identity);
        //     GameManager.instance.dogDropped = true;
        // }
        // Destroy(gameObject);

        
        //Instantiate(myPrefab, playerPos.position + playerPos.forward * dropOffset, Quaternion.identity);
    }

    public void AddItem(Item newItem){
        item = newItem;
    }
}
