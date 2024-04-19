using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{

    PauseMenu pauseMenu;
    NewPauseMenu newPauseMenu;
    
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
    public static bool playerFacingRight = true;
    private bool playerInmagnifer = false;
   

    public static bool playerOnGround = true;
    public static bool PlayerIsMoving;
    public static bool isInputEnabled = true;
    public bool knockBackIsGoing;

    CapsuleCollider2D bodyCollider;
    BoxCollider2D feet;
    CircleCollider2D feet2;
    Rigidbody2D rigidbody2D;

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

        playerFacingRight = true;
        isInputEnabled = true;

        
       
    }




    private float verticalMovement;
    public static bool inRangeOfLadder;
    private bool climbing;

    [SerializeField] private LayerMask Ground;
    



    

    void Update()
    {


        

        if (!Inventory.isPlayerUsingElement && !NewPauseMenu.isPauseMenuOpen  && isInputEnabled && !MovingPlatform.isChildOfPlatform && !DialogManager.isDialgueActive)
            {

            
                Vector3 mouseP = Camera.main.ScreenToWorldPoint(Input.mousePosition);


            verticalMovement = Input.GetAxis("Vertical");

            if (inRangeOfLadder && Mathf.Abs(verticalMovement) > 0 )
            {
                climbing = true;
               
            } 

            if (climbing)
            {
                playerRB.gravityScale = 0f;
                playerRB.velocity = new Vector2(playerRB.velocity.x, verticalMovement * playerSpeed);
            }
            else
            {
                playerRB.gravityScale = 1f;
            }

            if (!Inventory.isPlayerUsingElement)
                //Debug.Log(Inventory.isPlayerUsingElement);
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


                /*
                 *  if (Input.GetButtonDown("Jump") && playerOnGround)
                {
                    playerRB.velocity = new Vector2(playerRB.velocity.x, jumpHeight);
                    playerOnGround = false;

                }
                 */

                    
                if (isGrounded() == true)
                {
                    playerOnGround  = true;
                } else
                {
                    playerOnGround = false;
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

        //Debug.LogError("pozeram do prava" + playerFacingRight);
        // Debug.LogError("pozeram do lava" + !playerFacingRight);

        //Debug.LogError(playerOnGround);



       


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


       

        if (playerInmagnifer == true || climbing == true)
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

   
    public bool isGrounded()
    {
        return Physics2D.BoxCast(feet2.bounds.center, feet2.bounds.size, 0f, Vector2.down, 0.1f, Ground);
            



    }

    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (feet2.IsTouching (collision.collider))
        {
            if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Cloud") || collision.gameObject.CompareTag("EarthBlock") || collision.gameObject.CompareTag("Box") || collision.gameObject.CompareTag("OneWayPlatform")|| collision.gameObject.CompareTag("Bridge"))
            {
                playerOnGround = true;
            }

            
        }

        if (feet2.IsTouching(collision.collider))
        {
            if(collision.gameObject.CompareTag("MushRoom"))
            {
                playerRB.AddForce(Vector2.up * 1, ForceMode2D.Impulse);

            }
        }

        
    }

    


    
    /*
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!feet2.IsTouching(collision.collider))
        {
            StopAllCoroutines();
            StartCoroutine(NotTouching());
            
        }

    }
    */
    IEnumerator NotTouching()
    {
        yield return new WaitForSeconds(0.050f);
        playerOnGround = false;

    }




    private void OnTriggerEnter2D(Collider2D collision)
    {

        
        if (collision.gameObject.CompareTag("Magnifer"))
        {
            playerInmagnifer = true;
        }

        

     
            if (collision.gameObject.CompareTag("Ladder"))
            {
               
                inRangeOfLadder = true;
            

            }
            
        








        }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            inRangeOfLadder = false;
            climbing = false;
           

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
