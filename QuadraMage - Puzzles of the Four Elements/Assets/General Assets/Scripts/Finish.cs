using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Cinemachine.DocumentationSortingAttribute;

public class Finish : MonoBehaviour
{

    public Player player;
    //public CircleCollider2D circleCollider;
    
    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        
        if (playerObject != null)
        {
            player = playerObject.GetComponent<Player>();
        }
       

        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        
            if (collision.CompareTag("Player") )
            {
            //play finish sound
            Debug.LogError(player.level + "saved");
             player.level += 1;
            SavePlayerData();
           // Debug.LogError("next level is" + player.level);
            loadLevel();
           
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
