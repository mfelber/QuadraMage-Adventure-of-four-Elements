using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour

{

    public GameObject mana;
    //public int maxMana = 100;
    //public int currentMana;
    // public ManaBar manaBar;
    //public Player player;

    Player player;
   
    public static List<Item.ItemData> inventory = new List<Item.ItemData>();

    private int currentIndex = 0;


   public Transform shootpoint;

    PauseMenu pauseMenu;
    PlayerMovement playermovement;

    public GameObject windball;

    public GameObject waterball;    
    public GameObject fireball;
    public GameObject earthball;

    
    
    public static bool isPlayerUsingElement;    
    public static bool canUseElement = true;

    

    void Start()
    {

        mana.SetActive(false);
        //currentMana = maxMana;
       // manaBar.setMaxMana(maxMana);
        
        //if player has at least 1 element inventory than update actual element

        player = GetComponent<Player>();

        if (inventory.Count > 0)
        {
            updateActualElement();
        }

        if (waterball == null)
        {
            Debug.LogError("nemas prefab");
        }
        if (fireball == null)
        {
            Debug.LogError("nemas prefab fire ball");
        }


    }

    public void playerUsingElement()
    {
        isPlayerUsingElement = true;    
    }
    public void playerStopUsingElement()
    {
        isPlayerUsingElement = false;
    }



    void Update()
    {      
        
        /*

        if (ManaBar.isEmpty)
        {
            Invoke("setManaToMax", 3);
            
        }

        if (Player.currentMana > 100)
        {
            manaBar.setMana(100);
        }
        */

        /*
        else if (currentMana == 75)
        {
            manaBar.setMana(100);
            currentMana = 100;
        }
        else if (currentMana == 50)
        {
            manaBar.setMana(75);
            currentMana = 75;
        }
        else if (currentMana == 25)
        {
            manaBar.setMana(50);
            currentMana = 50;
        }
        */
        Animator anim = GetComponent<Animator>();
        if (!PauseMenu.isGamePaused && !Book.isBookOpen)
        {
            if(!PlayerMovement.PlayerIsMoving)
            {
                if (inventory.Count > 0) {
                    mana.SetActive(true);
                    updateActualElement();
                }                
                if (Input.GetMouseButtonDown(0))
                {

                    if (inventory.Count > 0){
                        
                        if (inventory[currentIndex].itemName.Equals("Wind"))
                        {
                            
                            if(canUseElement == true && !ManaBar.isEmpty && PlayerMovement.playerOnGround == true)
                            {
                                anim.SetBool("WindBall", true);
                                player.useMana(25);
                                Debug.LogError("pouzil si wind");
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
                            if (canUseElement == true && !ManaBar.isEmpty && PlayerMovement.playerOnGround == true)
                            {

                                anim.SetBool("WaterBall", true);
                                //useMana(25);
                                player.useMana(25);
                                Debug.LogError("pouzil si water");
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
                            if (canUseElement == true && !ManaBar.isEmpty && PlayerMovement.playerOnGround == true)
                            {

                                anim.SetBool("FireBall", true);
                                player.useMana(25);
                                Debug.LogError("pouzil si fire");
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
                            if (canUseElement == true && !ManaBar.isEmpty && PlayerMovement.playerOnGround == true)
                            {

                                anim.SetBool("EarthBall", true);                                
                                player.useMana(25);
                                Debug.LogError("pouzil si earth");
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

    void setManaToMax()
    {
        if(Player.currentMana == 0)
        {
            Player.currentMana = 100;
            manaBar.setMana(Player.currentMana);
            ManaBar.isEmpty = false;
        }
       
    }

    void useMana(int mana)
    {
        Player.currentMana -= mana;
        manaBar.setMana(Player.currentMana);
    }

    */

    public void SpawnWaterElement(Object water)
    {
        
        GameObject obj = GameObject.Instantiate<GameObject>(waterball, shootpoint.position, shootpoint.rotation);
        Destroy(obj, 1);
        StartCoroutine(CheckIfElementDestroyed(obj));
        Invoke("playerStopUsingElement", 0.3f);
    }

    public void SpawnFireElement(Object fire)
    {
       
        GameObject obj = GameObject.Instantiate<GameObject>(fireball, shootpoint.position, shootpoint.rotation);
        Destroy(obj, 1);
        StartCoroutine(CheckIfElementDestroyed(obj));
        Invoke("playerStopUsingElement", 0.3f);
        
    }

    IEnumerator CheckIfElementDestroyed(GameObject element)
    {
        yield return new WaitForSeconds(1);

        
        if (element == null)
        {
            canUseElement = true;
            
        }
        else
        {
            canUseElement = false;
        }

        
        
    }

    public void SwitchTransition(Object nullobj)
    {
        Animator anim = GetComponent<Animator>();
        //anim.SetBool("WindBall", false);
        anim.SetBool("WaterBall", false);
        anim.SetBool("FireBall", false);
       //anim.SetBool("EarthBall", false);
    }

    public void addToInventory(Item.ItemData itemData)
    {
        inventory.Add(itemData);
        Debug.Log("Element " + itemData.itemName + " is added to your inventory");

    }

    public void changeElement(int index)
    {
        if (index >= 0 && index < inventory.Count)
        {
            currentIndex = index;
            updateActualElement();

        }

        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("este si neziskal vzdusny element");
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("este si neziskal vodny element");
        }

        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("este si neziskal ohnivy element");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Debug.Log("este si neziskal zemny element");
        }


    }

    private void updateActualElement()
    {

        Debug.Log("You are using : " + inventory[currentIndex].itemName);



    }
}
