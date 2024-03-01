using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMovement : MonoBehaviour
{

    private float verticalMovement;
    private float speed;
    private bool inRange;
    private bool climbing;

    public Rigidbody2D playerRb;



    // Update is called once per frame
    void Update()
    {
        verticalMovement = Input.GetAxis("Vertical");

        if (inRange && Mathf.Abs(verticalMovement) > 0)
        {
            climbing = true;
        }
        Debug.Log("Vertical Movement: " + verticalMovement);
        Debug.Log("In Range: " + inRange);
        Debug.Log("Climbing: " + climbing);

        if (climbing)
        {
            playerRb.gravityScale = 0f;
            playerRb.velocity = new Vector2(playerRb.velocity.x, verticalMovement * speed);
        }
        else
        {
            playerRb.gravityScale = 1f;
        }
    }


    private void FixedUpdate()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            Debug.LogError("si v range");
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            inRange = false;
            climbing = false;
        }
    }
}
