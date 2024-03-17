using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilShoot : MonoBehaviour
{
    public GameObject attack;
    public Transform attackPosition;
    private float timer;
    public Animator Devilanimator;
    public Animator RockAnimator;
    public Animator RockAnimator2;
    public Animator RockAnimator3;
    //public Animator RockAnimator4;
    public GameObject stoneFromPlatform;
    public GameObject stoneFromAbove;
    public bool playerInRangeOfDevil;
    public PlayerMovement PlayerMovement;
    public bool smashFirstTime;
    public bool smashSecondTime;
    public bool attackStop;
    public GameObject player;
    public List<GameObject> troops;
    public Animator ground;
    Devil devil;
    void Start()
    {
        
        for (int i = 0; i < troops.Count; i++)
        {
            troops[i].SetActive(false);
        }
        devil = FindObjectOfType<Devil>();
    }

    // Update is called once per frame
    void Update()
    {
        

        /*
        if (timer > 2)
        {
            timer = 0;
            shoot();
        }
        */

        Debug.Log(attackStop);
        

        

        if (playerInRangeOfDevil)
        {

            timer += Time.deltaTime;

            /*
            if (attackStop == false)
            {
                Devilanimator.SetBool("attack", true);
            }
            */
           

            if (smashFirstTime == false)
            {
                if (timer > 10)
                {
                    
                    attackStop = true;
                    Devilanimator.SetBool("attack", false);
                    smashFirstTime = true;
                    Invoke("firstSmashAttack", 0.1f);
                   
                    
                    //RockAnimator.SetBool("rocks", true);
                    // Devilanimator.SetBool("smashAttack", true);
                    
                    
                    //RockAnimator4.Play("Fall");
                    StartCoroutine(resetAnimations());
                }
            } 
                Devilanimator.SetBool("attack", true);
            

            
                
           


            



        }



        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            PlayerMovement.HowMuchTimeIsLeft = PlayerMovement.TimeOfKnockBack;
            if (collision.transform.position.x <= transform.position.x)
            {
                PlayerMovement.knockBackFromR = true;

            }
            if (collision.transform.position.x > transform.position.x)
            {
                PlayerMovement.knockBackFromR = false;

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Devilanimator.SetBool("playerInRange", true);
            playerInRangeOfDevil = true;

        }
    }

    public void firstSmashAttack()
    {
        RockAnimator.SetBool("rocks",true);
        // StartCoroutine(resetAnimations());
        RockAnimator2.SetBool("fall", true);
        RockAnimator3.Play("rockUp");
        Invoke("smash", 0.2f);
        if (PlayerMovement.playerOnGround == true)
        {
            PlayerMovement.HowMuchTimeIsLeft = PlayerMovement.TimeOfKnockBack;
            PlayerMovement.knockBackFromR = true;
        }
        
    }

    public void smash()
    {
        Rigidbody2D rb2 = stoneFromAbove.GetComponent<Rigidbody2D>();
        rb2.bodyType = RigidbodyType2D.Dynamic;
        Invoke("ContinueSmash", 0.1f);
    }

    public void ContinueSmash()
    {
        Rigidbody2D rb = stoneFromPlatform.GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    public void shoot()
    {
        Instantiate(attack, attackPosition.position, Quaternion.identity);
    }

    public void rocksFalse()
    {
        Devilanimator.SetBool("rocks", false);
    }

    IEnumerator resetAnimations()
    {
        yield return new WaitForSeconds(1);

        /*
        if (RockAnimator.GetBool("rocks") == true)
        {
            RockAnimator.SetBool("rocks", false);
        }
        */
        if (Devilanimator.GetBool("attack") == false)
        {
            Devilanimator.SetBool("attack", true);
            attackStop = false;
        }


    }

    IEnumerator secondSmash()
    {
        yield return new WaitForSeconds(10);

        Devilanimator.SetBool("attack", false);
        smashSecondTime = true;
        Invoke("secondSmash", 0.1f);
    }

   
                    
                        
}

