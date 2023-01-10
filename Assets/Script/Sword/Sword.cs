using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    BoxCollider2D collider;
    public Animator animator;
    Player player;
    void Start()
    {
        collider= GetComponent<BoxCollider2D>();
        player = FindObjectOfType<Player>();    
    }
    // Update is called once per frame
    void Update()
    {
        if(player.Arma1 && Input.GetKeyUp(KeyCode.E))
        {
            Attack();
            //if (Input.GetKeyUp(KeyCode.E)) 
            {
                Attack();
            }

        }
    }
    public void Attack()
    {
        animator.Play("Sword-Attack");
        collider.enabled = true;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("enemigo"))
        {
            collision.gameObject.GetComponent<EnemigoIABasic>().Muerte();
        }
        if (collision.gameObject.CompareTag("enemigoEspecial"))
        {
            collision.gameObject.GetComponent<EnemigoIABasic>().Muerte();
        }
    }
}
