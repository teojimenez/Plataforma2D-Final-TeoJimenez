using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showLive : MonoBehaviour
{
    public GameObject vida1;
    public GameObject vida2;
    public GameObject vida3;
    public GameObject vida4;

    void Start()
    {
        
    }
    void Update()
    {
        mostrar();
    }

    public void mostrar()
    {
        if (GameManager.instance.vidas == 4)
        {
            vida1.SetActive(false);
            vida2.SetActive(false);
            vida3.SetActive(false);
            vida4.SetActive(true);
        }
        if (GameManager.instance.vidas == 3)
        {
            vida1.SetActive(false);
            vida2.SetActive(false);
            vida3.SetActive(true);
            vida4.SetActive(false);
        }
        else if (GameManager.instance.vidas == 2)
        {
            vida1.SetActive(false);
            vida2.SetActive(true);
            vida3.SetActive(false);
            vida4.SetActive(false);
        }
        else if (GameManager.instance.vidas == 1)
        {
            vida1.SetActive(true);
            vida2.SetActive(false);
            vida3.SetActive(false);
            vida4.SetActive(false);
        }
        else if(GameManager.instance.vidas <= 0)
        {
            vida1.SetActive(false);
            vida2.SetActive(false);
            vida3.SetActive(false);
            vida4.SetActive(false);
        }

    }
}
