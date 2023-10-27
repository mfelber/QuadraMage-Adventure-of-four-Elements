using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D Player;    
    public GameObject player;
    private Animator animator;

    PauseMenu pauseMenu;



    public float jumpHeight = 10f;
    public float playerSpeed = 3.5f;

    bool playerOnGround;
    bool playerFacingRight = true;



    private void Start()
    {
        
        Player = GetComponent<Rigidbody2D>();
        player = player.gameObject;  
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        if (!PauseMenu.isGamePaused)
        {
            Vector3 mouseP = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            float playerMove = Input.GetAxisRaw("Horizontal");
            Player.velocity = new Vector2(playerMove * playerSpeed, Player.velocity.y);

            if (Input.GetButtonDown("Jump") && !playerOnGround)
            {
               // animator.SetBool("running", false);
                Player.velocity = new Vector2(Player.velocity.x, jumpHeight);
                playerOnGround = true;
            }


            if (mouseP.x < Player.transform.position.x && playerFacingRight)
            {
                flip();


            }
            else if (mouseP.x > Player.transform.position.x && !playerFacingRight)
            {
                flip();

            }

            // animation if player is moving or player is idle
            if(playerMove > 0f)
            {
                animator.SetBool("running",true);
            }else if (playerMove < 0f)
            {
                animator.SetBool("running", true);
            }
            else
            {
                animator.SetBool("running", false);
            }
        }
       

    }

    void flip()
    {
        playerFacingRight = !playerFacingRight;
        player.transform.Rotate(0f, 180f, 0f);
        

    }
    
  
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            playerOnGround=false;
        }
    }


}
