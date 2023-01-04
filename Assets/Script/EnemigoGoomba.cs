using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemigoGoomba : MonoBehaviour
{
    public Transform PuntoA;
    public Transform PuntoB;
    public float speed;

    public bool ToA = false;
    public bool ToB = false;

    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ToA = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (ToA)
        {
            rb.transform.position = Vector2.MoveTowards(transform.position, PuntoA.position, speed * Time.deltaTime);

            if (transform.position == PuntoB.position)
            {
                ToA = true;
                ToB = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            Destroy(collision.gameObject);
        }
    }
}
