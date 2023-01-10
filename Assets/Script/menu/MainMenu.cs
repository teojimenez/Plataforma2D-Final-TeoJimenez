using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Update()
    {
        
    }
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Quit()
    {
        UnityEditor.EditorApplication.isPlaying = false;    
        Application.Quit(); 
    }
    public void N1()
    {
        SceneManager.LoadScene(2);
    } public void N2()
    {
        SceneManager.LoadScene(3);
    } public void Gym()
    {
        SceneManager.LoadScene(1);
    }
}
