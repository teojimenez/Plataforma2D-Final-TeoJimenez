using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Player : MonoBehaviour
{
    public float Speed = 20;
    Rigidbody2D rb;
    GroundDetector_Raycast ground;
    Animator anim;
    //public Animation animation;
    //public GameObject coin;
    public SpriteRenderer pruebaLlave;
    public int score;
    SpriteRenderer sprite;
    CapsuleCollider2D collider;
    //public BoxCollider2D colliderEnemigo;

    public bool muerto;
    bool bandera = false;
    public Transform spawnPlayer;
    public Transform spawnBandera;

    public float force = 20;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ground = GetComponent<GroundDetector_Raycast>();
        anim = GetComponent<Animator>();
        //animation = GetComponent<Animation>();
        sprite= GetComponent<SpriteRenderer>();
        collider= GetComponent<CapsuleCollider2D>();

        transform.position = spawnPlayer.transform.position;
        spriteVerde.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.position = transform.position + new Vector3(horizontal * Time.deltaTime * Speed, 0);
        anim.SetBool("grounded", ground.grounded);
        anim.SetBool("moving", horizontal != 0);
        if (horizontal > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (horizontal < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        //if(Input.GetKeyDown(KeyCode.E))
            {
                //animation.CrossFade("air");
            }

    //if (GameManager.instance.score == 300)
        {
            pruebaLlave.enabled = true;
        }


        Arma();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "coin")
        {
            Destroy(collision.gameObject);
            GameManager.instance.score = GameManager.instance.score + 10;
        }
        if (collision.tag == "key")
        {
            Destroy(collision.gameObject);
            GameManager.instance.score = GameManager.instance.score + 100;
        }
        if (collision.tag == "vida")
        {
            Destroy(collision.gameObject);
            GameManager.instance.vidas = GameManager.instance.vidas + 1;
        }

        if (collision.tag == "bandera")
        {
            bandera = true;
            spriteRojo.enabled = false;
            spriteVerde.enabled = true;
        }

    }
    public bool Arma1 = false; //lanza
    public bool Arma2 = false; //flecha
    public void Arma()
    {
        //Input.GetKeyDown(KeyCode.Keypad1)
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            Arma1 = true;
            Arma2 = false;
            Debug.Log("1 apretado y lanza es" + Arma1 + "; shuriken es" + Arma2);
        }
        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            Arma1 = false;
            Arma2 = true;
            Debug.Log("2 apretado y lanza es" + Arma1 + "; shuriken es" + Arma2);
        }
    }
    public void Muerte()
    {
        GameManager.instance.vidas -= 1;
        //FindObjectOfType<EnemigoIABasic>().wait();
        if (GameManager.instance.vidas <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            StartCoroutine(Respawn_Coroutine());
            Debug.Log("ToqueDENTRO");
        }
    }

    public SpriteRenderer spriteRojo;
    public SpriteRenderer spriteVerde;

    IEnumerator Respawn_Coroutine()
    {
        muerto = true;
        sprite.enabled = false;
        yield return new WaitForSeconds(0.5f);

        if(bandera)
        {
            //Debug.Log("Bandera cogida, checkpoint");
            //transform.position = new Vector3(22, -3.52f, 0);
            transform.position = spawnBandera.transform.position;
            rb.velocity = new Vector2(0, 0);
            muerto = false;
            sprite.enabled = true;


        }
        else
        {

            //transform.position = new Vector3(-10, -3, 0);
            transform.position = spawnPlayer.transform.position;
            rb.velocity = new Vector2(0, 0);
            muerto = false;
            sprite.enabled = true;
        }

    }

}
