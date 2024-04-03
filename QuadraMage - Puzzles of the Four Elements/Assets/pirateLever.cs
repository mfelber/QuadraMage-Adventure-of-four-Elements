using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pirateLever : MonoBehaviour
{

    public Animator PatrolLever;
    public PlayerMovement PlayerMovement;
    Cauldron cauldron;
   public GameObject leverOff, leverOn;
    public Animator woodAnimator;
    void Start()
    {
        //PatrolLever = GetComponent<Animator>(); 
        cauldron = FindObjectOfType<Cauldron>();
        leverOff.SetActive(true);
        leverOn.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            Debug.LogError("kolizia");
            if(cauldron.hotWater)
            {
                PatrolLever.SetBool("water", true);
            } 
           
        }

        if (collision.gameObject.CompareTag("Lever"))
        {
            woodAnimator.Play("woodLogLeverDownLevel2");
            leverOff.SetActive(false);
            leverOn.SetActive(true);

        }
    }

   

    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("smoke"))
        {
            Debug.LogError("kolizia");
            PatrolLever.SetBool("smoke", true);
        }
    }
    */

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("kolizia");
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

}
