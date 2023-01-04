using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.vidas != 0 )
        {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, speed * Time.deltaTime);
        }
    }
}
