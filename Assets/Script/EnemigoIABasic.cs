using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemigoIABasic : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public BoxCollider2D collider;
    public float speed;
    private float waitTime;
    public Transform[] spots;
    public float startWaitTime;
    private int i = 0;

    public Transform Enemigo;

    private Vector2 actualPos;
    void Start()
    {
        //Player = GameObject.FindGameObjectWithTag("Player");
        spriteRenderer = GetComponent<SpriteRenderer>(); 
        collider = GetComponent<BoxCollider2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine(flip());

        IEnumerator flip()
        {
            if (waitTime == 0)
            {
                Debug.Log("Estoy dentro");
                spriteRenderer.flipX = true;
                yield return new WaitForSeconds(waitTime);
                spriteRenderer.flipX = false;
            }
        }

        StartCoroutine(CheckEnemyMoving());
        transform.position = Vector2.MoveTowards(transform.position, spots[i].transform.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, spots[i].transform.position) < 0.1f)
        {
            if (waitTime <= 0)
            {
                if (spots[i] != spots[spots.Length - 1])
                {
                    i++;
                }
                else
                {
                    i = 0;
                }

                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
    IEnumerator CheckEnemyMoving()
    {
        actualPos = transform.position;
        yield return new WaitForSeconds(0.5f);

        if(transform.position.x > actualPos.x)
        {
            spriteRenderer.flipX = true;
        }

        else if (transform.position.x < actualPos.x)
        {
            spriteRenderer.flipX = false;
        }
    }
    public int vidaEnemigo;
    public void Muerte()
    {
        vidaEnemigo--;
        if (vidaEnemigo <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Muerte2()
    {
        Destroy(gameObject);  
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            
            FindObjectOfType<Player>().Muerte();
            //wait();
        }
    }

    public void wait()
    {
        StartCoroutine(Espera());
    }
    IEnumerator Espera()
    {
        collider.enabled = false;
        yield return new WaitForSeconds(3);
        collider.enabled = true;
    }

}
