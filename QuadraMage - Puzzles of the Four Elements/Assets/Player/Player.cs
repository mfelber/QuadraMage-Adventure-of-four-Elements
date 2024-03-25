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

    Inventory inventory;
    public GameObject Wand;
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

    public bool isPlayerHide;
    public bool inRange;
    public static bool inRangeOfLever;
    public static bool inRangeOfMineCartLever;
    public static bool inRangeOfNPC;

    void Start()
    {
       // playerHasCollide = false;
        quest = 1;
        hiddenKey = 0;
        inventory = FindObjectOfType<Inventory>();
        currentMana = maxMana;
        manaBar.setMaxMana(maxMana);
        rigidbody2D = GetComponent<Rigidbody2D>();
        canbereloaded = false;
        inRangeOfTnt = false;
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Elements"));

        string sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == "Level1")
        {
            Wand.SetActive(false);
        }
        // Physics2D.IgnoreLayerCollision(6,14);

        poseidonQuestManager = FindObjectOfType<PoseidonQuestManager>();
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
        LoadPlayerData();
        //LoadLevelScene();
       
        


    }
  
    public bool canbereloaded = false;
    public static bool manaIsLoaded = true;

    void Update()
    {
        //Debug.LogError(playerHasCollide);
        if (ManaBar.isEmpty)
        {
            //Invoke("setManaToMax", 3);
           // StopCoroutine("CheckForManaLoad");
            //StopCoroutine("setToCanBeReloaded");
            //StartCoroutine(setManaTomax());

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

        /*
        if (Inventory.isPlayerUsingElement == true && currentMana < maxMana)
        {

            StopCoroutine("CheckForManaLoad");
            StopCoroutine("setToCanBeReloaded");

        }

        */

        //Debug.LogError(canbereloaded);
       




        // TODO check which level player playing, restart inventory to corrent level 
        /*
        if (Input.GetKeyUp(KeyCode.R))
        {
            //player.transform.position = new Vector3(-8.64f, 0f, 0f);
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name, LoadSceneMode.Single);
            Inventory.inventory.Clear();
        }
        */
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
            //Debug.Log("reloadujem neprazdnu manu");
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

        player.transform.position = new Vector2(12.84f, 66.92f);
        vcam.Follow = player.transform;
        isPlayerHide = false;


    }

    public static bool inTaver = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        
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
                //interactionMassage.SetActive(true);
            }


        if (collision.gameObject.CompareTag("MineCartLever"))
        {
            inRangeOfMineCartLever = true;
            //interactionMassage.SetActive(true);
        }



        if (collision.gameObject.CompareTag("NPC"))
        {
            inRangeOfNPC = true;
            interactionMassage.SetActive(true);
        }

        if (collision.gameObject.CompareTag("camera"))
        {
            StartCoroutine(ChangeOrthoSizePirateShip(10f, 2f));
            //vcam.m_Lens.OrthographicSize = 10;
        }

        /*
        if (collision.gameObject.CompareTag("FinalBosscamera"))
        {
            StartCoroutine(ChangeOrthoSizeFinalBoss(8.5f, 2f));
            //vcam.m_Lens.OrthographicSize = 10;
        }
        */
        if (collision.gameObject.CompareTag("Tavern"))
        {
            inTaver = true;
        }

        
        if(collision.gameObject.CompareTag("FirstQuest"))
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




        /*
        if(collision.gameObject.CompareTag("Tnt"))
        {
            inRangeOfTnt = true;
        }
        */


        if (!playerHasCollide) 
        {
            
            if (collision.gameObject.CompareTag("Finish"))
            {
                //level += 1;                
                //SavePlayerData();
                playerHasCollide = true;
                inventory.inventory.Clear();
                //Invoke("noCollide",1);
                 
            }
            if (collision.gameObject.CompareTag("Test"))
            {
                LoadPlayerData();
                Debug.LogError(level);
                //Debug.LogError(hiddenKey);
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
            //level += 1;                
            //SavePlayerData();
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
                //interactionMassage.SetActive(false);
            }

        if (collision.gameObject.CompareTag("MineCartLever"))
        {
            inRangeOfMineCartLever = false;
            //interactionMassage.SetActive(true);
        }

        if (collision.gameObject.CompareTag("NPC"))
        {
            inRangeOfNPC = false;
            interactionMassage.SetActive(false);
        }
        if (collision.gameObject.CompareTag("camera"))
        {
            StartCoroutine(ChangeOrthoSizePirateShip(5.3f, 2f));
            //vcam.m_Lens.OrthographicSize = 5.3f;
        }

        if (collision.gameObject.CompareTag("Tavern"))
        {
            inTaver = false;
        }
        /*
        if (collision.gameObject.CompareTag("Tnt"))
        {
            inRangeOfTnt = false;
        }
        */

        
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

    }

    public float silaOdrazeniaX = 10f;
    public float silaOdrazeniaY = 2f;

    
    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Scene currentScene = SceneManager.GetActiveScene();
        //string sceneName = currentScene.name;

        if (collision.gameObject.CompareTag("Obstacles"))
        {
            

           
                Invoke("setToSpawn",0.1f);

            

        }
        
    }
    
    */

    

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
