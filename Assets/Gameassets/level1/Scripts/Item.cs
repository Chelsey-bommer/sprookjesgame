using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]

public class Item : ScriptableObject
{
   // Be able to make item in unity with following components

   public int id;
   public string itemName;
   public int value;
   public Sprite icon;

   public GameObject prefab;
    

}
