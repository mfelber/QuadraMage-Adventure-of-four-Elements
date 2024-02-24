using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatFormWithBox : MonoBehaviour
{
    public Animator animator;
    public GameObject box;
    public GameObject gold;
    public GameObject iron;
    public GameObject wood;


    private bool isAnimationEnabledRight;
    public bool IsonPlatformWhileMoving = false;

    private bool isAnimationEnabledLeft;
    public bool boxOnPlatform = false;

    private bool movingtoright;
    private bool movingtoleft;



    void Start()
    {
        animator = GetComponent<Animator>();    
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Box") )
        {
            Debug.LogError("je");
            boxOnPlatform = true;

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Box") ){
            collision.transform.SetParent(null);
            boxOnPlatform = false;
            Debug.LogError("uz neni Box");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        isAnimationEnabledRight = animator.GetBool("IsMovingToRight");
        isAnimationEnabledLeft = animator.GetBool("IsMovingToLeft");

        movingtoleft = isAnimationEnabledLeft;
        movingtoright = isAnimationEnabledRight;

        if (boxOnPlatform && (movingtoright == true || movingtoleft == true))
        {
            Debug.LogError("Animation is going");
            GameObject box = GameObject.FindGameObjectWithTag("Box");

            if (box != null)
            {

                box.transform.SetParent(transform);

                IsonPlatformWhileMoving = true;
            }
        }
        else
        {
            IsonPlatformWhileMoving = false;
            GameObject box = GameObject.FindGameObjectWithTag("Box");

            if (box != null && box.transform.parent == transform)
            {

                box.transform.SetParent(null);

            }
        }
    }
}
