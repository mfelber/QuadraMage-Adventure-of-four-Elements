using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatFormWithBox : MonoBehaviour
{
    public Animator animator;

    private bool isAnimationEnabledRight;

    private bool isAnimationEnabledLeft;
    public bool boxOnPlatform = false;

    public bool movingtoright;
    private bool movingtoleft;
    void Start()
    {
        animator = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
