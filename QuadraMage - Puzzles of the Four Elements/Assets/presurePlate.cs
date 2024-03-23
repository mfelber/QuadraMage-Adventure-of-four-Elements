using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class presurePlate : MonoBehaviour
{
    public Animator animator; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Box"))
        {
            Debug.Log("Je tu box");
            animator.SetBool("BoxOnPlate", true);
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Box opustil plate");
        animator.SetBool("BoxOnPlate", false);
    }
}

   

