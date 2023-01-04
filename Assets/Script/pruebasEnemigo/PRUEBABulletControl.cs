using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PRUEBABulletControl : MonoBehaviour
{
    Rigidbody2D rb;
    public float bulletSpeed = 12;
    public float bulletLive = 3;

    void Start()
    {
    rb = GetComponent<Rigidbody2D>();
    rb.AddForce(transform.right * bulletSpeed);
    Destroy(gameObject, bulletLive);


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemigo"))
        {
            collision.gameObject.GetComponent<PRUEBAEnemigoIA>().Muerte();
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
