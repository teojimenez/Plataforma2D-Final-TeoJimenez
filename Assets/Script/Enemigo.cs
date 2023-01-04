using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemigo : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D collider1;
    SpriteRenderer sprite;
    public float speed;
    public Transform detect;
    public LayerMask wallMask;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        collider1 = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new  Vector2(transform.right.x * speed, rb.velocity.y);

        Collider2D collision = Physics2D.OverlapCircle(detect.position, 0.1f, wallMask);
        if(collision != null) 
        {
            transform.eulerAngles = transform.eulerAngles.y == 0 ? new Vector3(0, 180, 0) : new Vector3(0, 0, 0);
        }

    }
    public int vidaEnemigo;
    public void MuerteEnemigo()
    {        
        if(vidaEnemigo <= 0)
        {
            sprite.enabled = false;
            collider1.enabled = false;
            Destroy(gameObject, 0.1f);
            Debug.Log("estoy dentro");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            FindObjectOfType<Player>().Muerte();        
        }
    }
}
