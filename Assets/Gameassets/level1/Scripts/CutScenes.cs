using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutScenes : MonoBehaviour
{
    public Image oldImage;
    public Sprite newImage;
    public Sprite newImage2;
    private bool part1 = false;
    
    public void imageChange(){
        oldImage.sprite = newImage;

    }
    
}
