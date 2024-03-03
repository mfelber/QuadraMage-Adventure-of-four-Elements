using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{


    public int heat;
    public Animator PatrolLeverAnimator;
    private enum PatroLeverStates { smoke, smokeHold,smokeMoving};
    void Start()
    {
        PatrolLeverAnimator = GetComponent<Animator>();
    }

   
    void Update()
    {
        if (heat > 100)
        {
            // set states
        }
    }
}
