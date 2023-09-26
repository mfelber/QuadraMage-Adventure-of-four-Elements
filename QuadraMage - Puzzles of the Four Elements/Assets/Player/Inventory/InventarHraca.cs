using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventarHraca : MonoBehaviour
{
    private Inventar inventarHraca;


    private void Start()
    {
        inventarHraca = GetComponent<Inventar>(); // Získa referenciu na skript Inventar pripojený k hrá?ovi

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