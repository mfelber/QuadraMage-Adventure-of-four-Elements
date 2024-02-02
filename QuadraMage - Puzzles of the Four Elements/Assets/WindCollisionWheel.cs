using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindCollisionWheel : MonoBehaviour
{
    public Animator anim;
    private bool moving = false;
    private float time = 0f;
    private bool movingToRight;
    private bool movingToLeft;
    public float posxRight1;
    public float posxLeft1;
    public float posxRight2;
    public float posxLeft2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("WindElementShot") && !moving)
        {
            Debug.Log("Collider entered!");

            if (anim != null)
            {
                moving = true;

                float xPosition = anim.transform.position.x;

                if (xPosition >= posxRight1 && xPosition <= posxRight2)
                {
                    anim.SetBool("IsMovingToRight", true);
                    anim.SetBool("IsMovingToLeft", false);
                    Debug.LogError("Moving to the right!");
                }
                else if (xPosition >= posxLeft1 && xPosition <= posxLeft2)
                {
                    anim.SetBool("IsMovingToLeft", true);
                    anim.SetBool("IsMovingToRight", false);
                    Debug.LogError("Moving to the left!");
                }
            }
        }
    }


    private void Update()
    {
        if (moving)
        {
            // Check the current playing animations
            AnimatorClipInfo[] clipInfo = anim.GetCurrentAnimatorClipInfo(0);

            // Check if there's any clip info
            if (clipInfo.Length > 0)
            {
                // Iterate through each clip and print information to the console
                foreach (AnimatorClipInfo info in clipInfo)
                {
                    string currentAnimationName = info.clip.name;
                    float currentAnimationTime = info.clip.length * info.weight; // Adjust the factor based on your needs
                    Debug.Log("Current Animation: " + currentAnimationName );

                    // Example: Check if a specific animation is playing
                    if (currentAnimationName == "MovingPlatformToLeft")
                    {
                        Debug.LogError("si v default");
                        anim.SetBool("IsMovingToLeft", false);
                        anim.SetBool("IsMovingToRight", false);
                        moving = false;
                        // Do something based on the current animation state
                    }
                }
            }

            // Add your update logic here
        }
    }
}
