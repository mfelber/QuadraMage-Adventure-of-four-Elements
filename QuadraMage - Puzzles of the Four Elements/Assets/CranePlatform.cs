using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CranePlatform : MonoBehaviour
{
    
    public bool tntOnPlatWhileAnim;
    craneHand craneHandScript;
   
    void Start()
    {
        tntOnPlatWhileAnim = false;
        craneHandScript = FindObjectOfType<craneHand>();
    }

    
    void Update()
    {
        if(craneHandScript.animationGoing && tntOnPlatWhileAnim)
        {
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("item"), true);
        } else
        {
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("item"), false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tnt"))
        {
            collision.transform.SetParent(transform);
            tntOnPlatWhileAnim = true;
            
        } else
        {
            return;
        }

        

       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Destroy"))
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tnt"))
        {

            collision.transform.SetParent(null);
            tntOnPlatWhileAnim = false;

        } else
        {
            return;
        }
    }
}
