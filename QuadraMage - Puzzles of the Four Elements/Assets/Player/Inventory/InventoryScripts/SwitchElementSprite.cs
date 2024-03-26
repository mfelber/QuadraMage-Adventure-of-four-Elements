using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchElementSprite : MonoBehaviour
{

    Inventory inventoryScript;
    public Sprite water, fire, wind,earth;

    
    void Start()
    {


        inventoryScript = FindObjectOfType<Inventory>();

        
        if (inventoryScript.inventory.Count >= 1)
        {
            GetComponent<SpriteRenderer>().sprite = wind;
        }
        
    }

    
    void Update()
    {
        /*
        if (Inventory.inventory.Count >= 1)
        {

            GetComponent<SpriteRenderer>().sprite = wind;

        }
        */


        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "Level1")
        {
            if (inventoryScript.inventory.Count == 1)
            {
                GetComponent<SpriteRenderer>().sprite = wind;
            }

        }


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {

            //TODO pridat podmienky na zmenenie sprite palicky

            if (inventoryScript.inventory.Count >= 1)
            {
                
                GetComponent<SpriteRenderer>().sprite = wind;

            }


        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {

            if (inventoryScript.inventory.Count >= 2)
            {
                
                GetComponent<SpriteRenderer>().sprite = earth;
            }




        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {

            if (inventoryScript.inventory.Count >= 3)
            {
                
                GetComponent<SpriteRenderer>().sprite = water;
            }




        }
        
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (inventoryScript.inventory.Count >= 4)
            {

                GetComponent<SpriteRenderer>().sprite = fire;
            }
        }
        
    }

    
}
