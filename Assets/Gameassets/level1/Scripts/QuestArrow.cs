using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestArrow : MonoBehaviour
{
    
    public Transform target;
    public float buffer;


    void Start()
    {
        
    }

    
    void Update()
    {
        if(target != null){
         Vector2 difference = transform.position - target.position;
         float angle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
         transform.rotation = Quaternion.Euler(0, 0, angle+ buffer);
        }
        
    }
}
