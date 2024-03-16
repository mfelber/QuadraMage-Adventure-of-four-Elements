using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lavaGuard : MonoBehaviour
{
    public Sprite dead;

    public PlayerMovement PlayerMovement;
    private bool isHit = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isHit)
        {
            //specialGuardAnimator.enabled = false;
            GetComponent<SpriteRenderer>().sprite = dead;
            Physics2D.IgnoreLayerCollision(6, 7);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Luster"))
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("WindElementShot"))
        {
            //specialGuardAnimator.SetBool("hit", true);
            Destroy(collision.gameObject);
        }

        //waterElementShot
        if (collision.gameObject.CompareTag("WaterElementShot"))
        {
            //specialGuardAnimator.SetBool("hit", true);
            isHit = true;
        }

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
}
