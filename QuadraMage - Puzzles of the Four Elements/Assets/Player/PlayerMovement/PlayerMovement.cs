using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{

    PauseMenu pauseMenu;

    [Serialize] Rigidbody2D Player;    
    
    private Animator animator;
    

    [Serialize] private float playerMove = 0f;
    [Serialize] public float jumpHeight = 7f;
    [Serialize] public float playerSpeed = 3.5f;

    bool playerOnGround = true;
    bool playerFacingRight = true;

    private enum PlayerMovementStates { idle, running, jumping , falling}
    


    private void Start()
    {
        
        Player = GetComponent<Rigidbody2D>();
        
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        if (!PauseMenu.isGamePaused)
        {
            Vector3 mouseP = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            playerMove = Input.GetAxisRaw("Horizontal");
            Player.velocity = new Vector2(playerMove * playerSpeed, Player.velocity.y);

            if (Input.GetButtonDown("Jump") && playerOnGround)
            {
               // animator.SetBool("running", false);
                Player.velocity = new Vector2(Player.velocity.x, jumpHeight);
                playerOnGround = false;
            }

            

            if (mouseP.x < Player.transform.position.x && playerFacingRight)
            {
                flip();


            }
            else if (mouseP.x > Player.transform.position.x && !playerFacingRight)
            {
                flip();

            }
            
            UpdateAnimation();
        }
       

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
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Cloud"))
        {
            
            playerOnGround = true;
        }
    }


}