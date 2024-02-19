using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewPauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    //private Book book;

    public static bool isPauseMenuOpen;
    void Start()
    {
       // book = GetComponent<Book>();
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isPauseMenuOpen)
            {
                //OpenPauseMenu();
                ClosePauseMenu();
            } else
            {
                OpenPauseMenu();
                //ClosePauseMenu();
            }
        }

        
    }


    public void OpenPauseMenu()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        // book.OpenBook();
        isPauseMenuOpen = true;
    }

    public void ClosePauseMenu()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;

        isPauseMenuOpen = false;
    }

  
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
        Inventory.inventory.Clear();

    }

    public void QuitGame()
    {
        Inventory.inventory.Clear();
        Application.Quit();
    }

}
