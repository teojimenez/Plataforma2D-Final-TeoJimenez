using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    Rigidbody2D rb;
    CircleCollider2D collider;
    SpriteRenderer sprite;
    SimpleShoot simpleShoot;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<CircleCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        simpleShoot = FindObjectOfType<SimpleShoot>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {   
            Debug.Log("Objeto cogido");
            //script.enabled = true;
            simpleShoot.pickup = true;
            Destroy(gameObject);
        }
    }
}
