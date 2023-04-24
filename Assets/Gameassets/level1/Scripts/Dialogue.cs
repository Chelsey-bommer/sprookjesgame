using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Code van tutorial, bron:

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    private int index;

    void Start()
    {
        textComponent.text = string.Empty;
        startDialogue();
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Return)){
            if(textComponent.text == lines[index]){
                NextLine();
            } else{
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void startDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        } else{
            gameObject.SetActive(false);
        }

    }
}