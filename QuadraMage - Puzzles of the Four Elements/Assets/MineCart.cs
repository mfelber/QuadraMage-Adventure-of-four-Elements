using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineCart : MonoBehaviour
{

   public  Animator animator;
    bool onplatform;
    [SerializeField] Transform gold;
    [SerializeField] private BoxCollider2D boxCollider2D;
    


    private void Start()
    {
        
        boxCollider2D = GetComponent<BoxCollider2D>();
        
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Gold"))
        {
            Debug.LogError("som");
            gold = collision.transform;
            gold.SetParent(transform);
            onplatform = true;    


        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.LogError("uz nie som");

        if (collision.gameObject.CompareTag("Gold"))
        {
            if (onplatform == true)
            {
                gold.SetParent(null);
                onplatform = false;
            }
        }
    }


    public void outofplatform ()
    {
        if (onplatform == true) {
            Rigidbody2D goldRB = gold.gameObject.GetComponent<Rigidbody2D>();
            boxCollider2D.enabled = false;
            goldRB.AddForce(new Vector2(20f, 10f), ForceMode2D.Impulse);
            Invoke("collider", 1.2f);
            //playerRigidbody.gravityScale = 3;
        }

        //Invoke("cartgoBack", 1.5f);
        

    }

    public void cartgoBack()
    {
        animator.SetBool("go", false);
    }

    public void collider()
    {
        boxCollider2D.enabled = true;
    }

}
