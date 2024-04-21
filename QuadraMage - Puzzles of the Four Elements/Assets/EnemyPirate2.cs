using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPirate2 : MonoBehaviour
{
    public Animator animator;
    public PlayerMovement PlayerMovement;
    tnt Tnt;
    public static bool pirate2NearTnt;
    public string tntObjectName;
    void Start()
    {
        GameObject tntObject = GameObject.Find(tntObjectName);
        Tnt = tntObject.GetComponent<tnt>();

        pirate2NearTnt = false;
        //Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Enemy"), LayerMask.NameToLayer("Ground"), true);
    }

    // Update is called once per frame
    void Update()
    {
        if (pirate2NearTnt && Tnt.time < 0)
        {
            animator.Play("pirateOverBoard2");
        }
        Debug.LogError(pirate2NearTnt);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       



        if (collision.gameObject.CompareTag("TNTPIRATE"))
        {
            Debug.Log("kolizia s tnt");
            pirate2NearTnt = true;
        }


    }


    
    /*
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.name == tntObjectName)
        {
            Invoke("setCollision", 1f);
            // Debug.Log("kolizia");
            // pirateNearTnt = false;
        }
    }
    */

    public void setCollision()
    {
        pirate2NearTnt = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("WindElementShot"))
        {
            animator.Play("pirateOverBoard2");
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
           // Debug.Log("kolizia");
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
