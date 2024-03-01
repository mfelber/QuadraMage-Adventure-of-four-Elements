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
   


    [Serialize] Rigidbody2D playerRB;
    [SerializeField] private Animator animator;




    [Serialize] private float playerMove = 0f;
    [Serialize] public float jumpHeight = 7f;
    [Serialize] public float playerSpeed = 3.5f;
    public float KnobBackForce;
    public float HowMuchTimeIsLeft;
    public float TimeOfKnockBack;



    public bool knockBackFromR;
    private bool playerFacingRight = true;
    private bool playerInmagnifer = false;

    public static bool playerOnGround = true;
    public static bool PlayerIsMoving;
    public static bool isInputEnabled = true;
    public bool knockBackIsGoing;

    CapsuleCollider2D bodyCollider;
    BoxCollider2D feet;
    CircleCollider2D feet2;
    Rigidbody2D rigidbody2D;

    private bool isKnockbackInProgress = false;

    private enum PlayerMovementStates { idle, running, jumping, falling }
    public enum NewPlayerMovementStates { idle, running, jumping, falling, land }





    private void Start()
    {

        playerRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        bodyCollider = GetComponent<CapsuleCollider2D>();
        feet = GetComponent<BoxCollider2D>();
        feet2 = GetComponent<CircleCollider2D>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        
       
        isInputEnabled = true;

    }




    
    
    void Update()
    {
       

        if (!NewPauseMenu.isPauseMenuOpen && !Book.isBookOpen && isInputEnabled && !MovingPlatform.isChildOfPlatform )
            {
                Vector3 mouseP = Camera.main.ScreenToWorldPoint(Input.mousePosition);


                if (!Inventory.isPlayerUsingElement )
                {
                    if(HowMuchTimeIsLeft <= 0)
                {
                    if (knockBackIsGoing == false )
                    {
                        playerMove = Input.GetAxisRaw("Horizontal");
                        playerRB.velocity = new Vector2(playerMove * playerSpeed, playerRB.velocity.y);
                    }
                    
                } else
                {
                    
                    if(knockBackFromR == true)
                    {
                        playerRB.velocity = new Vector2(-KnobBackForce,KnobBackForce);
                        knockBackIsGoing = true;
                        //Debug.LogError(knockBackIsGoing);
                        playerOnGround = false;
                        Invoke("knockbackOff",1.3f);
                        
                    }
                    if (knockBackFromR == false)
                    {
                        playerRB.velocity = new Vector2(KnobBackForce, KnobBackForce);
                        knockBackIsGoing=true;
                        //Debug.LogError(knockBackIsGoing);
                        playerOnGround = false;
                        Invoke("knockbackOff", 1.3f);


                    }

                    HowMuchTimeIsLeft -= Time.deltaTime;
                    
                    //Debug.LogError(knockBackIsGoing);
                }

                    
                    
                    if (playerMove > 0 || playerMove < 0)
                    {
                        playerIsMoving();
                    }
                    else
                    {
                        playerIsNotMoving();
                    }

                if (Input.GetButtonDown("Jump") && playerOnGround)
                    {
                        playerRB.velocity = new Vector2(playerRB.velocity.x, jumpHeight);
                        playerOnGround = false;

                    }


                    if (mouseP.x < playerRB.transform.position.x && playerFacingRight)
                    {
                        flip();
                    }
                    else if (mouseP.x > playerRB.transform.position.x && !playerFacingRight)
                    {
                        flip();
                    }
                }
             UpdateAnimation();
            }


    }

    

    


    private void knockbackOff()
    {
        knockBackIsGoing = false;
    }



    private void UpdateAnimation()
    {
        float verticalVelocity = playerRB.velocity.y;
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

    

    void flip()
    {
        playerFacingRight = !playerFacingRight;
        transform.Rotate(0f, 180f, 0f);     

    }

   


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (feet2.IsTouching (collision.collider))
        {
            if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Cloud") || collision.gameObject.CompareTag("EarthBlock") || collision.gameObject.CompareTag("Box"))
            {
                playerOnGround = true;
            }
        }
       
      
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Magnifer"))
        {
            playerInmagnifer = true;
        }

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
        playerRB.velocity = Vector2.zero;

    }

    public void EnableInput()
    {
        isInputEnabled = true;
    }

    void outofMagnifer()
    {
        playerInmagnifer = false;
    }
}
