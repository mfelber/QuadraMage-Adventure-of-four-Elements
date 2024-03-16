using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonScript : MonoBehaviour
{
    public Animator demonAnimator;
    public PlayerMovement PlayerMovement;
    void Start()
    {
        
    }

    
    void Update()
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

        if (collision.gameObject.CompareTag("WindElementShot"))
        {
            demonAnimator.SetBool("windElimination", true);
            Invoke("windEliminationToFalse", 2.2f);
        }

        if (collision.gameObject.CompareTag("Luster"))
        {
            demonAnimator.SetBool("lusterElimin", true);
            
        }

    }

    public void windEliminationToFalse()
    {
        demonAnimator.SetBool("windElimination", false);
    }
}
