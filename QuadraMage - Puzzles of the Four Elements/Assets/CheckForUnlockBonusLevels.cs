using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CheckForUnlockBonusLevels : MonoBehaviour
{

    public Button bonusLevels;

    

    

    private int level;
    private int hiddenKey;
    
   

    
    void Update()
    {
        
        if (hiddenKey == 0)
        {
            bonusLevels.enabled = false;
        } else
        {
            bonusLevels.enabled = true;
        }
    }

    public void LoadPlayerData()
    {
        //PlayerData data = Save.LoadPlayerSave();

        //level = data.level;
        //hiddenKey = data.hiddenKey;


        PlayerData data = Save.LoadPlayerSave();

        if (data != null)
        {
            level = data.level;
            hiddenKey = data.hiddenKey;
            Debug.Log("Player data loaded. Level: " + level + ", Hidden Key: " + hiddenKey);
        }
        else
        {
            Debug.LogError("Failed to load player data.");
        }

    }

    void LoadLevelScene()
    {
        string sceneName = "Scena" + level; // Predpoklad�me, �e sc�ny maj� n�zvy vo form�te "Level1", "Level2", at?.
        if (SceneManager.GetSceneByName(sceneName) != null)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
        else
        {
            Debug.LogError("Scene not found: " + sceneName);
        }
    }

    private void OnHove()
    {
        Debug.Log("Si na mne");
    }

    
}
