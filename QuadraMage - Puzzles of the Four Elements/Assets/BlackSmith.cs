using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackSmith : MonoBehaviour
{
    
    private enum BlackSmithStates { idle, patrol, warning}
    [SerializeField] private Animator blackSmithAnimator;
    BlackSmithStates states;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        checkForStates();

    }

    public void checkForStates()
    {
       

        if (ArmorStand.isPlayerMoveWithArmorStand)
        {
            states = BlackSmithStates.patrol;
        } else
        {
            states = BlackSmithStates.idle;
        }

        blackSmithAnimator.SetInteger("state", (int)states);
        
    }
}
