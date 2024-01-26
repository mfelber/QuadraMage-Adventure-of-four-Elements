using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class ChangeMainQuestText : MonoBehaviour
{
    public TextMeshProUGUI MainQuest;
    public Player player;

    void Start()
    {

        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        Debug.LogError(sceneName);

        if (playerObject != null)
        {
            // Get the Player component from the playerObject
            player = playerObject.GetComponent<Player>();
        }

        if (sceneName == "Level1")
        {
            Debug.LogError("si v tejto scene" + sceneName);
            //MainQuest.text = player.getValue().ToString();
            MainQuest.text += "1.Collect Fire element";
        }
        if (sceneName == "Scena2")
        {
            Debug.LogError("si v tejto scene" + sceneName);
            MainQuest.text += "2.Collect Water element";
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
