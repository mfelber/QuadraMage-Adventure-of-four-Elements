using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static int maxMana = 100;   
    public static int currentMana;
    public ManaBar manaBar;

    

    public GameObject player;

    public  int level;
    public  int hiddenKey;

    private bool playerHasCollide = false;


    public static bool playerFinishTheGame = false;

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

    // Update is called once per frame
    void Update()
    {
        if (ManaBar.isEmpty)
        {
            Invoke("setManaToMax", 3);

        }


        // TODO check which level player playing, restart inventory to corrent level 
        if (Input.GetKeyUp(KeyCode.R))
        {
            player.transform.position = new Vector3(-8.64f, 0f, 0f);
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
        if (!playerHasCollide) // Pouze pokud ješt? nebyla kolize zpracována
        {
            Debug.LogError(gameObject);
            if (collision.gameObject.CompareTag("Finish"))
            {
                level += 1;                
                SavePlayerData();
                playerHasCollide = true;
                 
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
