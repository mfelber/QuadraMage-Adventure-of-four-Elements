using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatFormWithBoxAndPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public bool IsonPlatformWhileMoving = false;
    public Animator animator;

    private bool isAnimationEnabledRight;

    private bool isAnimationEnabledLeft;

    public bool bothOnPlatform = false;
    public bool movingtoright;
    private bool movingtoleft;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.CompareTag("Player")) && (collision.gameObject.CompareTag("Box")))
        {
            bothOnPlatform = true;

        }

        /*
        if (collision.gameObject.CompareTag("Box"))
        {
            //boxOnPlatform = true;
            Debug.LogError("Box je na platforme");
        }
        */

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
