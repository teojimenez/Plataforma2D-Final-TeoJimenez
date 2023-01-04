using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
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
        if (collision.gameObject.CompareTag("enemigo"))
        {
            collision.gameObject.GetComponent<EnemigoIABasic>().Muerte();
            Destroy(gameObject);
        }

        ////EnemigoMuerte.MuerteEnemigo();
        //enemigoIABasic.vidaEnemigo = enemigoIABasic.vidaEnemigo - 1; //resta 1 de vida
        //if (enemigoIABasic.vidaEnemigo <= 0)
        //{
        //    Destroy(collision.gameObject);
        //}

        //if (enemigoIABasic.vidaEnemigo <= 0)
        //{
        //    //this.EnemigoMuerte.MuerteEnemigo();
        //}
        ////(collision.gameObject.CompareTag("enemigo"))

        if (collision.tag == "Player")
        {
            FindObjectOfType<Player>().Muerte();
        }
    
    }

}
