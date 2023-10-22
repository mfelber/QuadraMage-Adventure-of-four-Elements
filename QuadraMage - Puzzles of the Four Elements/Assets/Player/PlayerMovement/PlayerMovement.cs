using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D Player;    
    public GameObject player;

    PauseMenu pauseMenu;
    
  

    public float jumpHeight = 40f;
    public float playerSpeed = 30f;

    bool playerOnGround;
    bool playerFacingRight = true;



    private void Start()
    {
        
        Player = GetComponent<Rigidbody2D>();
        player = player.gameObject;     
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
