using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    public static bool isPauseMenuOpen;
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isPauseMenuOpen)
            {
                OpenPauseMenu();
            } else
            {
                ClosePauseMenu();
            }
        }

        
    }

    public void ClosePauseMenu()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPauseMenuOpen = true;
    }

    public void OpenPauseMenu()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPauseMenuOpen = false;
    }
}
