using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PRUEBAEnemigoIA : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    BoxCollider2D collider;
    public float speed;
    private float waitTime;
    public Transform[] spots;
    public float startWaitTime;
    private int i = 0;

    public Transform Enemigo;

    private Vector2 actualPos;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

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

        if (transform.position.x > actualPos.x)
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
        if(vidaEnemigo <= 0) 
        { 
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Toque");
            FindObjectOfType<Player>().Muerte();
        }
    }
}
