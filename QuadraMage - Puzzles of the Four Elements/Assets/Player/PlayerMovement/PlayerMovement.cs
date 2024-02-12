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

    [SerializeField] private Animator animator;



    [Serialize] private float playerMove = 0f;
    [Serialize] public float jumpHeight = 7f;
    [Serialize] public float playerSpeed = 3.5f;


    public static bool playerOnGround = true;

    bool playerFacingRight = true;

    public static bool PlayerIsMoving;

    private enum PlayerMovementStates { idle, running, jumping, falling }
    private enum NewPlayerMovementStates { idle, running, jumping, falling, land }


    public static bool isInputEnabled = true;



    private void Start()
    {

        Player = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();


        isInputEnabled = true;


    }


    public void playerIsMoving()
    {
        PlayerIsMoving = true;
    }

    public void playerIsNotMoving()
    {
        PlayerIsMoving = false;
    }


    public void DesibleInput()
    {
        isInputEnabled = false;
        Player.velocity = Vector2.zero;
        
    }

    public void EnableInput()
    {
        isInputEnabled = true;
    }

    


    void Update()
    {
       
            if (!NewPauseMenu.isPauseMenuOpen && !Book.isBookOpen && isInputEnabled && !MovingPlatform.isChildOfPlatform)
            {
                Vector3 mouseP = Camera.main.ScreenToWorldPoint(Input.mousePosition);


                if (!Inventory.isPlayerUsingElement )
                {
                    playerMove = Input.GetAxisRaw("Horizontal");



                    if (playerMove > 0 || playerMove < 0)
                    {
                        playerIsMoving();

                    }
                    else
                    {
                        playerIsNotMoving();

                    }
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
                }



            }
            UpdateAnimation();

            /*
            if (PauseMenu.isGamePaused == true && playerOnGround == false)
            {

            }

            */

        




    }



    public bool playerInmagnifer = false;

    private void UpdateAnimation()
    {
        float verticalVelocity = Player.velocity.y;
        NewPlayerMovementStates states;
        PlayerMovementStates state;


        if (playerInmagnifer == true)
        {

            states = NewPlayerMovementStates.idle;
            Invoke("outofMagnifer", 4.6f);

        } else if (playerOnGround && playerInmagnifer == false)
        {
            if (Mathf.Abs(playerMove) > 0.1f)
            {
                states = NewPlayerMovementStates.running;
                state = PlayerMovementStates.running;
            }
            else
            {
                states = NewPlayerMovementStates.idle;
                state = PlayerMovementStates.idle;
            }

        }
        else
        {
            if (verticalVelocity > 0.1f)
            {

                states = NewPlayerMovementStates.jumping;
                state = PlayerMovementStates.jumping;
            }
            else
            {

                states = NewPlayerMovementStates.falling;
                state = PlayerMovementStates.falling;
            }


        }



        //animator.SetInteger("state", (int)state);
        animator.SetInteger("state", (int)states);



    }

    void outofMagnifer()
    {
        playerInmagnifer = false;
    }













    void flip()
    {
        playerFacingRight = !playerFacingRight;
        transform.Rotate(0f, 180f, 0f);     

    }

   





    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Cloud") || collision.gameObject.CompareTag("EarthBlock") )
        {
            
            playerOnGround = true;
            
        }

        
      
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Magnifer"))
        {
            playerInmagnifer = true;
        }

    }

   





}
