using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D Player;

    public float jumpHeight = 40f;
    public float playerSpeed = 30f;
    bool playerOnGround;



    private void Start()
    {
        Player = GetComponent<Rigidbody2D>();
    }


    void Update()
    {

        float x = Input.GetAxisRaw("Horizontal");
        Player.velocity = new Vector2(x * playerSpeed, Player.velocity.y);

        if (Input.GetButtonDown("Jump") && !playerOnGround)        
        {
           
            Player.velocity = new Vector2(Player.velocity.x, jumpHeight);
            playerOnGround = true;
        }

      

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            playerOnGround=false;
        }
    }




}
