using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] public Item item;
    void Pickup()
    {
        InventoryManager.Instance.Add(item);
        Destroy(gameObject);
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        Pickup();
    }
}
