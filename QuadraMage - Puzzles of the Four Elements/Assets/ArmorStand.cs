using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorStand : MonoBehaviour
{
    public static bool isPlayerMoveWithArmorStand;


    void Start()
    {
        isPlayerMoveWithArmorStand = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            isPlayerMoveWithArmorStand = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerMoveWithArmorStand = false;
        }
    }

    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {           

            isPlayerMoveWithArmorStand = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerMoveWithArmorStand = false;
        }
    }

    */
}
