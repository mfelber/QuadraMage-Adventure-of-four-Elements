using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    public PlayerMovement PlayerMovement;
    public Sprite sleepingDragon, awakeDragon;


    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = sleepingDragon;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            PlayerMovement.HowMuchTimeIsLeft = PlayerMovement.TimeOfKnockBack;
            if (collision.transform.position.x <= transform.position.x)
            {
                PlayerMovement.knockBackFromR = true;
                
            }
            if (collision.transform.position.x > transform.position.x)
            {
                PlayerMovement.knockBackFromR = false;
                
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // maybe call invoke to start animation of opening eyes
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().sprite = awakeDragon;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // maybe call invoke to start animation of closing eyes
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().sprite = sleepingDragon;

        }
    }
}
