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
            // Z�sk�n� komponenty Rigidbody2D hr�?e
            Rigidbody2D playerRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();

            if (playerRigidbody != null)
            {
                // Z�sk�n� hmotnosti hr�?e z komponenty Rigidbody2D
                float playerWeight = playerRigidbody.mass;
                weight += playerWeight;
                // Zde m?�ete pou��t hodnotu playerWeight podle pot?eby
                Debug.Log("Hmotnost hr�?e je: " + playerWeight);
            }
            else
            {
                Debug.LogError("Objekt hr�?e neobsahuje komponentu Rigidbody2D.");
            }
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Z�sk�n� komponenty Rigidbody2D hr�?e
            Rigidbody2D playerRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();

            if (playerRigidbody != null)
            {
                // Z�sk�n� hmotnosti hr�?e z komponenty Rigidbody2D
                float playerWeight = playerRigidbody.mass;
                weight -= playerWeight;
                // Zde m?�ete pou��t hodnotu playerWeight podle pot?eby
                Debug.Log("Hmotnost hr�?e je: " + playerWeight);
            }
            else
            {
                Debug.LogError("Objekt hr�?e neobsahuje komponentu Rigidbody2D.");
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
