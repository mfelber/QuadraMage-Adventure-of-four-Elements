using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pirateLever : MonoBehaviour
{

    public Animator PatrolLever;
    public PlayerMovement PlayerMovement;
    void Start()
    {
        PatrolLever = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("smoke"))
        {
            Debug.LogError("kolizia");
            PatrolLever.SetBool("smoke", true);
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