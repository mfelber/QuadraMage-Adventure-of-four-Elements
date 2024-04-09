using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class specialGuard : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator specialGuardAnimator;
    //public GameObject specialGuardGO;
    private Renderer specialGuardRenderer;
   // public Sprite dead;
    public PlayerMovement PlayerMovement;

    public bool isHit = false;
    public bool hitByWater = false;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(isHit)
        {
            specialGuardAnimator.Play("specialGuardElimination");
           // specialGuardAnimator.enabled = false;
            // GetComponent<SpriteRenderer>().sprite = dead;
            Physics2D.IgnoreLayerCollision(6, 7);
        }


        if (hitByWater)
        {
            
            Physics2D.IgnoreLayerCollision(6, 7);
            Invoke("desibleAnimator", 0.6f);
        }

    }

    public void desibleAnimator()
    {
        specialGuardAnimator.Play("specialGuardElimination");
        specialGuardAnimator.enabled = false;

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("FireElementShot"))
        {
            //specialGuardAnimator.SetBool("hit", true);
            isHit = true;
            Destroy(collision.gameObject);
        }


        if (collision.gameObject.CompareTag("WaterElementShot"))
        {
            //specialGuardAnimator.SetBool("hit", true);
            hitByWater = true;
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("WindElementShot"))
        {
            Destroy(collision.gameObject);
        }

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
}
