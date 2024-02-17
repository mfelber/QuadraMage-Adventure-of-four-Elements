using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
    
{
    private Inventory inventory;
    
    
    void Start()
    {
        inventory = GetComponent<Inventory>(); 

        if (inventory == null)
        {
            Debug.LogError("Script Inventory is not set to Player");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wind") || other.CompareTag("Fire") || other.CompareTag("Water") || other.CompareTag("Earth"))
        {

            Item.ItemData itemData = other.GetComponent<Item>().itemData;
            inventory.addToInventory(itemData);
            Destroy(other.gameObject);

        }
    }
}
