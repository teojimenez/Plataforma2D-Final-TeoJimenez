using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePaused = false;
    public GameObject pauseMenu;

    void Start()
    {
        pauseMenu.SetActive(false); 
    }

        void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        { 
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        GamePaused = false;
    }
    void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        GamePaused= true;
    }

    public void Quit()
    {
        Application.Quit();
    }
    public void Menu()
    {
        Debug.Log("ASDASDASD");
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
