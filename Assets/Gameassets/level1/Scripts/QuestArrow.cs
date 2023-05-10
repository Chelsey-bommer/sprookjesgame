using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;


public class QuestArrow : MonoBehaviour
{
    
    public Transform target;
    public QuestArrow TargetArrow;
    public float buffer;

    void Update()
    {
        if(target != null){
         Vector3 difference = transform.position - target.position;
         float angle = Mathf.Atan2(difference.z, difference.x) * Mathf.Rad2Deg % 360;
         if (angle < 0) angle += 360;
         transform.rotation = Quaternion.Euler(0, 0, angle + buffer);
        }
        
        
    //Get the targets position on screen into a Vector3
        
    }
}
