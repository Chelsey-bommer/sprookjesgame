using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] public Item item;
  
    public void Pickup()
    {
        InventoryManager.Instance.Add(item);  // Add item to Item list

        if(gameObject.name.Equals("Cake")){
            GameManager.instance.cakesPickedup = true;
        }
        
        Destroy(gameObject);  // Make object disappear

    }

    // Update is called once per fram
    private void OnMouseDown()
    {
        Pickup();
    }
}
