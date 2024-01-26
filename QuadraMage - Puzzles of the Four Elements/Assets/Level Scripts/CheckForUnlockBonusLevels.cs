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



    private void Start()
    {
       LoadPlayerData();
    }


    void Update()
    {
       
        if (hiddenKey > 0) // && player finish the game = true 
        {
            bonusLevels.enabled = true;
        } else
        {
            bonusLevels.enabled = false;
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
        string sceneName = "Scena" + level; 
        if (SceneManager.GetSceneByName(sceneName) != null)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
        else
        {
            Debug.LogError("Scene not found: " + sceneName);
        }
    }

   

    
}
