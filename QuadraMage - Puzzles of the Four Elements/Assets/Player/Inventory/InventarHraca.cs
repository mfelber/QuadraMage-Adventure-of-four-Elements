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
            Debug.LogError("Skript Inventar nie je priraden� alebo nie je inicializovan� na GameObjecte hr�?a.");
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