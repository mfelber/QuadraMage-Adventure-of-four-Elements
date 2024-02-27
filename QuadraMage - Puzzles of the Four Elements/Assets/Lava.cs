using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public float weight;
    void Start()
    {
        weight = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float getWeight
    {
        get { return weight; }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") )
        {
            // Získání komponenty Rigidbody2D hrá?e
            Rigidbody2D playerRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            //player.transform.SetParent(transform);

            if (playerRigidbody != null)
            {
                // Získání hmotnosti hrá?e z komponenty Rigidbody2D
                float playerWeight = playerRigidbody.mass;
               
                weight += playerWeight;
               // Zde m?žete použít hodnotu playerWeight podle pot?eby
               Debug.Log("Hmotnost hrá?e je: " + playerWeight);
            }
            
        }

        if (collision.gameObject.CompareTag("Gold"))
        {
            Rigidbody2D gold = collision.gameObject.GetComponent<Rigidbody2D>();
            if(gold != null)
            {
                float boxweight = gold.mass;
                weight += boxweight;
                Debug.Log("Hmotnost boxu je: " + boxweight);
            }
        }
        if (collision.gameObject.CompareTag("Box"))
        {
            Rigidbody2D box = collision.gameObject.GetComponent<Rigidbody2D>();
            if (box != null)
            {
                float boxweight = box.mass;
                weight += boxweight;
                Debug.Log("Hmotnost boxu je: " + boxweight);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            
            //player.transform.SetParent(transform);
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
            
        }

        if (collision.gameObject.CompareTag("Gold"))
        {
            GameObject gold = GameObject.FindGameObjectWithTag("Gold");
            Rigidbody2D goldBox = collision.gameObject.GetComponent<Rigidbody2D>();

           // box.transform.SetParent(transform);

            if (goldBox != null)
            {
                // Získání hmotnosti hrá?e z komponenty Rigidbody2D
                
                float goldWeight = goldBox.mass;
                weight -= goldWeight;
                // Zde m?žete použít hodnotu playerWeight podle pot?eby
                Debug.Log("Hmotnost boxu je: " + goldWeight);
            }
        }


        if (collision.gameObject.CompareTag("Box"))
        {
            GameObject box = GameObject.FindGameObjectWithTag("Box");
            Rigidbody2D boxRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();

            // box.transform.SetParent(transform);

            if (boxRigidbody != null)
            {
                // Získání hmotnosti hrá?e z komponenty Rigidbody2D

                float boxweight = boxRigidbody.mass;
                weight -= boxweight;
                // Zde m?žete použít hodnotu playerWeight podle pot?eby
                Debug.Log("Hmotnost boxu je: " + boxweight);
            }
        }
    }
}
