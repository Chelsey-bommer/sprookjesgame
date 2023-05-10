using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;


public class QuestArrow : MonoBehaviour
{
    
    public Transform target;

    public QuestArrow TargetArrow;
    public float buffer;

    private GameObject woundedfriend;
    private Vector3 TargetPosition;
    private RectTransform pointerRectTransform;

    void Awake(){
        woundedfriend = GameObject.Find("WoundedFriend");
        pointerRectTransform = GameObject.Find("Pointer").GetComponent<RectTransform>();
        TargetPosition = new Vector3(0,-105,0);//new Vector3(woundedfriend.transform.position.x, woundedfriend.transform.position.y, woundedfriend.transform.position.y);
    }


    
    void Update()
    {
        Vector3 toPosition = TargetPosition;
        Vector3 fromPosition = Camera.main.transform.position;
        fromPosition.z = 0f;
        Vector3 dir = (toPosition - fromPosition).normalized;
        float angle = UtilsClass.GetAngleFromVectorFloat(dir);
        pointerRectTransform.localEulerAngles = new Vector3(0, 0, angle);



        // if(target != null){
        //  Vector3 difference = transform.position - target.position;
        //  float angle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg % 360;
        //  transform.rotation = Quaternion.Euler(0, 0, angle + buffer);
        // }
        
        
    //Get the targets position on screen into a Vector3
        
    }
}
