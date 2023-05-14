using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] public Item item;
    public AudioClip pickupAudio;// Sound clip to play when picking up the item

  
    public void Pickup()
    {
        InventoryManager.Instance.Add(item);  // Add item to Item list
        Destroy(gameObject);  // Make object disappear

         AudioManager.Instance.PlaySound(pickupAudio);

        if(item.name.Equals("Cups")){
           GameManager.instance.cupsPickedup = true;
        }
        if(item.name.Equals("Apples")){
           GameManager.instance.applesPickedup = true;
        }
        if(item.name.Equals("Grapes")){
           GameManager.instance.grapesPickedup = true;
        }
        if(item.name.Equals("Cake")){
           GameManager.instance.cakesPickedup = true;
        }
        if(item.name.Equals("Wine")){
           GameManager.instance.winePickedup = true;
        }
         if(item.name.Equals("Dogfood")){
           GameManager.instance.dogPickedup = true;
        }
        if(item.name.Contains("Wood")){
           GameManager.instance.woodPickedup = true;
        }
        if(item.name.Contains("Arrows")){
           GameManager.instance.arrowsPickedup = true;
        }
       


    }

    // Update is called once per fram
    private void OnMouseDown()
    {
        Pickup();
    }
}
