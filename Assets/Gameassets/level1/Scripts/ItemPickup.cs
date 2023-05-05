using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] public Item item;
  
    private void Pickup()
    {
        InventoryManager.Instance.Add(item);  // Add item to Item list
        Destroy(gameObject);  // Make object disappear
        GameManager.instance.pickedUp = true;
    }

    // Update is called once per fram
    private void OnMouseDown()
    {
        Pickup();
    }
}
