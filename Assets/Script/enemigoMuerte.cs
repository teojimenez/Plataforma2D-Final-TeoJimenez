using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigoMuerte : MonoBehaviour
{
    SpriteRenderer sprite;
    BoxCollider2D collider;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
    }

    public int vidaEnemigo;
    public void MuerteEnemigo()
    {
            //sprite.enabled = false;
            //collider.enabled = false;
            //Destroy(this.gameObject, 0.1f);
        //if(vidaEnemigo <= 0)
        //{

        //     Destroy(this.gameObject, 0.1f);

        //}
        //Debug.Log("estoy dentro");
        //if (vidaEnemigo <= 0)
        //{
        //    sprite.enabled = false;
        //    collider.enabled = false;
        //    Destroy(gameObject, 0.1f);
        //    Debug.Log("estoy dentro");
        //}
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "Player")
    //    {
    //        FindObjectOfType<Player>().Muerte();
    //    }
    //}

}
