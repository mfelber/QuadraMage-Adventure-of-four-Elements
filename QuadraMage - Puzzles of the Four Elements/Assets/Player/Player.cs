using Cinemachine;
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


    public int level;
    public int hiddenKey;

    public CinemachineVirtualCamera vcam;
    public GameObject interactionMassage;

    public int quest;

    public bool inRangeOfTnt;

    private PoseidonQuestManager poseidonQuestManager;
    public bool nearofNpcFirstQuest;
    public bool nearofNpcSecondQuest;
    public bool nearofNpcThirdQuest;
    public bool nearofPoseidonQuest;

    Inventory inventory;
    public GameObject Wand;
    ActivateCutScene activateCutScene;

    public bool b2enabled;
    public bool b3enabled;
    public bool b4enabled;
    public void SavePlayerData()
    {
        Save.SavePlayerData(this);
    }


    public void LoadPlayerData()
    {
        


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

    public bool isPlayerHide;
    public bool inRange;
    public static bool inRangeOfLever;
    public static bool inRangeOfMineCartLever;
    public static bool inRangeOfNPC;
    public static bool infrontOfTavern = false;
    public static bool infrontOfDoors = false;
    public static bool inBulding = false;

    public bool canbereloaded = false;
    public static bool manaIsLoaded = true;
    void Start()
    {
       
       inBulding = false;
        infrontOfTavern = false;
        infrontOfDoors = false;
        quest = 1;
        hiddenKey = 0;
        inventory = FindObjectOfType<Inventory>();
        currentMana = maxMana;
        manaBar.setMaxMana(maxMana);
        rigidbody2D = GetComponent<Rigidbody2D>();
        canbereloaded = false;
        inRangeOfTnt = false;
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Elements"));
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("WorkBench"));
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Fluids"));
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Block"));
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("WaterTank"));
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Ship"));
        //Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Enemy"), false);
        string sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == "Level1")
        {
            Wand.SetActive(false);
        }
       

        poseidonQuestManager = FindObjectOfType<PoseidonQuestManager>();
        activateCutScene = FindObjectOfType<ActivateCutScene>();
       
        LoadPlayerData();
       
       
        


    }
  
   

    void Update()
    {

        

        if (infrontOfTavern && Input.GetKeyDown(KeyCode.E))
        {
            inBulding = true;
        } 

        if (infrontOfDoors && Input.GetKeyDown(KeyCode.E))
        {
            inBulding = false;
        }

        
        if (inBulding == false)
        {
            
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("NPC"),true);
        } else
        {
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("NPC"), false);
            
        }
        
      

        if (ManaBar.isEmpty)
        {
          

            StartCoroutine(setToCanBeReloaded());


        }
        
        if(inventory.inventory.Count >= 1)
        {
            Wand.SetActive(true);
        }
        

        if (Inventory.isPlayerUsingElement == false && currentMana < maxMana)
        {
            
            StartCoroutine(setToCanBeReloaded());
            
        }

        
       




        
        if (inRange == true && Input.GetKeyDown(KeyCode.E))
        {

            if (isPlayerHide == false)
            {
                hidePlayer();
            } else
            {
                unHidePlayer();
            }

        }
        
        if (isPlayerHide == true)
        {
            inRange = true;

        }

        
       

       
    }

   

    



    IEnumerator setToCanBeReloaded()
    {
        if (!canbereloaded)
        {
            yield return new WaitForSeconds(1f);
            canbereloaded = true;            
            StopCoroutine("CheckForManaLoad");    

            StartCoroutine(CheckForManaLoad());
        }
    }


    
    IEnumerator CheckForManaLoad()
    {
        if (canbereloaded)
        {
            
            yield return new WaitForSeconds(5);

            currentMana = 100;
            manaBar.setMana(currentMana);
            canbereloaded = false;
            manaIsLoaded = false;
            ManaBar.isEmpty = false;
            StopCoroutine("setToCanBeReloaded");
            Invoke("manaIsLoadedfun",1.5f);
           
        }

        
    }

    IEnumerator setManaTomax()
    {
        yield return new WaitForSeconds(3);
        manaIsLoaded = false;
        currentMana = 100;
        manaBar.setMana(currentMana);
        ManaBar.isEmpty = false;
        Invoke("manaIsLoadedfun", 1.5f);

    }


    public void manaIsLoadedfun()
    {
        manaIsLoaded = true;    
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


    public void hidePlayer()
    {
        isPlayerHide = true;
        player.transform.position = new Vector2(13.4f, 213.9617f);    
        vcam.Follow = null;      

    }

    


    public void unHidePlayer()
    {

        player.transform.position = new Vector2(-2.215332f, 23.71198f);
        vcam.Follow = player.transform;
        isPlayerHide = false;
        


    }

   

    private void OnTriggerEnter2D(Collider2D collision)
    {

       


        if (collision.gameObject.CompareTag("THE END"))
        {
            SceneManager.LoadScene("THE END");
        }

        
        if (collision.gameObject.CompareTag("Obstacles"))
        {
            
            Invoke("setToSpawn", 0.1f);
           


        }
        

        if (collision.gameObject.CompareTag("Barrel") )
        {
            inRange = true;
            interactionMassage.SetActive(true);

        }

        
            if (collision.gameObject.CompareTag("Lever"))
            {
                inRangeOfLever = true;
                
            }


        if (collision.gameObject.CompareTag("MineCartLever"))
        {
            inRangeOfMineCartLever = true;
           
        }



        if (collision.gameObject.CompareTag("NPC"))
        {
            inRangeOfNPC = true;
            interactionMassage.SetActive(true);
        }

        if (collision.gameObject.CompareTag("camera"))
        {
            StartCoroutine(ChangeOrthoSizePirateShip(9f, 2f));
           
        }

       
        if (collision.gameObject.CompareTag("Tavern"))
        {
           
            infrontOfTavern = true;
            interactionMassage.SetActive(true);
        }

        if (collision.gameObject.CompareTag("InBuilding"))
        {
           
            infrontOfDoors = true;
            interactionMassage.SetActive(true);
        }


        if (collision.gameObject.CompareTag("FirstQuest"))
        {
            inRangeOfNPC = true;
            nearofNpcFirstQuest = true;
            interactionMassage.SetActive(true);
        }

        if (collision.gameObject.CompareTag("SecondQuest"))
        {
            inRangeOfNPC = true;
            nearofNpcSecondQuest = true;
            interactionMassage.SetActive(true);
        }

        if (collision.gameObject.CompareTag("ThirdQuest"))
        {
            inRangeOfNPC = true;
            nearofNpcThirdQuest = true;
            interactionMassage.SetActive(true);
        }

        if (collision.gameObject.CompareTag("PoseidonQuest"))
        {
            inRangeOfNPC = true;
            nearofPoseidonQuest = true;
            interactionMassage.SetActive(true);
        }

        if (!playerHasCollide) 
        {
            
            if (collision.gameObject.CompareTag("Finish"))
            {
                
                playerHasCollide = true;
                inventory.inventory.Clear();
               
                 
            }
            if (collision.gameObject.CompareTag("Test"))
            {
                LoadPlayerData();
                Debug.LogError(level);
                
                playerHasCollide = true;
            }

            

            if (collision.gameObject.CompareTag("HiddenKey"))
            {
                
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

   

    IEnumerator ChangeOrthoSizePirateShip(float newValue, float time)
    {
        float startingValue = vcam.m_Lens.OrthographicSize;
        float elapsedTime = 0f;

        while (elapsedTime < time)
        {
            vcam.m_Lens.OrthographicSize = Mathf.Lerp(startingValue, newValue, elapsedTime / time);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        
        vcam.m_Lens.OrthographicSize = newValue;
    }

    



    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Finish"))
        {
           
            playerHasCollide = false;
            

        }

        if (collision.gameObject.CompareTag("Barrel") )
        {
            inRange = false;
            interactionMassage.SetActive(false);
        }
               
            if (collision.gameObject.CompareTag("Lever"))
            {
                inRangeOfLever = false;
                
            }

        if (collision.gameObject.CompareTag("MineCartLever"))
        {
            inRangeOfMineCartLever = false;
            
        }

        if (collision.gameObject.CompareTag("NPC"))
        {
            inRangeOfNPC = false;
            interactionMassage.SetActive(false);
        }
        if (collision.gameObject.CompareTag("camera"))
        {
            StartCoroutine(ChangeOrthoSizePirateShip(5.8f, 2f));
            
        }

        if (collision.gameObject.CompareTag("Tavern"))
        {
           
            infrontOfTavern = false;
            interactionMassage.SetActive(false);

        }

        if (collision.gameObject.CompareTag("InBuilding"))
        {
            
            infrontOfDoors = false;
            interactionMassage.SetActive(false);
        }
        


        if (collision.gameObject.CompareTag("FirstQuest"))
        {
            inRangeOfNPC = false;
            nearofNpcFirstQuest = false;
            interactionMassage.SetActive(false);
        }

        if (collision.gameObject.CompareTag("SecondQuest"))
        {
            inRangeOfNPC = false;
            nearofNpcSecondQuest = false;
            interactionMassage.SetActive(false);
        }

        if (collision.gameObject.CompareTag("ThirdQuest"))
        {
            inRangeOfNPC = false;
            nearofNpcThirdQuest = false;
            interactionMassage.SetActive(false);
        }

        if (collision.gameObject.CompareTag("PoseidonQuest"))
        {
            inRangeOfNPC = false;
            nearofPoseidonQuest = false;
            interactionMassage.SetActive(false);
        }

    }

    public float silaOdrazeniaX = 10f;
    public float silaOdrazeniaY = 2f;

    
   

    

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
        
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name, LoadSceneMode.Single);
     
        inventory.inventory.Clear();
        Inventory.canUseElement = true;
        Inventory.isPlayerUsingElement = false;
        GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();
        foreach (GameObject obj in allObjects)
        {
            

            Destroy(obj);
        }

    }

}
