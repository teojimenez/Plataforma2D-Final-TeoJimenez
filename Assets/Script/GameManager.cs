using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int vidas;
    public int score;
    void Start()
    {
        
    }

    private void Awake() //sucede antes del primer fotograma
    {
        instance = this;
    }
}
