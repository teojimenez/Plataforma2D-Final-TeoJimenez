using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoShoot : MonoBehaviour
{
    public GameObject bullet;
    public GameObject spawnBullet;
    public float cuanto;
    void Start()
    {
        InvokeRepeating("Shoot", 1,cuanto);
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Shoot()
    {
        GameObject temp1 = Instantiate(bullet, spawnBullet.transform.position, spawnBullet.transform.rotation);
        Destroy(temp1, 0.5f);
    }
}
