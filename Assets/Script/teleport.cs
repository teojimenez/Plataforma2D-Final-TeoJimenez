using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
    Rigidbody2D rb;
    public CapsuleCollider2D collider;
    public GameObject whereT;
    private GameObject Player;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        rb = Player.GetComponent<Rigidbody2D>();
        //collider= GetComponent<CapsuleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            rb.velocity = new Vector2(0, 0);
            Player.transform.position = whereT.transform.position;
            Debug.Log("teleport");
            StartCoroutine(waitToUse());

        }
    }

    IEnumerator waitToUse()
    {
        collider.enabled = false;
        yield return new WaitForSeconds(3);
        collider.enabled = true;
    }
}
