using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// public class ItemInfo : MonoBehaviour
// {
//     //[SerializeField] private Image itemImage;

//     [SerializeField] private Item item;
//     [SerializeField] private TMP_Text title;

//     [SerializeField] private Image icon;
//     [SerializeField] private TMP_Text description;
//     public List<Item> Items = new List<Item>();

//     private Transform ItemContent;
//     private GameObject InventoryItem;

//     public void Awake(){
//         ResetDescription();
//     }

//     public void ResetDescription(){
//         //this.itemIcon.gameObject.SetActive(false);
//         this.title.text = "";
//         this.description.text = "";

//     }

//     public void SetDescription(Sprite sprite, string name, string itemDescription){
//       //this.itemImage.gameObject.SetActive(true);

//       GameObject obj = Instantiate(InventoryItem, ItemContent);
//       var itemName = obj.transform.Find("itemName").GetComponent<TextMeshProUGUI>();
//       var itemIcon = obj.transform.Find("Image").GetComponent<Image>();

//       itemName.text = item.itemName;
//       itemIcon.sprite = item.icon;
//       description.text = item.itemDescription;
     
//       //this.itemIcon.sprite = sprite;
//       //this.title.text = name;
//      //description.text = itemDescription;
//     }
// }
