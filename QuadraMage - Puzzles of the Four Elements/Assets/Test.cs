using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Cinemachine.DocumentationSortingAttribute;

public class Test : MonoBehaviour
{

    public Button yourButton;

    private int level;
    private int hiddenKey;
    // Start is called before the first frame update
    void Start()
    {
        LoadPlayerData();
        Debug.LogError(level);
        Debug.LogError(hiddenKey);

        yourButton = GetComponentInChildren<Button>();
        LoadLevelScene();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (hiddenKey == 0)
        {
            yourButton.enabled = false;
        } else
        {
            yourButton.enabled = true;
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
        string sceneName = "Scena" + level; // Predpokladáme, že scény majú názvy vo formáte "Level1", "Level2", at?.
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
