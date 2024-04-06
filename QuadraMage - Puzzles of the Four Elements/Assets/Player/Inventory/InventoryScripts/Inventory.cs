using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour

{
    PauseMenu pauseMenu;
    NewPauseMenu newPauseMenu;
    PlayerMovement playermovement; 
    PoseidonQuestManager poseidonQuestManager;

    Player player;
   
    public List<Item.ItemData> inventory = new List<Item.ItemData>();

    private int currentIndex = 0;


   public Transform shootpoint;

    public GameObject mana;
    public GameObject Wind;
    public GameObject Waterball;    
    public GameObject Fireball;
    public GameObject Earth;

    
    
    public static bool isPlayerUsingElement;    
    public static bool canUseElement = true;

    public bool playerNotUsingElement;

    void Start()
    {
        

        mana.SetActive(false);

        player = GetComponent<Player>();

        if (inventory.Count > 0)
        {
           // updateActualElement();
        }

        if (Waterball == null)
        {
            Debug.LogError("nemas prefab");
        }
        if (Fireball == null)
        {
            Debug.LogError("nemas prefab fire ball");
        }

        playermovement = FindObjectOfType<PlayerMovement>();


        string sceneName = SceneManager.GetActiveScene().name;

        
        if (sceneName == "Level2")
        {
            Item.ItemData wind = new Item.ItemData();
            wind.itemName = "Wind";
            inventory.Add(wind);           

        }
        
        if (sceneName == "Level3")
        {
            poseidonQuestManager = FindObjectOfType<PoseidonQuestManager>();
            Item.ItemData wind = new Item.ItemData();
            Item.ItemData earth = new Item.ItemData();
            wind.itemName = "Wind";
            earth.itemName = "Earth";
            inventory.Add(wind);
            inventory.Add(earth);

        }

        if (sceneName == "Level4")
        {
            Item.ItemData wind = new Item.ItemData();
            Item.ItemData earth = new Item.ItemData();
            Item.ItemData water = new Item.ItemData();
            
            wind.itemName = "Wind";
            earth.itemName = "Earth";
            water.itemName = "Water";
            
            inventory.Add(wind);
            inventory.Add(earth);
            inventory.Add(water);
            



        }

    }

    
    

    void Update()
    {

        string sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == "Level3")
        {
            if (poseidonQuestManager.acceptSaveMarmaid)
            {
                Item.ItemData water = new Item.ItemData();
                water.itemName = "Water";
                inventory.Add(water);
            }           

        }

        //Debug.Log( "Can use elemnt :" + canUseElement);
        Animator anim = GetComponent<Animator>();
        if (!NewPauseMenu.isPauseMenuOpen && !Book.isBookOpen && !MovingPlatform.isChildOfPlatform)
        {
            if(!PlayerMovement.PlayerIsMoving)
            {
                if (inventory.Count > 0) {
                    mana.SetActive(true);
                    //updateActualElement();
                }                
                if (Input.GetMouseButtonDown(0))
                {

                    if (inventory.Count > 0){
                        
                        if (inventory[currentIndex].itemName.Equals("Wind"))
                        {

                            if (canUseElement == true && !ManaBar.isEmpty && playermovement.isGrounded() == true && Player.manaIsLoaded == true && Player.inBulding == false && PlayerMovement.isInputEnabled == true && !DialogManager.isDialgueActive)
                            {
                                Debug.LogError(inventory.Count);
                                anim.SetBool("Wind", true);
                                player.useMana(25);
                               // Debug.LogError("pouzil si wind");
                                playerUsingElement();
                                canUseElement = false;
                            }  else if (ManaBar.isEmpty)
                            {
                                Debug.LogError("uz nemas manu");
                            }
                            

                        }
                        else if (inventory[currentIndex].itemName.Equals("Water"))
                        {                                                       
                            Debug.LogError(inventory.Count);
                            if (canUseElement == true && !ManaBar.isEmpty && playermovement.isGrounded() == true && Player.manaIsLoaded == true && Player.inBulding == false && PlayerMovement.isInputEnabled == true && !DialogManager.isDialgueActive)
                            {

                                anim.SetBool("WaterBall", true);
                                //useMana(25);
                                player.useMana(25);
                                
                                playerUsingElement();
                                canUseElement = false;
                            } else if (ManaBar.isEmpty)
                            {
                                Debug.LogError("uz nemas manu");
                            }                           

                        }
                        else if (inventory[currentIndex].itemName.Equals("Fire"))
                        {

                            Debug.LogError(inventory.Count);
                            if (canUseElement == true && !ManaBar.isEmpty && playermovement.isGrounded() == true && Player.manaIsLoaded == true && Player.inBulding == false && PlayerMovement.isInputEnabled == true && !DialogManager.isDialgueActive)
                            {

                                anim.SetBool("FireBall", true);
                                player.useMana(25);
                                
                                playerUsingElement();
                                canUseElement = false;
                            }
                            else if (ManaBar.isEmpty)
                            {
                                Debug.LogError("uz nemas manu");
                            }                           

                        }
                        else if (inventory[currentIndex].itemName.Equals("Earth"))
                        {
                            Debug.LogError(inventory.Count);
                            if (canUseElement == true && !ManaBar.isEmpty && playermovement.isGrounded() == true && Player.manaIsLoaded == true && Player.inBulding == false && PlayerMovement.isInputEnabled == true && !DialogManager.isDialgueActive)
                            {

                                anim.SetBool("Earth", true);                                
                                player.useMana(25);
                               
                                playerUsingElement();
                                canUseElement = false;
                            }
                            else if (ManaBar.isEmpty)
                            {
                                Debug.LogError("uz nemas manu");
                            }

                        }

                    }
                    else
                    {
                        Debug.Log("Inventory is empty you cant shoot");
                    }
                }
            }
            

            
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {

                changeElement(0);


            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {

                changeElement(1);

            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {

                changeElement(2);

            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                changeElement(3);
            }
            
        }
    }

    

    

    

    /*
    void useMana(int mana)
    {
        Player.currentMana -= mana;
        manaBar.setMana(Player.currentMana);
    }

    */

    public void SpawnWindElement( Object windElement)
    {
        GameObject wind = GameObject.Instantiate<GameObject>(Wind, shootpoint.position, shootpoint.rotation);
        Destroy(wind, 1);
        StopAllCoroutines();
        StartCoroutine(CheckIfElementDestroyed(wind));
        StartCoroutine(playerStopUsingElement());
       // Invoke("playerStopUsingElement", 0.3f);
    }

    public void SpawnWaterElement(Object waterElement)
    {             
         GameObject water = GameObject.Instantiate<GameObject>(Waterball, shootpoint.position, shootpoint.rotation);
         Destroy(water, 1f);
        StopAllCoroutines();
        StartCoroutine(CheckIfElementDestroyed(water));
        StartCoroutine(playerStopUsingElement());
       // Invoke("playerStopUsingElement", 0.3f);
        
    }

    public void SpawnFireElement(Object fireElement)
    {       
        GameObject fire = GameObject.Instantiate<GameObject>(Fireball, shootpoint.position, shootpoint.rotation);
        Destroy(fire, 1);
       // StopAllCoroutines();
        StartCoroutine(CheckIfElementDestroyed(fire));
        StartCoroutine(playerStopUsingElement());
      //  Invoke("playerStopUsingElement", 0.3f);
        
    }

    public void SpawnEarthElement(Object fireElement)
    {
        GameObject fire = GameObject.Instantiate<GameObject>(Earth, shootpoint.position, shootpoint.rotation);
        Destroy(fire, 1);
        // StopAllCoroutines();
        StartCoroutine(CheckIfElementDestroyed(fire));
        StartCoroutine(playerStopUsingElement());
        //  Invoke("playerStopUsingElement", 0.3f);

    }

    public void SwitchTransitionWind(Object nullobj)
    {
        Animator anim = GetComponent<Animator>();
        anim.SetBool("Wind", false);
       
    }
    public void SwitchTransitionWaterBall(Object nullobj)
    {
        Animator anim = GetComponent<Animator>();     
        anim.SetBool("WaterBall", false);
        
    }

    public void SwitchTransitionFireBall(Object nullobj)
    {
        Animator anim = GetComponent<Animator>();        
        anim.SetBool("FireBall", false);
        
    }

    public void SwitchTransitionEarth(Object nullobj)
    {
        Animator anim = GetComponent<Animator>();
        anim.SetBool("Earth", false);

    }


    IEnumerator playerStopUsingElement()
    {
        
        yield return new WaitForSeconds(0.3f);

        isPlayerUsingElement = false;

    }

    IEnumerator CheckIfElementDestroyed(GameObject element)
    {

        yield return new WaitForSeconds(1f);
        
        if (element == null)
        {
            canUseElement = true;
            
        }
        else
        {
            canUseElement = false;
        }
                
        
    }

   

    public void addToInventory(Item.ItemData itemData)
    {
        inventory.Add(itemData);
       // Debug.Log("Element " + itemData.itemName + " is added to your inventory");
      //  Debug.Log(inventory.Count);

    }

    public void changeElement(int index)
    {
        if (index >= 0 && index < inventory.Count)
        {
            currentIndex = index;
            //updateActualElement();

        }

        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("este si neziskal vzdusny element");
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("este si neziskal zemny element");
           
        }

        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("este si neziskal vodny element");
            
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Debug.Log("este si neziskal ohnivy element");
        }


    }

    /*
    private void updateActualElement()
    {

        Debug.Log("You are using : " + inventory[currentIndex].itemName);



    }
    */


    public void playerUsingElement()
    {
        isPlayerUsingElement = true;
       }

    /*
    public void playerStopUsingElement()
    {
        isPlayerUsingElement = false;
        
    }
    */
}
