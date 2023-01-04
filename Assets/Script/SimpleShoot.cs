using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleShoot : MonoBehaviour
{
    public GameObject spawnBullet;
    public GameObject bullet;
    public bool pickup = false;
    Player player;

    void Start()
    {
        player = FindObjectOfType<Player>();
    }
    void Update()
    {
        //Debug.Log(pickup);
        if (player.Arma2 && pickup == true)
        {
                
            if(Input.GetKeyDown(KeyCode.E))
            {
                GameObject temp1 = Instantiate(bullet, spawnBullet.transform.position, spawnBullet.transform.rotation);
                Destroy(temp1, 2.5f);
            }
                

        }

    }
}
