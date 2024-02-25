using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightPlatform : MonoBehaviour
{
    public float weight;
    void Start()
    {
        weight = 10;
    }

    public float getWeight
    {
        get { return weight; }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Získání komponenty Rigidbody2D hrá?e
            Rigidbody2D playerRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();

            if (playerRigidbody != null)
            {
                // Získání hmotnosti hrá?e z komponenty Rigidbody2D
                float playerWeight = playerRigidbody.mass;
                weight += playerWeight;
                // Zde m?žete použít hodnotu playerWeight podle pot?eby
                Debug.Log("Hmotnost hrá?e je: " + playerWeight);
            }
            else
            {
                Debug.LogError("Objekt hrá?e neobsahuje komponentu Rigidbody2D.");
            }
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Získání komponenty Rigidbody2D hrá?e
            Rigidbody2D playerRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();

            if (playerRigidbody != null)
            {
                // Získání hmotnosti hrá?e z komponenty Rigidbody2D
                float playerWeight = playerRigidbody.mass;
                weight -= playerWeight;
                // Zde m?žete použít hodnotu playerWeight podle pot?eby
                Debug.Log("Hmotnost hrá?e je: " + playerWeight);
            }
            else
            {
                Debug.LogError("Objekt hrá?e neobsahuje komponentu Rigidbody2D.");
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
