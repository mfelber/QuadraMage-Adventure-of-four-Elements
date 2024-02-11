using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    public static bool onPlatform = false;
    


   

  

    public Animator animator;

    private bool isAnimationEnabledRight;

    private bool isAnimationEnabledLeft;

    private bool playerOnPlatform = false;




    private void Start()
    {
        
        animator = GetComponent<Animator>();
        playerOnPlatform = false;
        
    }

    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {

         isAnimationEnabledRight = animator.GetBool("IsMovingToRight");
         isAnimationEnabledLeft = animator.GetBool("IsMovingToLeft");
        if (collision.gameObject.CompareTag("Player") && (isAnimationEnabledRight == true || isAnimationEnabledLeft == true))
        {
            collision.transform.SetParent(transform);
            
           
            //PlayerMovement.isInputEnabled = false;
            //Invoke("set", 3);
        }
        


    }

    */

    public bool movingtoright;
    public bool movingtoleft;


    /*
    private void OnTriggerEnter2D(Collider2D other)
    {
        isAnimationEnabledRight = animator.GetBool("IsMovingToRight");
        isAnimationEnabledLeft = animator.GetBool("IsMovingToLeft");

        //Debug.LogError("idem do lava state =" + isAnimationEnabledLeft);
        //Debug.LogError("idem do prava state =" + isAnimationEnabledRight);

        if (other.gameObject.CompareTag("Player") && (movingtoright == true || movingtoleft == true))
        {
            Debug.LogError("Collision with Player detected and AnimationEnabled");
            other.transform.SetParent(transform);
        }
    }
    */


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOnPlatform = true;
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {

        playerOnPlatform = false;
            collision.transform.SetParent(null);
           
        
        
        
    }

    private void Update()
    {
       

        isAnimationEnabledRight = animator.GetBool("IsMovingToRight");
        isAnimationEnabledLeft = animator.GetBool("IsMovingToLeft");

        movingtoleft = isAnimationEnabledLeft;
        movingtoright = isAnimationEnabledRight;

       // Debug.LogError(movingtoright);
      //  Debug.LogError(movingtoleft);

        //Debug.LogError("idem do lava state =" + isAnimationEnabledLeft);
        //Debug.LogError("idem do prava state =" + isAnimationEnabledRight);


        if (playerOnPlatform &&( movingtoright == true || movingtoleft == true))
        {
            Debug.LogError("Animation is going");
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {

                player.transform.SetParent(transform);
            }
        } else
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null && player.transform.parent == transform)
            {
                player.transform.SetParent(null);
            }
        }

    }


    public void SetMovingToFalse()
    {
        WindCollisionWheel.platformIsMoving = false;
    }

    public void SetMovingToTrue()
    {
        WindCollisionWheel.platformIsMoving = true;
    }
    
    public void setMovingToRightToFalse()
    {
        animator.SetBool("IsMovingToRight", false);
    }

    public void setMovingToLeftToFalse()
    {
        animator.SetBool("IsMovingToLeft", false);
    }



}
