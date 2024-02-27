using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    NewPauseMenu newPauseMenu;
    public void loadLevelById(int levelID)
    {
        string name = "Level" + levelID;
        SceneManager.LoadScene(name);
        NewPauseMenu.isPauseMenuOpen = false;
    }

    public void LoadTestLevel()
    {
        SceneManager.LoadScene("Scena1");
    }

    public void LoadSpecificLevel()
    {
        SceneManager.LoadScene("Level2");
    }
}
