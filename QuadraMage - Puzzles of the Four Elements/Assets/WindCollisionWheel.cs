using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindCollisionWheel : MonoBehaviour
{
    public Animator anim;
    public static bool platformIsMoving = false;
   
    public float posxLeft1;
    public float posxRight2;
    public float posxLeft2;

    [SerializeField]private float posxRight1;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("WindElementShot") && !platformIsMoving)
        {
            Debug.LogError("trafil si ");

           
                platformIsMoving = true;

                float xPosition = anim.transform.position.x;

                if (xPosition >= posxRight1 && xPosition <= posxRight2)
                {
                    MoveToRight();
                    /*
                    anim.SetBool("IsMovingToRight", true);                    
                    anim.SetBool("IsMovingToLeft", false);
                    Debug.LogError("Moving to the right!");
                    Invoke("setmovingtofalse", 2);
                    */
                    //Debug.LogError(moving);

                }
                else if (xPosition >= posxLeft1 && xPosition <= posxLeft2)
                {
                    MoveToLeft();
                    /*
                    anim.SetBool("IsMovingToLeft", true);                    
                    anim.SetBool("IsMovingToRight", false);
                    Debug.LogError("Moving to the left!");
                    */
                    //Debug.LogError(moving);
                }
            
          
            

           
        }
       
    }

    
    private void MoveToRight()
    {
        anim.SetBool("IsMovingToRight", true);
        //anim.SetBool("IsMovingToLeft", false);
        //Debug.LogError("Moving to the right!");
        
        // Set moving to false after 2 seconds

    }

    private void MoveToLeft()
    {
        anim.SetBool("IsMovingToLeft", true);
        //anim.SetBool("IsMovingToRight", false);
        //Debug.LogError("Moving to the left!");
    }

    

    private void Start()
    {
        platformIsMoving=false;
    }

    public void SetMovingToFalse()
    {
        platformIsMoving = false;
        anim.SetBool("IsMovingToLeft", false);
        anim.SetBool("IsMovingToRight", false);
    }

    /*
    private void Update()
    {

        

        if (platformIsMoving)
        {
            // Check the current playing animations
           // AnimatorClipInfo[] clipInfo = anim.GetCurrentAnimatorClipInfo(0);

            // Check if there's any clip info
            if (clipInfo.Length > 0)
            {
                // Iterate through each clip and print information to the console
                foreach (AnimatorClipInfo info in clipInfo)
                {
                    string currentAnimationName = info.clip.name;

                    //Debug.Log("Current Animation: " + currentAnimationName);

                    // Example: Check if a specific animation is playing
                    if (currentAnimationName == "MovingPlatformToLeft")
                    {
                        //Debug.LogError("si v default");
                        
                        //Invoke("SetMovingToFalse", 2);
                        //platformIsMoving = false;
                       

                    }
                   
                    

                }
            }



        }


      
    }
    */
   

}
