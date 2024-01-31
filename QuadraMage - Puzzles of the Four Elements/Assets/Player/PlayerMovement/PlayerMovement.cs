using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{

    PauseMenu pauseMenu;
    NewPauseMenu newPauseMenu;
    Book book;
    Inventory inventory;
    

    [Serialize] Rigidbody2D Player;    
    
    private Animator animator;
    

    [Serialize] private float playerMove = 0f;
    [Serialize] public float jumpHeight = 7f;
    [Serialize] public float playerSpeed = 3.5f;

   
    public static bool playerOnGround = true;

    bool playerFacingRight = true;

    public static bool PlayerIsMoving;

    private enum PlayerMovementStates { idle, running, jumping , falling}
    

    

    private void Start()
    {
        
        Player = GetComponent<Rigidbody2D>();
        
        animator = GetComponent<Animator>();
    }


    public void playerIsMoving()
    {
        
        PlayerIsMoving = true;
    }

    public void playerIsNotMoving()
    {
        PlayerIsMoving = false;
    }


   
    void Update()
    {
        if (!NewPauseMenu.isPauseMenuOpen && !Book.isBookOpen)
        {
            Vector3 mouseP = Camera.main.ScreenToWorldPoint(Input.mousePosition);

           
            if (!Inventory.isPlayerUsingElement) 
            {
            playerMove = Input.GetAxisRaw("Horizontal");

                if (playerMove == 0f)
                {
                    animator.SetBool("isRunning", false);
                }

            if (playerMove > 0 || playerMove < 0)
            {
                playerIsMoving();
                    animator.SetBool("isRunning", true);
            } else
            {
                playerIsNotMoving();
                
            }
            Player.velocity = new Vector2(playerMove * playerSpeed , Player.velocity.y);

            if (Input.GetButtonDown("Jump") && playerOnGround)
            {
                    animator.SetBool("isJumping", true);
               // animator.SetBool("running", false);
                Player.velocity = new Vector2(Player.velocity.x, jumpHeight );
                playerOnGround = false;
                
            } else
                {
                    animator.SetBool("isJumping", false);
                }
           


            if (mouseP.x < Player.transform.position.x && playerFacingRight)
            {
                flip();


            }
            else if (mouseP.x > Player.transform.position.x && !playerFacingRight)
            {
                flip();

            }
            }



        }
            UpdateAnimation();

        /*
        if (PauseMenu.isGamePaused == true && playerOnGround == false)
        {

        }
       
        */

    }

  



    private void UpdateAnimation()
    {
        float verticalVelocity = Player.velocity.y;
        PlayerMovementStates state;

      
            if (playerOnGround)
            {
                if (Mathf.Abs(playerMove) > 0.1f)
                {
                    state = PlayerMovementStates.running;
                }
                else
                {
                    state = PlayerMovementStates.idle;
                }

            }
            else
            {
                if (verticalVelocity > 0.1f)
                {
                    state = PlayerMovementStates.jumping;
                }
                else
                {
                    state = PlayerMovementStates.falling;
                }
            }

            animator.SetInteger("state", (int)state);

       

    }

  

    void flip()
    {
        playerFacingRight = !playerFacingRight;
        transform.Rotate(0f, 180f, 0f);     

    }
    
  
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Cloud") || collision.gameObject.CompareTag("EarthBlock"))
        {
            
            playerOnGround = true;
            animator.SetBool("isJumping", false);
        }
 
    }



}
