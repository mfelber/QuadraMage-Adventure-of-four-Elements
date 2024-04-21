using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    

    public Animator animator;
    

    private void Start()
    {
        animator = GetComponent<Animator>();
      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("PlayerOnPad",true);
            Invoke("playerJump", 1);
        }
    }

   

   

   
    private void playerJump()
    {
        animator.SetBool("PlayerOnPad", false);
    }
}
