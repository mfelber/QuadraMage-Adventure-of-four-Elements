using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinallBoss : MonoBehaviour
{
    //public List<GameObject> gameObjects = new List<GameObject>();
    public bool playerInrange;
    public BoxCollider2D collider;
    void Start()
    {
        playerInrange = false;
        /*
        for (int i = 0; i < gameObjects.Count; i++)
        {
            gameObjects[i].SetActive(false);
        }
        */
        collider = GetComponent<BoxCollider2D>();
        collider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInrange)
        {
            collider.enabled = true;
          //  for (int i = 0; i < gameObjects.Count; i++)
          //  {
              //  gameObjects[i].SetActive(true);
        //    }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInrange = true;
        }
    }
}
