using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class specialGuard : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator specialGuardAnimator;
    public GameObject specialGuardGO;
    private Renderer specialGuardRenderer;
    public Sprite dead;
    public PlayerMovement PlayerMovement;

    private bool isHit = false;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(isHit)
        {
            specialGuardAnimator.enabled = false;
            GetComponent<SpriteRenderer>().sprite = dead;
            Physics2D.IgnoreLayerCollision(6, 7);
        }

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("FireElementShot"))
        {
            //specialGuardAnimator.SetBool("hit", true);
            isHit = true;
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
