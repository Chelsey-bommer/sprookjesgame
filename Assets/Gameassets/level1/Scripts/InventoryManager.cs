using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> Items = new List<Item>();
    public Transform ItemContent;
    public GameObject InventoryItem;

    public Toggle EnableRemove;
    
    private void Awake()
    {
        Instance = this;
    }

    public void Add(Item item)
    {
        Items.Add(item);
    }

    public void Remove(Item item){
       Items.Remove(item);
    }

    public void ListItems(){

        // clean inventory content before open
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }
      
      foreach (var item in Items)  // for every item you pick up
      {
        GameObject obj = Instantiate(InventoryItem, ItemContent);
        var itemName = obj.transform.Find("itemName").GetComponent<TextMeshProUGUI>();
        var itemIcon = obj.transform.Find("Image").GetComponent<Image>();

        itemName.text = item.itemName;
        itemIcon.sprite = item.icon;
      }
    }

    public void EnableItemsRemove(){
        if(EnableRemove.isOn){
            foreach (Transform item in ItemContent)
            {
                item.Find("removeitem").gameObject.SetActive(true);

            }
        } else{
            foreach (Transform item in ItemContent)
            {
                item.Find("removeitem").gameObject.SetActive(false);

        }}
    }
}
