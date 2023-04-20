using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemController : MonoBehaviour
{
    Item item;
    public Button RemoveButton;
    public GameObject myPrefab;

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
        Destroy(gameObject);
        Instantiate(myPrefab, playerPos.position + playerPos.forward * dropOffset, Quaternion.identity);
    }

    public void AddItem(Item newItem){
        item = newItem;
    }
}
