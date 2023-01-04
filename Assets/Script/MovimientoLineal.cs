using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoLineal : MonoBehaviour
{
    public List<Transform> puntos;
    int puntoActual;
    public float speed;

    void Start()
    {
        transform.position = puntos[0].position;    
    }
    void Update()
    {
        if (Vector3.Distance(transform.position, puntos[puntoActual].position) < 0.1f)
        {
            puntoActual++;
            if(puntoActual >= puntos.Count)
            {
                puntoActual = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, puntos[puntoActual].position, speed * Time.deltaTime); 
        //transform.localScale= Vector3.one;
    }
}
