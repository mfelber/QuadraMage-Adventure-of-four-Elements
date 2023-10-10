using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D Player;
    public GameObject wand;

    public float jumpHeight = 40f;
    public float playerSpeed = 30f;

    bool playerOnGround;
    bool playerFacingRight = true;



    private void Start()
    {
        Player = GetComponent<Rigidbody2D>();
    }


    void Update()
    {


        float playerMove = Input.GetAxisRaw("Horizontal");
        Player.velocity = new Vector2(playerMove * playerSpeed, Player.velocity.y);

        if (Input.GetButtonDown("Jump") && !playerOnGround)        
        {
           
            Player.velocity = new Vector2(Player.velocity.x, jumpHeight);
            playerOnGround = true;
        }

        
        if(playerMove > 0 && !playerFacingRight )
        {
            
            flipPlayer();
            flipWand();
            
        }
        else if (playerMove < 0 && playerFacingRight )
        {
           
            
            flipPlayer();
            flipWand();
            Debug.Log("looking to left");
        }


    }




    void flipWand()
    {
        Vector3 currentScale = wand.transform.localScale;
        currentScale.x *= -1;
        wand.transform.localScale = currentScale;

    }


    void flipPlayer()
    {
        Vector3 currentScale = Player.transform.localScale;
        currentScale.x *= -1;
        Player.transform.localScale = currentScale;

        playerFacingRight = !playerFacingRight;
    }

  
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            playerOnGround=false;
        }
    }


}
