using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector_Trigger : MonoBehaviour
{
    public bool grounded;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        grounded = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        grounded = false;
    }
}
