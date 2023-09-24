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
            Debug.LogError("Skript Inventar nie je priradený alebo nie je inicializovaný na GameObjecte hrá?a.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Polozka"))
        {

            Item.ItemData itemData = other.GetComponent<Item>().itemData;
            inventarHraca.PridatDoInventara(itemData);
            Destroy(other.gameObject);
            
        }
    }
}