using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPirate : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator animator;
    public PlayerMovement PlayerMovement;
    tnt Tnt;
    public bool pirateNearTnt;
    //public string tntObjectName;
    public string tntObjectName;
    void Start()
    {
        //GameObject tntObject = GameObject.Find(tntObjectName);
        GameObject tntObject = GameObject.Find(tntObjectName);

        // Tnt = FindObjectOfType<tnt>();
        Tnt = tntObject.GetComponent<tnt>();
        if (Tnt == null)
        {
            Debug.LogError("TNT object not found!");
        }
        pirateNearTnt = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Tnt.time);

        if (pirateNearTnt && Tnt.time < 0)
        {
            animator.SetBool("overBoardPirate2", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Kolizia");
            animator.SetBool("go", true);
        }

        if (collision.gameObject.CompareTag("FireSpread"))
        {
           // Debug.LogError("kolizia ohen + pirat");
            animator.SetBool("overBoardPirate3", true);
        }

        

        if (collision.gameObject.name == tntObjectName)
        {
            Debug.Log("kolizia");
            pirateNearTnt =true;
        }

        if (collision.gameObject.CompareTag("cage"))
        {
            animator.SetBool("overBoardPirate5", true);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        /*
        if (collision.gameObject.name == tntObjectName)
        {
            Debug.Log("neni kolizia");
            pirateNearTnt = false;
        }
        */
    }


    public void setCollision ()
    {
        pirateNearTnt = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("WindElementShot"))
        {
            animator.SetBool("pirateOverBoard", true);
            animator.SetBool("overBoardPirate3", true);
            animator.SetBool("overBoardPirate4", true);
            Destroy(collision.gameObject);
        }

        

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
