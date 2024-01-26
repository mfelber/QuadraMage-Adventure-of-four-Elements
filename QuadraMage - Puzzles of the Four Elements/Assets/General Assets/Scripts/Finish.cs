using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{

    public Player player; 
    // audiosource 
    void Start()
    {
        //finish audio source
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            // Get the Player component from the playerObject
            player = playerObject.GetComponent<Player>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //play finish sound
           
            loadLevel();
            //SavePlayerData();
        }
    }

    private void loadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SavePlayerData()
    {
        Save.SavePlayerData(player);
    }

}
