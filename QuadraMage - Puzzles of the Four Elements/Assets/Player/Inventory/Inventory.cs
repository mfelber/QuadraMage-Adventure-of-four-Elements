using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour

{


    WindElement windScript;
    FireElement fireScript;
    WaterElement waterScript;
    EarthElement earthScript;

    public List<Item.ItemData> inventory = new List<Item.ItemData>();

    private int currentIndex = 0;
   

    public GameObject Wind;
    public float windSpeed;

 
    public Transform shootpoint;

    PauseMenu pauseMenu;

    void Start()
    {

        loadElementScripts();        
       
        //if player has at least 1 element inventory than update actual element
        if (inventory.Count > 0)
        {
            updateActualElement();
        }
    }

    void Update()
    {
        if (!PauseMenu.isGamePaused)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (inventory.Count > 0)
                {
                    if (inventory[currentIndex].itemName.Equals("Wind"))
                    {
                        windScript.createWindElement();
                    }
                    else if (inventory[currentIndex].itemName.Equals("Fire"))
                    {
                        fireScript.createFireElement();
                    }
                    else if (inventory[currentIndex].itemName.Equals("Water"))
                    {
                        waterScript.createWaterElement();
                    }
                    else if (inventory[currentIndex].itemName.Equals("Earth"))
                    {
                        earthScript.createEarthElement();
                    }

                }
                else
                {
                    Debug.Log("Inventory is mpty you cant shoot");
                }
            }



            if (Input.GetKeyDown(KeyCode.Alpha1))
            {

                //TODO pridat podmienky na zmenenie sprite palicky


                changeElement(0); // parameter for function changeElement is index of list
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

        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("este si neziskal ohnivy element");
        }

        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("este si neziskal vodny element");
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
