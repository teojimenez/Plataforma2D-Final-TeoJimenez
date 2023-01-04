using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIKeys : MonoBehaviour
{
    public GameObject key1;
    public GameObject key2;
    public GameObject key3;
    public GameObject keyAlfa;

    key1 Key1Collected1;
    key2 Key2Collected2;
    key3 Key3Collected3;

    void Start()
    {
        Key1Collected1 = FindObjectOfType<key1>();
        Key2Collected2 = FindObjectOfType<key2>();
        Key3Collected3 = FindObjectOfType<key3>();
        Debug.Log("EL VALO DE LA KEY ES"+ Key1Collected1.key);
        keyAlfa.SetActive(true);
        key1.SetActive(false);
        key2.SetActive(false);
        key3.SetActive(false);
    }

                                        
    void Update()
    {
        mostrar();
    }
    void mostrar()
    {
        if (Key1Collected1.key == true)
        {
            key1.SetActive(true);
        }
        if (Key2Collected2.key == true)
        {
            key2.SetActive(true);
        }
        if (Key3Collected3.key == true)
        {
            key3.SetActive(true);
        }
    }
}
