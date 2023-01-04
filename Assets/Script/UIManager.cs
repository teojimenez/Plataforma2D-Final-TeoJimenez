using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI vidas;
    public TextMeshProUGUI score;
    public GameObject gameOver;

    void Update()
    {
        if (GameManager.instance.vidas <= 0)
        {
            gameOver.SetActive(true);
        }
        vidas.text = GameManager.instance.vidas.ToString();
        score.text = GameManager.instance.score.ToString();
    }
}
