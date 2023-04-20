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

    //public Toggle EnableRemove;
    public InventoryItemController[] InventoryItems;

    //[SerializeField] private ItemInfo itemDescription;
    
    private void Start(){
        clearInv();
    }
    private void Awake()
    {
        Instance = this;
        //itemDescription.ResetDescription();
    }

    public void Add(Item item)
    {
        Items.Add(item);
    }

    public void Remove(Item item){
       Items.Remove(item);
    }

    public void clearInv(){
      // clean inventory content before open
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }
      //itemDescription.ResetDescription();
    }

    public void ListItems(){

      
      foreach (var item in Items)  // for every item you pick up
      {
        GameObject obj = Instantiate(InventoryItem, ItemContent);
        var itemName = obj.transform.Find("itemName").GetComponent<TextMeshProUGUI>();
        var itemIcon = obj.transform.Find("Image").GetComponent<Image>();
        //var removeButton = obj.transform.Find("removeitem").GetComponent<Button>();

        itemName.text = item.itemName;
        itemIcon.sprite = item.icon;
       
      }
      

      SetInventoryItems();
      
    }


    public void SetInventoryItems(){
        InventoryItems = ItemContent.GetComponentsInChildren<InventoryItemController>();

        for (int i = 0; i < Items.Count; i++)
        {
            InventoryItems[i].AddItem(Items[i]);
        }
    }

    
}
