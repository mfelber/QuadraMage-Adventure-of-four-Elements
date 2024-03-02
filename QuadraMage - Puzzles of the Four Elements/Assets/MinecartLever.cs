using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinecartLever : MonoBehaviour
{
    public Animator minecartAnimator;
    public bool leverIsActive;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.inRangeOfLever == true && Input.GetKeyDown(KeyCode.E)&& leverIsActive == false)
        {
            activateMinecartLever();
        }
    }

    public void activateMinecartLever()
    {
        Player.inRangeOfLever = false;
        Debug.LogError(Player.inRangeOfLever);
        minecartAnimator.SetBool("go", true);
        leverIsActive = true;
        Invoke("deactivateLever", 1.5f);
    }

    public void deactivateLever()
    {
        minecartAnimator.SetBool("go", false);
        leverIsActive = false;
        Player.inRangeOfLever = true;
    }
}
