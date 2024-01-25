using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    NewPauseMenu newPauseMenu;
    public void loadLevelById(int levelID)
    {
        string name = "Scena" + levelID;
        SceneManager.LoadScene(name);
        NewPauseMenu.isPauseMenuOpen = false;
    }
}
