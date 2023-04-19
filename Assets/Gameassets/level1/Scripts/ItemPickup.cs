using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] public Item item;
    void Pickup()
    {
        InventoryManager.Instance.Add(item);  // Add item to Item list
        Destroy(gameObject);  // Make object disappear
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        Pickup();
    }
}
