using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TodoList : MonoBehaviour
{

    public GameObject Todolist;
    private bool Nearworkbench = false;

    void Start()
    {
        Todolist.SetActive(false);
    }


    void Update()
    {

    }

    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            Debug.Log("Workbench open");
            Todolist.SetActive(true);
            
        } else{
            Todolist.SetActive(false);
        }
    }

    public void CloseMenu(){
        Todolist.SetActive(false);
        
    }
}
