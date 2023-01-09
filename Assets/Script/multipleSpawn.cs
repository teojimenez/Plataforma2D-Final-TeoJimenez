using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class multipleSpawn : MonoBehaviour
{
    public Transform spawnMain;
    public Transform spawn2;
    public Transform spawn3;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawns()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "bandera")
        {
        }

    }
}
