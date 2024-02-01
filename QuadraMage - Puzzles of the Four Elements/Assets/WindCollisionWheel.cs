using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WindCollisionWheel : MonoBehaviour
{

    public Animator anim;
    private bool moving = false;
    private float time = 0f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("WindElementShot") && !moving)
        {
           
            if (anim != null)
            {
                anim.SetBool("isMoving", true); 
                moving = true; 
            }
        }
    }

    private void Update()
    {
        if (moving == true)
        {
            time += Time.deltaTime;
            if(time > 5f)
            {
                anim.SetBool("isMoving", false);
                moving = false;
                time = 0f;
            }
        }
    }

}
