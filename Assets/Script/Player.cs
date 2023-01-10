using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Player : MonoBehaviour
{
    public float Speed = 20;
    Rigidbody2D rb;
    GroundDetector_Raycast ground;
    Animator anim;
    //public Animation animation;
    //public GameObject coin;
    public int score;
    SpriteRenderer sprite;
    CapsuleCollider2D collider;
    //public BoxCollider2D colliderEnemigo;

    public bool muerto;
    bool bandera = false;
    bool bandera2 = false;
    bool bandera3 = false;
    public Transform spawnPlayer;
    public Transform spawnBandera;
    public Transform spawnBandera2;
    public Transform spawnBandera3;

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
        spriteVerde2.enabled = false;
        spriteVerde3.enabled = false;
        mainBow.SetActive(false);

        Arma1 = true;
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

        Arma();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "coin")
        {
            Destroy(collision.gameObject);
            GameManager.instance.score = GameManager.instance.score + 10;
        }
        if (collision.tag == "enemigoEspecial")
        {
            GameManager.instance.score = GameManager.instance.score + 10;
        }
        if (collision.tag == "enemigo")
        {
            GameManager.instance.score = GameManager.instance.score + 5;
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
            bandera2 = false;
            bandera3 = false;
            spriteRojo.enabled = false;
            spriteVerde.enabled = true;
        }
        if (collision.tag == "bandera2")
        {
            bandera2 = true;
            bandera = false;
            bandera3 = false;

            spriteRojo2.enabled = false;
            spriteVerde2.enabled = true;
        }
        if (collision.tag == "bandera3")
        {
            bandera3 = true;
            bandera = false;
            bandera2 = false;

            spriteRojo3.enabled = false;
            spriteVerde3.enabled = true;
        }
        if (collision.tag == "Menu")
        {
            SceneManager.LoadScene(0);
        }

    }
    public bool Arma1 = false; //lanza
    public bool Arma2 = false; //flecha
    public GameObject lanza;
    public GameObject flecha;
    public GameObject mainLanza;
    public GameObject mainBow;

    public SpriteRenderer spriteRojo;
    public SpriteRenderer spriteVerde;
    public SpriteRenderer spriteRojo2;
    public SpriteRenderer spriteVerde2;
    public SpriteRenderer spriteRojo3;
    public SpriteRenderer spriteVerde3;


    public void Arma()
    {
        //Input.GetKeyDown(KeyCode.Keypad1)
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            Arma1 = true;
            Arma2 = false;
            lanza.SetActive(true);
            flecha.SetActive(false);
            mainLanza.SetActive(true);
            mainBow.SetActive(false);
            //Debug.Log("1 apretado y lanza es" + Arma1 + "; shuriken es" + Arma2);
        }
        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            Arma1 = false;
            Arma2 = true;
            lanza.SetActive(false);
            flecha.SetActive(true);
            mainLanza.SetActive(false);
            mainBow.SetActive(true);
            //Debug.Log("2 apretado y lanza es" + Arma1 + "; shuriken es" + Arma2);
        }
    }
    public void AnimMuerte()
    {
        anim.Play("damage");
    }
    public void Muerte()
    {
        GameManager.instance.vidas -= 1;
        anim.Play("damage");
        //FindObjectOfType<EnemigoIABasic>().wait();
        if (GameManager.instance.vidas <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            StartCoroutine(Respawn_Coroutine());
        }
    }


    IEnumerator Respawn_Coroutine()
    {
        muerto = true;
        //sprite.enabled = false;
        yield return new WaitForSeconds(0.25f);

        if(bandera)
        {
            //Debug.Log("Bandera cogida, checkpoint");
            //transform.position = new Vector3(22, -3.52f, 0);
            transform.position = spawnBandera.transform.position;
            rb.velocity = new Vector2(0, 0);
            muerto = false;
            sprite.enabled = true;
        }
        else if (bandera2)
        {
            transform.position = spawnBandera2.transform.position;
            rb.velocity = new Vector2(0, 0);
            muerto = false;
            sprite.enabled = true;
        }
        else if (bandera3)
        {
            transform.position = spawnBandera3.transform.position;
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
