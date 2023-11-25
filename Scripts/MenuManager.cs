using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;

    public GameObject pauseScreen;

    void Start()
    {
        instance = this;    
    }
    public void Play(string Scene)
    {
        SceneManager.LoadScene(Scene);
    }
    public void ExitGame()
    {
        Application.Quit(); 
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
    }
}
