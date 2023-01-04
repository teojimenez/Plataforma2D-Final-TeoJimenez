using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
    
{
    //public float Speed = 20;
    public float force = 200;
    public float force_air = 100;
    public int jumps_max = 2;
    int jumps;
    Rigidbody2D rb;
    GroundDetector_Raycast ground;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ground = GetComponent<GroundDetector_Raycast>();
    }

    // Update is called once per frame
    void Update()
    {

        if (ground.grounded)
        {
            jumps = jumps_max;
        }
        if (Input.GetButtonDown("Jump") && jumps > 0)
        {
            rb.AddForce(new Vector2(0, force));
            jumps--;

            if (ground.grounded)
            {
                rb.AddForce(new Vector2(0, force));
            }
            else
            {
                rb.AddForce(new Vector2(0, force_air));
            }
        }
    }
}
