using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;


public class QuestArrow : MonoBehaviour
{
    
    public Transform target;
    [SerializeField] private Camera uiCamera;

    public QuestArrow TargetArrow;
    public float buffer;

    private GameObject woundedfriend;
    private Vector3 TargetPosition;
    private RectTransform pointerRectTransform;

    void Awake(){
        woundedfriend = GameObject.Find("WoundedFriend");
        pointerRectTransform = GameObject.Find("Pointer").GetComponent<RectTransform>();
        TargetPosition = new Vector3(woundedfriend.transform.position.x, woundedfriend.transform.position.y);//woundedfriend.transform.position.x, woundedfriend.transform.position.y);
    } 


    
    void Update()
    {
        // Vector3 toPosition = TargetPosition;
        // Vector3 fromPosition = Camera.main.transform.position;
        // fromPosition.z = 0f;
        // Vector3 dir = (toPosition - fromPosition).normalized;
        // float angle = UtilsClass.GetAngleFromVectorFloat(dir);
        // pointerRectTransform.localEulerAngles = new Vector3(0, 0, angle);

        // float borderSize = 100f;
        // Vector3 targetPositionScreenPoint = Camera.main.WorldToScreenPoint(TargetPosition);
        // bool isOffscreen = targetPositionScreenPoint.x <= borderSize || targetPositionScreenPoint.x >= Screen.width - borderSize || 
        // targetPositionScreenPoint.y <= borderSize || targetPositionScreenPoint.y >= Screen.height - borderSize;

        // if(isOffscreen){
        //     Vector3 cappedTargetPositionScreen = targetPositionScreenPoint;
        //     if(cappedTargetPositionScreen.x <=borderSize) cappedTargetPositionScreen.x = borderSize;
        //     if(cappedTargetPositionScreen.x >= Screen.width - borderSize) cappedTargetPositionScreen.x = Screen.width - borderSize;
        //     if(cappedTargetPositionScreen.y <=borderSize) cappedTargetPositionScreen.y = borderSize;
        //     if(cappedTargetPositionScreen.y >= Screen.width - borderSize) cappedTargetPositionScreen.y = Screen.width - borderSize;

        //     Vector3 pointerWorldPosition = uiCamera.ScreenToWorldPoint(cappedTargetPositionScreen);
        //     pointerRectTransform.position = pointerWorldPosition;
        //     pointerRectTransform.localPosition = new Vector3(pointerRectTransform.localPosition.x, pointerRectTransform.localPosition.y, 0);
        // }

        // if(isOffscreen)
        // {
        //     pointerRectTransform.gameObject.SetActive(true);

        //     Vector3 cappedTargetScreenPosition = targetPositionScreenPoint;
        //     if(cappedTargetScreenPosition.x <= borderSize)
        //     {
        //         cappedTargetScreenPosition.x = borderSize;
        //     }
        //     if(cappedTargetScreenPosition.x >= Screen.width - borderSize)
        //     {
        //         cappedTargetScreenPosition.x = Screen.width - borderSize;
        //     }
        //     if (cappedTargetScreenPosition.y <= borderSize)
        //     {
        //         cappedTargetScreenPosition.y = borderSize;
        //     }
        //     if (cappedTargetScreenPosition.y >= Screen.height - borderSize)
        //     {
        //         cappedTargetScreenPosition.y = Screen.height - borderSize;
        //     }

        //     pointerRectTransform.position = cappedTargetScreenPosition;
        //     pointerRectTransform.localPosition = new Vector3(pointerRectTransform.localPosition.x, pointerRectTransform.localPosition.y, 0f);   
           
        // }



        if(target != null){
         Vector3 difference = transform.position - target.position;
         float angle = Mathf.Atan2(difference.z, difference.x) * Mathf.Rad2Deg % 360;
         if (angle < 0) angle += 360;
         transform.rotation = Quaternion.Euler(0, 0, angle + buffer);
        }
        
        
    //Get the targets position on screen into a Vector3
        
    }
}
