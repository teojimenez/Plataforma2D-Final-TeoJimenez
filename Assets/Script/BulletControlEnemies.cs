using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControlEnemies : MonoBehaviour
{
    Rigidbody2D rb;
    public float bulletSpeed = 12;
    public float bulletLive = 3;
    //Enemigo enemigo;


    //EnemigoIABasic enemigoIABasic;

    public Player score;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * bulletSpeed);
        Destroy(gameObject, bulletLive);

        //enemigoIABasic = FindObjectOfType<EnemigoIABasic>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            FindObjectOfType<Player>().Muerte();
        }

    }
}
