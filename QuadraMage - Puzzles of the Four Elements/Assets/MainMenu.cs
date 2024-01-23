using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    PauseMenu pausemenu;
    public void startGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        PauseMenu.isGamePaused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
