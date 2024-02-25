using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformWithObjects : MonoBehaviour
{
    public Animator animator;

    private bool isAnimationEnabledRight;
    private bool isAnimationEnabledLeft;

    public bool isOnPlatformWhileMoving = false;

    private bool movingToRight;
    private bool movingToLeft;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Box") || collision.gameObject.CompareTag("Gold") ||
            collision.gameObject.CompareTag("Iron") || collision.gameObject.CompareTag("Wood"))
        {
            Debug.Log("Object on platform");
            isOnPlatformWhileMoving = true;
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Box") || collision.gameObject.CompareTag("Gold") ||
            collision.gameObject.CompareTag("Iron") || collision.gameObject.CompareTag("Wood"))
        {
            Debug.Log("Object exited platform");
            collision.transform.SetParent(null);
            isOnPlatformWhileMoving = false;
        }
    }
    /*
    private void Update()
    {
        isAnimationEnabledRight = animator.GetBool("IsMovingToRight");
        isAnimationEnabledLeft = animator.GetBool("IsMovingToLeft");

        movingToRight = isAnimationEnabledRight;
        movingToLeft = isAnimationEnabledLeft;

        if (isOnPlatformWhileMoving && (movingToRight || movingToLeft))
        {
            Debug.Log("Animation is active");
        }
    }
    */
}
