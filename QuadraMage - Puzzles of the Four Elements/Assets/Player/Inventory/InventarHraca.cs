using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventarHraca : MonoBehaviour
{
    private Inventar inventarHraca;


    private void Start()
    {
        inventarHraca = GetComponent<Inventar>(); // Z�ska referenciu na skript Inventar pripojen� k hr�?ovi

        if (inventarHraca == null)
        {
            Debug.LogError("Script Inventory is not set to Player");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wind")|| other.CompareTag("Fire") || other.CompareTag("Water") || other.CompareTag("Earth") || other.CompareTag("Elemental"))
        {

            Item.ItemData itemData = other.GetComponent<Item>().itemData;
            inventarHraca.PridatDoInventara(itemData);
            Destroy(other.gameObject);
            
        }
    }
}