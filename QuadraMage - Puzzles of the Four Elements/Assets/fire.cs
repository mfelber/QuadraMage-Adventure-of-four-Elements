using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    public PlayerMovement PlayerMovement;

    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("WindElementShot"))
        {
            Destroy(gameObject);  
        }
    }
    */
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
    }
}
