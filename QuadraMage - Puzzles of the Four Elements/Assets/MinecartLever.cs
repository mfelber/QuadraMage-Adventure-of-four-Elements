using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinecartLever : MonoBehaviour
{
    public Animator minecartAnimator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.inRangeOfLever && Input.GetKeyDown(KeyCode.E))
        {
            activateMinecartLever();
        }
    }

    public void activateMinecartLever()
    {
        minecartAnimator.SetBool("go", true);
        Invoke("deactivateLever", 1.5f);
    }

    public void deactivateLever()
    {
        minecartAnimator.SetBool("go", false);
    }
}
