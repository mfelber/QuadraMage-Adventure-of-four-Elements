using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    public bool IsonPlatformWhileMoving = false;
    public static bool isChildOfPlatform;
    


   

  

    public Animator animator;

    private bool isAnimationEnabledRight;

    private bool isAnimationEnabledLeft;

    public bool playerOnPlatform = false;
    

    public bool movingtoright;
    private bool movingtoleft;
    WindCollisionWheel windCollisionWheel;



    private void Start()
    {
        
        animator = GetComponent<Animator>();
        windCollisionWheel = FindObjectOfType<WindCollisionWheel>();
       
        
    }

   


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") )
        {
            playerOnPlatform = true;
            
        }

        

       

    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
            playerOnPlatform = false;
           
            Debug.LogError("uz neni Player");

        }

        



    }

    private void Update()
    {
       




        isAnimationEnabledRight = animator.GetBool("IsMovingToRight");
        isAnimationEnabledLeft = animator.GetBool("IsMovingToLeft");

        movingtoleft = isAnimationEnabledLeft;
        movingtoright = isAnimationEnabledRight;


       
        

        if(movingtoright)
        {
            windCollisionWheel.rightSail();
        } 

        if (movingtoleft)
        {
            windCollisionWheel.leftSail();
        } 

        

        if (playerOnPlatform && (movingtoright == true || movingtoleft == true))
        {
            
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            
            if (player != null)
            {

                player.transform.SetParent(transform);
                
                IsonPlatformWhileMoving = true;
            }
        } else
        {
            IsonPlatformWhileMoving = false;
            GameObject player = GameObject.FindGameObjectWithTag("Player");
           
            if (player != null && player.transform.parent == transform)
            {
               
                player.transform.SetParent(null);
                
            }
        }




        if (IsonPlatformWhileMoving)
        {
           
            isChildOfPlatform = true;
            
        } else
        {
          
            isChildOfPlatform = false;
           
        }


      
       

    }


    public void flipSailLeft()
    {
        windCollisionWheel.LeftIdle.SetActive(true);
        windCollisionWheel.RightSail.SetActive(false);
    }

    public void flipSailRight()
    {
        windCollisionWheel.RightIdle.SetActive(true);
        windCollisionWheel.LeftSail.SetActive(false);
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
