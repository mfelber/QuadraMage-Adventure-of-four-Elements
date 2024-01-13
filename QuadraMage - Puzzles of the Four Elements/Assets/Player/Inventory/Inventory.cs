using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour

{


    public int maxMana = 100;
    public int currentMana;
    public ManaBar manaBar;

    WindElement windScript;
    FireElement fireScript;
    WaterElement waterScript;
    EarthElement earthScript;


    public static List<Item.ItemData> inventory = new List<Item.ItemData>();

    private int currentIndex = 0;


    // public GameObject Wind;
    // public float windSpeed;


    public Transform shootpoint;

    PauseMenu pauseMenu;
    PlayerMovement playermovement;

    public GameObject waterball;
    // public GameObject earthball;
    public GameObject fireball;


    public Sprite water, fire, wind;


    //private float timePassed = 0f;
    public float intervalMeziPlnenim = 5f;


    public bool canUseElement = true;
    public float elementCooldown =1;

    void Start()
    {


        currentMana = maxMana;
        manaBar.setMaxMana(maxMana);
        loadElementScripts();
        

        //if player has at least 1 element inventory than update actual element


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

    private bool canSpawnElement = true;

    void Update()
    {

        /*
        if (currentMana < 100)
        {
            Invoke("fillMana", 2);
        } if (currentMana < 75)
        {
            Invoke("fillMana", 2.5f);
        }
        if (currentMana < 50)
        {
            Invoke("fillMana", 2.75f);
        }
        if (currentMana < 25)
        {
            Invoke("fillMana", 3);
        }
        
        
        if(currentMana < maxMana)
        {
            timePassed += Time.deltaTime;
            if(timePassed>= intervalMeziPlnenim)
            {
                fillMana();
                timePassed = 0f;
            }
        }
        */

        if (ManaBar.isEmpty)
        {
            Invoke("setManaToMax", 3);
            
        }
        
        Animator anim = GetComponent<Animator>();
        if (!PauseMenu.isGamePaused)
        {
            if(!PlayerMovement.PlayerIsMoving)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (inventory.Count > 0){
                        
                        if (inventory[currentIndex].itemName.Equals("Wind"))
                        {
                            windScript.createWindElement();
                            useMana(25);

                        }
                        else if (inventory[currentIndex].itemName.Equals("Fire"))
                        {                                                       
                            Debug.LogError(inventory.Count);
                            if (canSpawnElement && !ManaBar.isEmpty)
                            {
                                anim.SetBool("FireBall", true);
                                useMana(25);
                                StartCoroutine(ElementCooldown());
                                Debug.LogError("mas manu");
                            } else
                            {
                                Debug.LogError("uz nemas manu");
                            }
                            

                        }
                        else if (inventory[currentIndex].itemName.Equals("Water"))
                        {
                            anim.SetBool("WaterBall", true);
                            useMana(25);


                        }
                        else if (inventory[currentIndex].itemName.Equals("Earth"))
                        {
                            earthScript.createEarthElement();
                            useMana(25);
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

    IEnumerator ElementCooldown()
    {
        canSpawnElement = false;

        float originalCooldown = elementCooldown;  // Store the original cooldown value
        elementCooldown = 2f;  // Set the desired shorter cooldown value

        yield return new WaitForSeconds(originalCooldown);

        elementCooldown = originalCooldown;  // Restore the original cooldown value
        canSpawnElement = true;
    }



    void setManaToMax()
    {
        currentMana = 100;
        manaBar.setMana(currentMana);
        ManaBar.isEmpty = false;
    }

    void useMana(int mana)
    {
        currentMana -= mana;
        manaBar.setMana(currentMana);
    }

    void fillMana()
    {
        /*
             currentMana += 25;
             manaBar.setMana(currentMana);

             if (currentMana > 0)
         {
             ManaBar.isEmpty = false;
         }
         */

        if (currentMana < 100)
        {
            ManaBar.isEmpty = false;
            currentMana += 25;
            manaBar.setMana(currentMana);
        }
        else
        {
            ManaBar.isEmpty = true;
        }

    }



    public void SpawnWaterElement(Object water)
    {
        // GameObject obj = Instantiate(waterElement, inventoryScript.shootpoint.position, inventoryScript.shootpoint.rotation);
        GameObject obj = GameObject.Instantiate<GameObject>(waterball, shootpoint.position, shootpoint.rotation);
        Destroy(obj, 1);
    }

    public void SpawnFireElement(Object fire)
    {
        // GameObject obj = Instantiate(waterElement, inventoryScript.shootpoint.position, inventoryScript.shootpoint.rotation);
        GameObject obj = GameObject.Instantiate<GameObject>(fireball, shootpoint.position, shootpoint.rotation);
        Destroy(obj, 1);
    }

    public void SwitchTransition(Object nullobj)
    {
        Animator anim = GetComponent<Animator>();
        anim.SetBool("WaterBall", false);
        anim.SetBool("FireBall", false);
    }

    public void loadElementScripts()
    {
        fireScript = GetComponent<FireElement>();
        windScript = GetComponent<WindElement>();
        waterScript = GetComponent<WaterElement>();
        earthScript = GetComponent<EarthElement>();
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
