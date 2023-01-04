using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectedCoin : MonoBehaviour
{
    BoxCollider2D collider;
    SpriteRenderer sprite;
    void Start()
    {       
        sprite= GetComponent<SpriteRenderer>();
        collider= GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            sprite.enabled = false;
            collider.enabled = false;
            Destroy(gameObject, 0.5f);
            GameManager.instance.score = GameManager.instance.score + 100;
        }
    }
}
