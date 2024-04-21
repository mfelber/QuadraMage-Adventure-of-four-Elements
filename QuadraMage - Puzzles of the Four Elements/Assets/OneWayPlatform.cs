using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayPlatform : MonoBehaviour
{

    private GameObject currentOneWayPlatform;

    [SerializeField] private CircleCollider2D playerCollider;
    [SerializeField] private CapsuleCollider2D playercolider;
    void Start()
    {
        
    }

   
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S) && PlayerMovement.inRangeOfLadder == true)
        {
            if (currentOneWayPlatform != null)
            {
                StopAllCoroutines();
                StartCoroutine(DisableCollision());
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OneWayPlatform"))
        {
            currentOneWayPlatform = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OneWayPlatform"))
        {
            currentOneWayPlatform = null;
        }
    }

    private IEnumerator DisableCollision ()
    {
        BoxCollider2D platformCollider = currentOneWayPlatform.GetComponent<BoxCollider2D>();
        Physics2D.IgnoreCollision(playerCollider, platformCollider);
        Physics2D.IgnoreCollision(playercolider, platformCollider);
        yield return new WaitForSeconds (2f);
        Physics2D.IgnoreCollision(playerCollider, platformCollider,false);
        Physics2D.IgnoreCollision(playercolider, platformCollider,false);
    }
}
