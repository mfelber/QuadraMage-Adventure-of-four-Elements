using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    public PlayerMovement PlayerMovement;
    private Animator animator;  

   

    private void Start()
    {
       
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
        if (collision.gameObject.CompareTag("WaterElementShot"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject); 
        }
        if (collision.gameObject.CompareTag("Water"))
        {
            Destroy(gameObject, 0.5f);
        }
    }
}
