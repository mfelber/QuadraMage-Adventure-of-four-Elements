using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewPauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    //private Book book;
    Inventory inventory;
    ActivateCutScene activateCutScene;

    public static bool isPauseMenuOpen;
    void Start()
    {
       // book = GetComponent<Book>();
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
                //OpenPauseMenu();
                ClosePauseMenu();
            } else
            {
                OpenPauseMenu();
                //ClosePauseMenu();
            }
        }
        //Debug.Log(isPauseMenuOpen);
        
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
        inventory.inventory.Clear();
        Inventory.canUseElement = true;
       

    }

    public void QuitGame()
    {
        inventory.inventory.Clear();
        Inventory.canUseElement = true;
        
        Application.Quit();
    }

   

    public void RestartLevel()
    {
       
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name, LoadSceneMode.Single);
        inventory.inventory.Clear();
        Inventory.canUseElement = true;
        // Debug.Log(inventory.inventory.Count);
        // Vector3 mouseP = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        PlayerMovement.playerFacingRight = true;
        // Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //mousePos = new Vector2(120, mousePos.y);

        
        isPauseMenuOpen = false;
        Time.timeScale = 1f;
    }

}
