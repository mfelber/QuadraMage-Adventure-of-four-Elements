using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    public PlayerMovement PlayerMovement;
    public Sprite sleepingDragon, deadDragon;
    public int maxDragonhealth = 100;
    public int currentHealth;
    public DragonHealthBar healthBar;
    public GameObject health;

    private void Start()
    {
        //GetComponent<SpriteRenderer>().sprite = sleepingDragon;
        currentHealth = maxDragonhealth;
        healthBar.setMaxHealth(maxDragonhealth);
        health.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("kolizia");
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

        if (collision.gameObject.CompareTag("Tnt"))
        {
            health.SetActive(true);
            Destroy(collision.gameObject);
            takeDamage(25);
        }
    }

    private void Update()
    {
        if (currentHealth == 0)
        {
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Dragon"), true);
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("item"), LayerMask.NameToLayer("Dragon"), true);

        } else
        {
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Dragon"), false);
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("item"), LayerMask.NameToLayer("Dragon"), false);
        }
    }


    public void takeDamage (int value)
    {
        currentHealth -= value;
        healthBar.setHealth(currentHealth);
    }

    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // maybe call invoke to start animation of opening eyes
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().sprite = awakeDragon;

        }
    }
    */

    /*
    private void OnTriggerExit2D(Collider2D collision)
    {
        // maybe call invoke to start animation of closing eyes
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().sprite = sleepingDragon;

        }
    }
    */
}
