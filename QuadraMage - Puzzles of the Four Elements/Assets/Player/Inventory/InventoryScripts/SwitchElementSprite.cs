using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchElementSprite : MonoBehaviour
{

    Inventory inventoryScript;
    public Sprite water, fire, wind,earth;

    
    void Start()
    {


        inventoryScript = GetComponent<Inventory>();
        //Debug.LogError(Inventory.inventory.Count);
        


    }

    
    void Update()
    {
        /*
        if (Inventory.inventory.Count >= 1)
        {

            GetComponent<SpriteRenderer>().sprite = wind;

        }
        */
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {

            //TODO pridat podmienky na zmenenie sprite palicky

            if (Inventory.inventory.Count >= 1)
            {
                
                GetComponent<SpriteRenderer>().sprite = wind;

            }


        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {

            //changeElement(1);
            if (Inventory.inventory.Count >= 2)
            {
                
                GetComponent<SpriteRenderer>().sprite = water;
            }




        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {

            if (Inventory.inventory.Count >= 3)
            {
                //Debug.Log(inventory.Count);
                
                GetComponent<SpriteRenderer>().sprite = fire;
            }




        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            
        }
    }

    
}
