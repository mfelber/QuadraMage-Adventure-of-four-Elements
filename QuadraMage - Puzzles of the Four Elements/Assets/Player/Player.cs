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

        quest = 1;
        hiddenKey = 0;

        currentMana = maxMana;
        manaBar.setMaxMana(maxMana);
        rigidbody2D = GetComponent<Rigidbody2D>();
        canbereloaded = false;

        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Elements"));

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
  
    public bool canbereloaded = false;
    public static bool manaIsLoaded = true;

    void Update()
    {
        
        if (ManaBar.isEmpty)
        {
            //Invoke("setManaToMax", 3);
           // StopCoroutine("CheckForManaLoad");
            //StopCoroutine("setToCanBeReloaded");
            //StartCoroutine(setManaTomax());

            StartCoroutine(setToCanBeReloaded());


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
        if (Input.GetKeyUp(KeyCode.R))
        {
            //player.transform.position = new Vector3(-8.64f, 0f, 0f);
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name, LoadSceneMode.Single);
            Inventory.inventory.Clear();
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
            StartCoroutine(ZmenOrthoSizeSmooth(10f, 2f));
            //vcam.m_Lens.OrthographicSize = 10;
        }

        if (collision.gameObject.CompareTag("Tavern"))
        {
            inTaver = true;
        }
        

        

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

    IEnumerator ZmenOrthoSizeSmooth(float novaHodnota, float cas)
    {
        float pociatocnaHodnota = vcam.m_Lens.OrthographicSize;
        float elapsedTime = 0f;

        while (elapsedTime < cas)
        {
            vcam.m_Lens.OrthographicSize = Mathf.Lerp(pociatocnaHodnota, novaHodnota, elapsedTime / cas);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        
        vcam.m_Lens.OrthographicSize = novaHodnota;
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
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
            StartCoroutine(ZmenOrthoSizeSmooth(5.3f, 2f));
            //vcam.m_Lens.OrthographicSize = 5.3f;
        }

        if (collision.gameObject.CompareTag("Tavern"))
        {
            inTaver = false;
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
