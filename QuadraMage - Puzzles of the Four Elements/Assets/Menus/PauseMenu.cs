using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool isGamePaused;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                ResumeGame();
            } 
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu?.SetActive(true);
        Time.timeScale = 0f; // this will stop animation, and everything
        isGamePaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;   
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartScreen");
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}