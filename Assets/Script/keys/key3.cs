using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key3 : MonoBehaviour
{
    public bool key;
    public SpriteRenderer sprite;
    public BoxCollider2D collider;
    void Start()
    {
        Debug.Log(key);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            Debug.Log("KEY UNO COGIDA");

            key = true;
            Debug.Log(key);
            collider.enabled = false;
            sprite.enabled = false;
        }
    }
}
