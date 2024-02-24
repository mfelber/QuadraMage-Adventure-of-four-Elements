using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    private bool playerHasCollide = false;
    public static bool playerFinishTheGame = false;

    public static int maxMana = 100;   
    public static int currentMana;

    public ManaBar manaBar;
    public GameObject player;
    Rigidbody2D rigidbody2D;


    public  int level;
    public  int hiddenKey;



    public void SavePlayerData()
    {
        Save.SavePlayerData(this);
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
    void Start()
    {
        
        hiddenKey = 0;

        currentMana = maxMana;
        manaBar.setMaxMana(maxMana);
        rigidbody2D = GetComponent<Rigidbody2D>();


        /*
        if(level == 1)
        {
            SceneManager.LoadScene("New Scene", LoadSceneMode.Additive);
        }
        if(level == 2)
        {
            SceneManager.LoadScene("Scena2", LoadSceneMode.Additive);
        }
        
        */
        //LoadPlayerData();
        //LoadLevelScene();
        Debug.LogError(level);
        
        
    }

    void Update()
    {
        if (ManaBar.isEmpty)
        {
            Invoke("setManaToMax", 3);

        }


        // TODO check which level player playing, restart inventory to corrent level 
        if (Input.GetKeyUp(KeyCode.R))
        {
            //player.transform.position = new Vector3(-8.64f, 0f, 0f);
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name, LoadSceneMode.Single);
            Inventory.inventory.Clear();
        }

        
    }

    public void useMana(int mana)
    {
        currentMana -= mana;
        manaBar.setMana(currentMana);
    }

    void setManaToMax()
    {
        if (currentMana == 0 )
        {
            currentMana = 100;
            manaBar.setMana(currentMana);
            ManaBar.isEmpty = false;
        }
       
    }

    public int getValue()
    {
        return hiddenKey;
    }

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!playerHasCollide) 
        {
            
            if (collision.gameObject.CompareTag("Finish"))
            {
                level += 1;                
                SavePlayerData();
                playerHasCollide = true;
                Inventory.inventory.Clear();
                 
            }
            if (collision.gameObject.CompareTag("Test"))
            {
                //LoadPlayerData();
                Debug.LogError(level);
                Debug.LogError(hiddenKey);
                playerHasCollide = true;
            }

            //TODO if collision compare tag final teleport = player finish the game = true

            if (collision.gameObject.CompareTag("HiddenKey"))
            {
                //LoadPlayerData();
                Debug.LogError(level);
                hiddenKey++;
                Debug.LogError(hiddenKey);
                playerHasCollide = true;
            }

           

        }
        else
        {
            playerHasCollide = false;
        }
       
    }

    public float silaOdrazeniaX = 10f;
    public float silaOdrazeniaY = 2f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (collision.gameObject.CompareTag("Obstacles"))
        {
            if (sceneName == "Level1Demo")
            {
                Invoke("setToSpawn",0.2f);

            }
            if (sceneName == "Level2Demo")
            {
                Invoke("setToSpawn", 0.2f);

            }
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

    private void setToSpawn()
    {
        //player.transform.position = new Vector3(-6.546f, -0.029f, 0);
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name, LoadSceneMode.Single);
        Inventory.inventory.Clear();
    }

}
