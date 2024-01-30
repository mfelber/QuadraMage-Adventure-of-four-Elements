using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : MonoBehaviour
{
    public Animator animator;
    private float time = 0f;
    private bool isMoving = false;

    
    void Start()
    {
        animator = GetComponent<Animator>();
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
      
            animator.Play("Moving");
            isMoving = true;
            animator.SetBool("isMoving", true);
        
        
       
        
        
    }

    private void Update()
    {
        //time++;
        if(isMoving== true)
        {
            time += Time.deltaTime;
            if (time > 5f)
            {
                animator.SetBool("isMoving", false);
                isMoving = false;
                time = 0f;
                
            }
        }
        
    }
}
