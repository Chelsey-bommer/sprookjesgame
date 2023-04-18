using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public bool onlyFollowX;
    
    public float smoothing = 0.1f;
    [SerializeField]
    private float endLeft;
    [SerializeField]
    private float endRight;
    [SerializeField]
    private float endTop;
    [SerializeField]
    private float endBottom;

    private float targetX;
    private float targetY;

   
    public Vector3 offset = new Vector3(0, 2, -10);
    private void LateUpdate()
    {
        transform.position = target.position + offset;
    }

    void FixedUpdate()
    {



        if(target.position.x < endLeft) {
        	targetX = endLeft + offset.x;
        } else if(target.position.x > endRight) {
        	targetX = endRight + offset.x;
        } else {
        	targetX = target.position.x + offset.x;
        }

        if(target.position.y > endTop) {
        	targetY = endTop + offset.y;
        } else if(target.position.y < endBottom) {
        	targetY = endBottom + offset.y;
        } else {
        	targetY = target.position.y + offset.y;
        }

        if (onlyFollowX) {
        	transform.position = Vector3.Lerp (transform.position, new Vector3 (targetX, transform.position.y, transform.position.z), smoothing);
        } else {
        	transform.position = Vector3.Lerp (transform.position, new Vector3 (targetX, targetY, transform.position.z), smoothing);
        }
    }
}
