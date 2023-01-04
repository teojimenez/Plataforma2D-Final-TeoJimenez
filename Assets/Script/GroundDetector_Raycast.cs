using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GroundDetector_Raycast : MonoBehaviour
{
    public bool grounded;
    public float lenght = 1;
    public LayerMask mask;

    public List<Vector3> originPoints;

    

    // Update is called once per frame
    void Update()
    {
        grounded = false;
        for (int i = 0; i < originPoints.Count; i++)
        {
            Debug.DrawRay(transform.position + originPoints[i], Vector3.down * lenght, Color.red);
            RaycastHit2D hit = Physics2D.Raycast(transform.position + originPoints[i], Vector3.down, lenght, mask);
            if (hit.collider != null)
            {
            if(hit.collider.tag == "Plataforma")
                {
                    transform.parent = hit.transform;
                }
            Debug.DrawRay(transform.position + originPoints[i], Vector3.down * hit.distance, Color.green);
            grounded = true;

            }
            else
            {
                transform.parent = null;
            }
            


        }
        if (!grounded)
        {
            transform.parent = null;            
        }

        //Debug.DrawRay(transform.position, Vector3.down * lenght, Color.red);
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.down, lenght, mask);

        //if(hit.collider != null)
        //{
        //    Debug.DrawRay(transform.position, Vector3.down * hit.distance, Color.green);
        //    grounded = true;

        //}
        //else
        //{
        //    grounded = false;   
        //}


    }
}
