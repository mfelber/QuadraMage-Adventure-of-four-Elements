using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Compilation;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    public static bool onPlatform = false;
    [Serialize] Rigidbody2D Player;


    PlayerMovement playerMovement;

    public Animator animator;

    public static bool isAnimationEnabledRight;

    public static bool isAnimationEnabledLeft;


    private void Start()
    {
        playerMovement = FindAnyObjectByType<PlayerMovement>();    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

         isAnimationEnabledRight = animator.GetBool("IsMovingToRight");
         isAnimationEnabledLeft = animator.GetBool("IsMovingToLeft");
        if (collision.gameObject.CompareTag("Player") || isAnimationEnabledRight == true || isAnimationEnabledLeft == true)
        {
            collision.transform.SetParent(transform);
            //PlayerMovement.isInputEnabled = false;
            //Invoke("set", 3);
        }
                  
       
        
    }


    private void set()
    {
        PlayerMovement.isInputEnabled = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
        
    }

    public void SetMovingToFalse()
    {
        WindCollisionWheel.platformIsMoving = false;
    }

    public void SetMovingToTrue()
    {
        WindCollisionWheel.platformIsMoving = true;
    }

   

}
