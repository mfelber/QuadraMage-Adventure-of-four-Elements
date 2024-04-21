using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewPauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
   
    Inventory inventory;
    ActivateCutScene activateCutScene;

    public static bool isPauseMenuOpen;
    void Start()
    {
       
        pauseMenu.SetActive(false);
        inventory = FindObjectOfType<Inventory>();
        activateCutScene = FindObjectOfType<ActivateCutScene>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isPauseMenuOpen)
            {
              
                ClosePauseMenu();
            } else
            {
                OpenPauseMenu();
               
            }
        }
     
        
    }


    public void OpenPauseMenu()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
      
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
        inventory.inventory.Clear();
        Inventory.canUseElement = true;
       

    }

    public void QuitGame()
    {
        inventory.inventory.Clear();
        Inventory.canUseElement = true;
        
        Application.Quit();
    }

   
   

}
