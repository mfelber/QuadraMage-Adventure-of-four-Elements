using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementImpact : MonoBehaviour
{
    public GameObject squarePrefab;
   // public Vector2 spawnOffset = new Vector2(0f, 10f);
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) 
        {
            //SpawnSquare(collision.contacts[0].point + spawnOffset);
            SpawnSquare(collision.contacts[0].point);
        }
    }

    void SpawnSquare(Vector2 position)
    {
        Instantiate(squarePrefab, position, Quaternion.identity);
    }
}
