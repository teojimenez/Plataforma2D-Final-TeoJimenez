using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class DoorItems : MonoBehaviour
{
    public Transform door, open, close;
    public float speed;
    bool isEnter;

    bool AllCollected = false;
    key1 Key1Collected;
    key2 Key2Collected;
    key3 Key3Collected;


    void Start()
    {
        Key1Collected = FindObjectOfType<key1>();
        Key2Collected = FindObjectOfType<key2>();
        Key3Collected = FindObjectOfType<key3>();
        
    }

    void Update()
    {
        //Key1Collected.key == true && Key2Collected.key == true &&
        //Key3Collected.key3 == true
        if (Key1Collected.key == true && Key2Collected.key == true && Key3Collected.key == true)
        {
            AllCollected = true;
        }

        door.transform.position = Vector2.MoveTowards(door.transform.position, AllCollected ? open.position : close.position, speed*Time.deltaTime);
        //items.childCount == 0
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.tag == "Player")
        {
            isEnter= true;
            //Debug.Log("que es???"+ isEnter);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isEnter = false;
        }
    }

}



